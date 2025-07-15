using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeApp.Model;

namespace TicTacToeApp.Services
{
    internal class MainService
    {
        private GameStatus _gameStatus;
        private GameGrid _gameGrid;
        public MainService()
        {
            _gameStatus = GameStatus.WalkCross;
            _gameGrid = new GameGrid();
        }

        public GameStatus CurrentGameStatus => _gameStatus;

        public GameSignType GetSign(int x, int y)
        {
            if (x > 0 && x < GameGrid.SizeX && y > 0 && y < GameGrid.SizeY)
            {
                return _gameGrid[x, y];
            }
            return GameSignType.None;
        }

        public GameSignType SetSign(int x, int y)
        {
            if (x >= 0 && x < GameGrid.SizeX && y >= 0 && y < GameGrid.SizeY)
            {
                if (_gameGrid[x,y]== GameSignType.None)
                {
                    GameSignType settedSign = GameSignType.None;

                    if (_gameStatus == GameStatus.WalkCross)
                    {
                        _gameGrid[x, y] = settedSign = GameSignType.Cross;
                        _gameStatus = GameStatus.WalkZero;
                    }
                    else if (_gameStatus == GameStatus.WalkZero)
                    {
                        _gameGrid[x, y] = settedSign = GameSignType.Zero;
                        _gameStatus = GameStatus.WalkCross;
                    }

                    return settedSign;
                }
            }
            return GameSignType.None;
        }

        public void ResetGame()
        {
            _gameStatus = GameStatus.WalkCross;
            _gameGrid = new GameGrid();
        }
    }
}
