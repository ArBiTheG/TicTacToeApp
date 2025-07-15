using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using TicTacToeApp.Model;
using TicTacToeApp.Services;
using TicTacToeApp.Utils;
using TicTacToeApp.View.ViewStates;

namespace TicTacToeApp.ViewModel
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private MainService _mainService;

        private RelayCommand _newGameCommand;
        private RelayCommand _selectPositionCommand;

        private string _message;

        private ObservableCollection<ButtonState> _buttonStates;
        private readonly ButtonState ButtonCross = new ButtonState("X", 255, 64, 96);
        private readonly ButtonState ButtonZero = new ButtonState("O", 64, 96, 255);
        private readonly ButtonState ButtonEmpty = new ButtonState();

        public MainViewModel()
        {
            _mainService = new MainService();

            _buttonStates = new ObservableCollection<ButtonState>(InitGridPositions(9));

            UpdateMessage();
        }

        public string Message
        {
            get => _message;
            set {
                _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        public ObservableCollection<ButtonState> ButtonStates
        {
            get => _buttonStates;
        }

        public RelayCommand NewGameCommand 
        {
            get => _newGameCommand ?? new RelayCommand((obj) =>
            {
                ClearAllPosition();
            });
        }

        public RelayCommand SelectPositionCommand
        {
            get => _selectPositionCommand ?? new RelayCommand((obj) =>
            {
                if (obj != null)
                {
                    int id = int.Parse(obj.ToString() ?? "-1");
                    SetSignToPosition(id);
                }
            });
        }

        private ButtonState[] InitGridPositions(int value)
        {
            var motions = new ButtonState[value];
            for (int i = 0; i < value; i++)
            {
                motions[i] = ButtonEmpty;
            }
            return motions;
        }

        private void UpdateMessage()
        {
            var getStatus = _mainService.CurrentGameStatus;
            switch (getStatus)
            {
                case GameStatus.WinNobody:
                    Message = "Ничья";
                    break;
                case GameStatus.WinCross:
                    Message = "Крестик победил";
                    break;
                case GameStatus.WinZero:
                    Message = "Нолик победил";
                    break;
                case GameStatus.WalkCross:
                    Message = "Сейчас ходит Крестик";
                    break;
                case GameStatus.WalkZero:
                    Message = "Сейчас ходит Нолик";
                    break;
            }
        }

        private void SetSignToPosition(int id)
        {
            if (id >= 0 && id < _buttonStates.Count)
            {
                int x = id % GameGrid.SizeX;
                int y = id / GameGrid.SizeY;

                var sign = _mainService.SetSign(x, y);

                switch (sign)
                {
                    case GameSignType.Cross:
                        ButtonStates[id] = ButtonCross;
                        break;
                    case GameSignType.Zero:
                        ButtonStates[id] = ButtonZero;
                        break;
                }

                UpdateMessage();
            }
        }

        private void ClearAllPosition()
        {
            for (int id = 0; id < _buttonStates.Count; id++)
            {
                _buttonStates[id] = ButtonEmpty;
            }
            _mainService.ResetGame();

            UpdateMessage();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
