using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TicTacToe.Common
{
    public class SimulationRunner
    {
        public int GamesPlayed { get; set; }
        public int TargetGames { get; set; }
        public int XWins { get; set; }
        public int OWins { get; set; }
        private Game simulation;

        public void Simulate(int targetGames, ITicTacToeAgent xPlayer, ITicTacToeAgent oPlayer)
        {
            TargetGames = targetGames;
            
            while (GamesPlayed < TargetGames)
            {
                simulation = new Game();
                CryptoRandom rand = new CryptoRandom();
                var randomPlayer = rand.Next(0, 2);
                ITicTacToeAgent firstPlayer;
                ITicTacToeAgent secondPlayer;

                if (randomPlayer == 0)
                {
                    firstPlayer = xPlayer;
                    secondPlayer = oPlayer;
                }
                else
                {
                    firstPlayer = oPlayer;
                    secondPlayer = xPlayer;
                }

                do
                {
                    firstPlayer.Play(simulation);
                    if (!simulation.GameOver())
                        secondPlayer.Play(simulation);
                }
                while (!simulation.GameOver());

                if (simulation.Winner == Token.X)
                {
                    XWins++;
                }
                else if (simulation.Winner == Token.O)
                {
                    OWins++;
                }

                xPlayer.GameOver(simulation.Winner);
                oPlayer.GameOver(simulation.Winner);

                GamesPlayed++;
            }
        }
    }
}
