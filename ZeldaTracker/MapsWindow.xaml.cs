using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace ZeldaTracker
{
    /// <summary>
    /// Interaction logic for MapsWindow.xaml
    /// </summary>
    public partial class MapsWindow : Window
    {
        public MapsWindow()
        {
            InitializeComponent();

            this.LightWorldMap.Source = new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, @"images/lightworld.png")));
            this.DarkWorldMap.Source = new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, @"images/darkworld.png")));
            this.Loaded += MapsWindow_Loaded;

        }

        private void MapsWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.HideMinimizeAndMaximizeButtons();
        }
    }
}
