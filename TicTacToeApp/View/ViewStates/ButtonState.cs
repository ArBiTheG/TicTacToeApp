using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TicTacToeApp.View.ViewStates
{
    internal class ButtonState
    {
        public string Text { get; set; }
        public SolidColorBrush Foreground { get; set; }

        public ButtonState(string text = "", byte red = 0, byte green = 0, byte blue = 0)
        {
            Text = text;
            Foreground = new SolidColorBrush(Color.FromRgb(red, green, blue));
        }
    }
}
