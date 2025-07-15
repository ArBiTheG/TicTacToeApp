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
        private GameSignType _currentGameSign;
        private GameGrid _gameGrid;
        public MainService()
        {
            _currentGameSign = GameSignType.Cross;
            _gameGrid = new GameGrid();
        }

        public GameSignType CurrentGameSign => _currentGameSign;

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
                    GameSignType settedSign = _currentGameSign;
                    if (settedSign == GameSignType.None)
                        settedSign = GameSignType.Cross;

                    _gameGrid[x,y] = settedSign;

                    // Смена игрового знака на противоположный
                    if (_currentGameSign == GameSignType.Cross)
                        _currentGameSign = GameSignType.Zero;
                    else
                        _currentGameSign = GameSignType.Cross;

                    return settedSign;
                }
            }
            return GameSignType.None;
        }

        public void ResetGame()
        {
            _currentGameSign = GameSignType.Cross;
            _gameGrid = new GameGrid();
        }
    }
}
