using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Common
{
    public interface ITicTacToeAgent
    {
        Token PlayerToken { get; }
        void Play(Game simulation);
        void GameOver(Token winner);
    }
}
