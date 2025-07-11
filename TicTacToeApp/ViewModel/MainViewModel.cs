using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TicTacToeApp.Services;

namespace TicTacToeApp.ViewModel
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private MainService _mainService;

        public MainViewModel()
        {
            _mainService = new MainService();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
