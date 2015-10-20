using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Common
{
    public class Game
    {
        private Token _winner = Token.Blank;

        public GameState CurrentState { get; private set; }
        public Token Winner
        {
            get
            {
                if (_winner == Token.Blank)
                {
                    GameOver();
                }

                return _winner;
            }
        }

        public Game()
        {
            StartNewGame();
        }

        public bool GameOver()
        {
            if (CurrentState != null)
            {
                var winStates = new List<int>();
                winStates.Add((int)CurrentState.Board[0] + (int)CurrentState.Board[1] + (int)CurrentState.Board[2]);
                winStates.Add((int)CurrentState.Board[3] + (int)CurrentState.Board[4] + (int)CurrentState.Board[5]);
                winStates.Add((int)CurrentState.Board[6] + (int)CurrentState.Board[7] + (int)CurrentState.Board[8]);
                winStates.Add((int)CurrentState.Board[0] + (int)CurrentState.Board[3] + (int)CurrentState.Board[6]);
                winStates.Add((int)CurrentState.Board[1] + (int)CurrentState.Board[4] + (int)CurrentState.Board[7]);
                winStates.Add((int)CurrentState.Board[2] + (int)CurrentState.Board[5] + (int)CurrentState.Board[8]);
                winStates.Add((int)CurrentState.Board[0] + (int)CurrentState.Board[4] + (int)CurrentState.Board[8]);
                winStates.Add((int)CurrentState.Board[6] + (int)CurrentState.Board[4] + (int)CurrentState.Board[2]);

                if (winStates.Contains(3))
                    _winner = Token.X;
                if (winStates.Contains(-3))
                    _winner = Token.O;

                if (CurrentState.Board.Count(c => c == Token.Blank) == 0)
                    return true;
                else 
                    return _winner != Token.Blank;
            }
            else
            {
                return false;
            }
        }

        public void StartNewGame()
        {
            CurrentState = new GameState();
            _winner = Token.Blank;
        }

        public bool PlaceToken(Token token, int square)
        {
            bool validMove;

            if (CurrentState.Board[square] != Token.Blank)
            {
                validMove = false;
            }
            else
            {
                CurrentState.Board[square] = token;
                CurrentState.LastMove = square;
                CurrentState.LastToken = token;
                validMove = true;
            }

            return validMove;
        }
    }
}
