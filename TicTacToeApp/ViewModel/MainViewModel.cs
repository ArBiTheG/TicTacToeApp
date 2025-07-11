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

namespace TicTacToeApp.ViewModel
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private MainService _mainService;

        private RelayCommand _newGameCommand;
        private RelayCommand _selectPositionCommand;
        private ObservableCollection<Motion> _motions;

        private string _message;

        public MainViewModel()
        {
            _mainService = new MainService();

            _motions = new ObservableCollection<Motion>(InitGridPositions(9));
        }

        public string Message
        {
            get => _message;
            set {
                _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        public ObservableCollection<Motion> Motions
        {
            get => _motions;
        }

        public RelayCommand NewGameCommand 
        {
            get => _newGameCommand ?? new RelayCommand((obj) =>
            {

            });
        }

        public RelayCommand SelectPositionCommand
        {
            get => _selectPositionCommand ?? new RelayCommand((obj) =>
            {
                if (obj != null)
                {
                    int id = int.Parse(obj.ToString() ?? "-1");
                    SetXToPosition(id);
                }

            });
        }

        private Motion[] InitGridPositions(int value)
        {
            var motions = new Motion[value];
            for (int i = 0; i < value; i++)
            {
                motions[i] = Motion.Empty;
            }
            return motions;
        }

        private void SetMotionPosition(int id, Motion motion)
        {
            if (id >= 0 && id < _motions.Count)
                _motions[id] = Motion.X;
        }
        private void SetXToPosition(int id)
        {
            SetMotionPosition(id, Motion.X);
        }

        private void SetOToPosition(int id)
        {
            SetMotionPosition(id, Motion.O);
        }

        private void ClearPosition(int id)
        {
            SetMotionPosition(id, Motion.Empty);
        }

        private void ClearAllPosition()
        {
            for (int id = 0; id < _motions.Count; id++)
            {
                SetMotionPosition(id, Motion.Empty);
            }
        }



        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
