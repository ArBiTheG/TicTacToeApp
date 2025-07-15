using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeApp.Model
{
    internal class GameGridBuilder
    {
        private GameGrid _grid;
        private GameGridBuilder()
        {
            _grid = new GameGrid();
        }

        public static GameGridBuilder Create()
        {
            return new GameGridBuilder();
        }

        public GameGridBuilder SetRow(int row, GameSignType gameSign)
        {
            for(int i = 0; i < GameGrid.SizeY; i++)
            {
                _grid[row, i] = gameSign;
            }
            return this;
        }

        public GameGridBuilder SetColumn(int column, GameSignType gameSign)
        {
            for (int i = 0; i < GameGrid.SizeX; i++)
            {
                _grid[i, column] = gameSign;
            }
            return this;
        }
        public GameGridBuilder SetDiagonal(bool reverse, GameSignType gameSign)
        {
            int column = reverse ? GameGrid.SizeY - 1: 0;
            for (int i = 0; i < GameGrid.SizeX; i++)
            {
                _grid[i, column] = gameSign;

                if (reverse)
                    column--;
                else
                    column++;
            }
            return this;
        }

        public GameGrid Build()
        {
            return _grid;
        }

    }
}
