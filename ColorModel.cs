using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace _01._11._2023_Команды.MVVM
{
    public class ColorModel {

        public double _alpha {  get; set; }
        public int _red { get; set; }
        public int _green { get; set; }
        public int _blue { get; set; }

        public ColorModel(double alpha, int red, int green, int blue) { 
            _alpha = alpha;
            _red = red;
            _green = green;
            _blue = blue;
            Color.FromArgb((byte)_alpha, (byte)_red, (byte)_green, (byte)_blue);
        }

        public Color Color {
            get { return Color.FromArgb((byte)_alpha, (byte)_red, (byte)_green, (byte)_blue); }
        }

    }
}
