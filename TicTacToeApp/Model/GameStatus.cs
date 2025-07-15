using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeApp.Model
{
    internal enum GameStatus: byte
    {
        Unknown = 0,
        WalkCross,
        WalkZero,
        WinCross,
        WinZero,
        WinNobody,
    }
}
