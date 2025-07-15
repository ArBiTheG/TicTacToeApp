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
        private readonly ButtonState ButtonCross = new ButtonState("X", 255, 0, 0);
        private readonly ButtonState ButtonZero = new ButtonState("O", 0, 0, 255);
        private readonly ButtonState ButtonEmpty = new ButtonState();

        public MainViewModel()
        {
            _mainService = new MainService();

            _buttonStates = new ObservableCollection<ButtonState>(InitGridPositions(9));
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

                var nextSign = _mainService.CurrentGameSign;
                switch (nextSign)
                {
                    case GameSignType.Cross:
                        Message = "Сейчас ходит Крестик";
                        break;
                    case GameSignType.Zero:
                        Message = "Сейчас ходит Нолик";
                        break;
                }
            }
        }

        private void ClearAllPosition()
        {
            for (int id = 0; id < _buttonStates.Count; id++)
            {
                _buttonStates[id] = ButtonEmpty;
            }
            _mainService.ResetGame();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
