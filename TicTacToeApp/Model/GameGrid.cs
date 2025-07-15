using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeApp.Model
{
    internal class GameGrid
    {
        GameSignType[,] _motionGrid;

        public GameGrid() 
        {
            _motionGrid = new GameSignType[SizeX, SizeY];
        }

        public static readonly int SizeX = 3;
        public static readonly int SizeY = 3;

        public GameSignType this[int x, int y]
        {
            get => _motionGrid[x, y];
            set => _motionGrid[x, y] = value; 
        }
    }
}
