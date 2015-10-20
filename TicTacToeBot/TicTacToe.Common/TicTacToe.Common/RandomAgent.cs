using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Common
{
    public class RandomAgent : ITicTacToeAgent
    {
        public Token PlayerToken { get; private set; }

        public RandomAgent(Token playerToken)
        {
            PlayerToken = playerToken;
        }

        public void Play(Game simulation)
        {
            if (!simulation.GameOver())
            {
                CryptoRandom rand = new CryptoRandom();
                var square = rand.Next(0, 9);
                while (!simulation.PlaceToken(PlayerToken, square))
                {
                    square = rand.Next(0, 9);
                }
            }
            else
            {
                throw new InvalidOperationException("No token can be placed because the game is over.");
            }
        }

        public void GameOver(Token winner)
        {
        }
    }
}
