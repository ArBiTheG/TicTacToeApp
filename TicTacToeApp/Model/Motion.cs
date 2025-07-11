using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using TColor = System.Windows.Media.Color;

namespace TicTacToeApp.Model
{
    internal class Motion
    {
        static public readonly Motion Empty = new();
        static public readonly Motion X = new("X", 255, 0, 0);
        static public readonly Motion O = new("O", 0, 0, 255);

        public string Sign { get; }
        public SolidColorBrush Color { get; }

        private Motion(string sign = "", byte red = 0, byte green = 0, byte blue = 0) 
        {
            Sign = sign;
            Color = new SolidColorBrush(TColor.FromRgb(red, green, blue));
        }
    }
}
