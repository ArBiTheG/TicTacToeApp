using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TicTacToeApp.Model;

namespace TicTacToeApp.Services
{
    internal class MainService
    {
        private GameStatus _gameStatus;
        private GameGrid _gameGrid;
        private int _signCount;

        public MainService()
        {
            _gameStatus = GameStatus.WalkCross;
            _gameGrid = new GameGrid();
            _signCount = GameGrid.SizeY * GameGrid.SizeX;
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
                        _signCount--;
                    }
                    else if (_gameStatus == GameStatus.WalkZero)
                    {
                        _gameGrid[x, y] = settedSign = GameSignType.Zero;
                        _gameStatus = GameStatus.WalkCross;
                        _signCount--;
                    }

                    GameStatus winStatus = CheckWins();
                    if (winStatus != GameStatus.Unknown)
                        _gameStatus = winStatus;

                    return settedSign;
                }
            }
            return GameSignType.None;
        }

        public Dictionary<GameGrid, GameSignType> GetWinsList()
        {
            return new Dictionary<GameGrid, GameSignType>()
            {
                { GameGridBuilder.Create().SetRow(0, GameSignType.Cross).Build(), GameSignType.Cross},
                { GameGridBuilder.Create().SetRow(1, GameSignType.Cross).Build(), GameSignType.Cross},
                { GameGridBuilder.Create().SetRow(2, GameSignType.Cross).Build(), GameSignType.Cross},
                { GameGridBuilder.Create().SetRow(0, GameSignType.Zero).Build(), GameSignType.Zero},
                { GameGridBuilder.Create().SetRow(1, GameSignType.Zero).Build(), GameSignType.Zero},
                { GameGridBuilder.Create().SetRow(2, GameSignType.Zero).Build(), GameSignType.Zero},
                { GameGridBuilder.Create().SetColumn(0, GameSignType.Cross).Build(), GameSignType.Cross},
                { GameGridBuilder.Create().SetColumn(1, GameSignType.Cross).Build(), GameSignType.Cross},
                { GameGridBuilder.Create().SetColumn(2, GameSignType.Cross).Build(), GameSignType.Cross},
                { GameGridBuilder.Create().SetColumn(0, GameSignType.Zero).Build(), GameSignType.Zero},
                { GameGridBuilder.Create().SetColumn(1, GameSignType.Zero).Build(), GameSignType.Zero},
                { GameGridBuilder.Create().SetColumn(2, GameSignType.Zero).Build(), GameSignType.Zero},
                { GameGridBuilder.Create().SetDiagonal(true, GameSignType.Cross).Build(), GameSignType.Cross},
                { GameGridBuilder.Create().SetDiagonal(false, GameSignType.Cross).Build(), GameSignType.Cross},
                { GameGridBuilder.Create().SetDiagonal(true, GameSignType.Zero).Build(), GameSignType.Zero},
                { GameGridBuilder.Create().SetDiagonal(false, GameSignType.Zero).Build(), GameSignType.Zero}
            };
        }

        public GameStatus CheckWins()
        {
            if (_signCount == 0)
                return GameStatus.WinNobody;

            var winsCombinations = GetWinsList();
            foreach (var wins in winsCombinations)
            {
                int сoincidence = 0;
                for (var x = 0; x < GameGrid.SizeX; x++)
                {
                    for (var y = 0; y < GameGrid.SizeY; y++)
                    {
                        if (_gameGrid[x,y] != GameSignType.None)
                        {
                            if (_gameGrid[x, y] == wins.Key[x, y])
                            {
                                сoincidence++;
                            }
                        }
                    }
                }
                if (сoincidence == GameGrid.SizeX)
                {
                    if (wins.Value == GameSignType.Cross)
                        return GameStatus.WinCross;
                    else if (wins.Value == GameSignType.Zero)
                        return GameStatus.WinZero;
                }
            }
            return GameStatus.Unknown;
        }

        public void ResetGame()
        {
            _gameStatus = GameStatus.WalkCross;
            _gameGrid = new GameGrid();
            _signCount = GameGrid.SizeY * GameGrid.SizeX;
        }
    }
}
