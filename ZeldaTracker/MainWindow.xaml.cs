using GrayscaleEffect;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ZeldaTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public List<BitmapImage> iconImages { get; set; } = new List<BitmapImage>();
        //public List<double> _grayscaleEffect = new List<double>();
        public List<double> grayscaleEffect { get; set; } = new List<double>();
        //{
        //    get
        //    {
        //        return _grayscaleEffect;
        //    }
        //    set
        //    {
        //        _grayscaleEffect = value;
        //        RaisePropertyChanged("grayscaleEffect");
        //    }
        //}
        //public static readonly DependencyProperty grayscaleEffectProperty = DependencyProperty.Register("grayscaleEffect", typeof(List<double>), typeof(MainWindow));

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public MainWindow()
        {
            this.iconImages.Add(new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images", "0000.png"))));
            this.iconImages.Add(new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images", "0001.png"))));
            this.iconImages.Add(new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images", "0002.png"))));
            this.iconImages.Add(new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images", "0003.png"))));
            this.iconImages.Add(new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images", "0004.png"))));
            this.iconImages.Add(new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images", "0005.png"))));
            this.iconImages.Add(new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images", "0006.png"))));

            this.iconImages.Add(new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images", "0007.png"))));
            this.iconImages.Add(new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images", "0008.png"))));
            this.iconImages.Add(new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images", "0009.png"))));
            this.iconImages.Add(new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images", "0010.png"))));
            this.iconImages.Add(new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images", "0011.png"))));
            this.iconImages.Add(new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images", "0012.png"))));
            this.iconImages.Add(new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images", "0013.png"))));

            this.iconImages.Add(new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images", "0014.png"))));
            this.iconImages.Add(new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images", "0015.png"))));
            this.iconImages.Add(new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images", "0016.png"))));
            this.iconImages.Add(new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images", "0017.png"))));
            this.iconImages.Add(new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images", "0018.png"))));
            this.iconImages.Add(new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images", "0019.png"))));
            this.iconImages.Add(new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images", "0020.png"))));

            this.iconImages.Add(new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images", "0021.png"))));
            this.iconImages.Add(new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images", "0022.png"))));
            this.iconImages.Add(new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images", "0023.png"))));
            this.iconImages.Add(new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images", "0024.png"))));
            this.iconImages.Add(new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images", "0025.png"))));
            this.iconImages.Add(new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images", "0026.png"))));
            this.iconImages.Add(new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images", "0027.png"))));

            this.iconImages.Add(new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images", "0028.png"))));
            this.iconImages.Add(new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images", "0029.png"))));
            this.iconImages.Add(new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images", "0030.png"))));
            this.iconImages.Add(new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images", "0031.png"))));
            this.iconImages.Add(new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images", "0032.png"))));
            this.iconImages.Add(new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images", "0033.png"))));
            this.iconImages.Add(new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images", "0034.png"))));

            this.iconImages.Add(new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images", "0035.png"))));
            this.iconImages.Add(new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images", "0036.png"))));
            this.iconImages.Add(new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images", "0037.png"))));
            this.iconImages.Add(new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images", "0038.png"))));
            this.iconImages.Add(new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images", "0039.png"))));
            this.iconImages.Add(new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images", "0040.png"))));
            this.iconImages.Add(new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "images", "0041.png"))));

            //_grayscaleEffect = new List<double>();
            for(int i=0; i<42; i++)
            {
                grayscaleEffect.Add(0.0);
            }

            InitializeComponent();

            DataContext = this;
        }

        private void MouseButtonUp(object sender, MouseButtonEventArgs e)
        {
            //e.ChangedButton;
            //((Image)sender).Name;

            if (sender.GetType() == typeof(Image))
            {
                var img = sender as Image;
                var nameArray = img.Name.ToCharArray();

                // y * 7 + x

                int x = (int)Char.GetNumericValue(nameArray[nameArray.Length - 1]);
                int y = (int)Char.GetNumericValue(nameArray[nameArray.Length - 2]);
                int index = y * 7 + x;
                grayscaleEffect[index] = 1.0 - grayscaleEffect[index];
                RaisePropertyChanged("grayscaleEffect");
            }
        }

    }
}
