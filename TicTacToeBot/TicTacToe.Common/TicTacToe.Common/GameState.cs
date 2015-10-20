using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Common
{
    [Serializable()]
    public class GameState
    {
        public Token[] Board { get; set; }
        public int? LastMove { get; set; }
        public Token? LastToken { get; set; }
        
        public GameState()
        {
            Board = new Token[] { Token.Blank, Token.Blank, Token.Blank,
                                  Token.Blank, Token.Blank, Token.Blank,
                                  Token.Blank, Token.Blank, Token.Blank };
        }

        public GameState(GameState oldState)
        {
            Board = new Token[9];
            oldState.Board.CopyTo(Board,0);
            LastMove = oldState.LastMove;
            LastToken = oldState.LastToken;
        }

        public GameState(Token[] board)
        {
            Board = board;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(GameState))
            {
                return this.GetHashCode() == ((GameState)obj).GetHashCode();
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            if (Board.Length != 9)
            {
                return "null";
            }
            else
            {
                string boardString = "";

                for (int i = 0; i < 9; i++)
                {
                    if (Board[i] == Token.Blank)
                    {
                        boardString += "-";
                    }
                    else
                    {
                        boardString += Board[i];
                    }
                }
                
                return boardString;
            }
        }

        public override int GetHashCode()
        {
            int hashVal = 0;
            int[] hashArr = new int[9];

            for (int i = 0; i < Board.Length; i++)
            {
                hashVal += ((int)Board[i] + 2) * getIntRank(i);
            }
            
            return hashVal;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        int getIntRank(int rank)
        {
            int multiplier = 1;
            for (int k = 0; k < rank; k++)
                multiplier *= 10;
            
            return multiplier;
        }
    }
}
