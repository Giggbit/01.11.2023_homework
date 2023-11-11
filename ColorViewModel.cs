using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace _01._11._2023_Команды.MVVM
{
    internal class ColorViewModel : ViewModelBase
    {
        public ObservableCollection<Color> ColorItem { get; set; } = new ObservableCollection<Color>();

        private static readonly DependencyProperty AlphaProperty = DependencyProperty.Register("Alpha", typeof(double), typeof(ColorViewModel), new PropertyMetadata(0.0, OnColorPropertyChanged));
        private static readonly DependencyProperty RedProperty = DependencyProperty.Register("Red", typeof(int), typeof(ColorViewModel), new PropertyMetadata(0, OnColorPropertyChanged));
        private static readonly DependencyProperty GreenProperty = DependencyProperty.Register("Green", typeof(int), typeof(ColorViewModel), new PropertyMetadata(0, OnColorPropertyChanged));
        private static readonly DependencyProperty BlueProperty = DependencyProperty.Register("Blue", typeof(int), typeof(ColorViewModel), new PropertyMetadata(0, OnColorPropertyChanged));
        public static readonly DependencyProperty RectangleColorProperty = DependencyProperty.Register("RectangleColor", typeof(Color), typeof(ColorViewModel), new PropertyMetadata(Colors.Black));

        public double Alpha { 
            get { return (double)GetValue(AlphaProperty); }
            set { SetValue(AlphaProperty, value); OnPropertyChanged(nameof(Alpha)); }
        }

        public int Red { 
            get { return (int)GetValue(RedProperty); }
            set { SetValue(RedProperty, value); OnPropertyChanged(nameof(Red)); }
        }

        public int Green { 
            get { return (int)GetValue(GreenProperty); }
            set { SetValue(GreenProperty, value); OnPropertyChanged(nameof(Green)); }     
        }

        public int Blue {
            get { return (int)GetValue(BlueProperty); }
            set { SetValue(BlueProperty, value); OnPropertyChanged(nameof(Blue)); }
        }

        public Color RectangleColor {
            get { return (Color)GetValue(RectangleColorProperty); }
            set { SetValue(RectangleColorProperty, value); OnPropertyChanged(nameof(RectangleColor)); }
        }


        private static void OnColorPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            var viewModel = (ColorViewModel)d;
            viewModel.UpdateRectangleColor();
        }
        private void UpdateRectangleColor() {
            RectangleColor = Color.FromArgb((byte)Alpha, (byte)Red, (byte)Green, (byte)Blue);
        }


        RelayCommand _addCommand;
        public ICommand AddCommand { 
            get { 
                if (_addCommand == null) {
                    _addCommand = new RelayCommand(AddColor, CanAddColor);
                } 
                return _addCommand;
            }
        }
        private void AddColor(object obj) {
            ColorItem.Add(Color.FromArgb((byte)Alpha, (byte)Red, (byte)Green, (byte)Blue));
        }
        private bool CanAddColor(object obj) {
            return true;
        }

 
    }
}
