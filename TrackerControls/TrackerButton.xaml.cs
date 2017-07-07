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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tracker;

namespace TrackerControls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class TrackerButton : UserControl
    {
        //public static readonly DependencyProperty MainImageSourceProperty = DependencyProperty.Register("MainImageSource", typeof(BitmapImage), typeof(TrackerButton));
        //public BitmapImage MainImageSource
        //{
        //    get { return (BitmapImage)GetValue(MainImageSourceProperty); }
        //    set { SetValue(MainImageSourceProperty, value); }
        //}

        //public static readonly DependencyProperty TopLeftImageSourceProperty = DependencyProperty.Register("TopLeftImageSource", typeof(BitmapImage), typeof(TrackerButton));
        //public BitmapImage TopLeftImageSource
        //{
        //    get { return (BitmapImage)GetValue(TopLeftImageSourceProperty); }
        //    set { SetValue(TopLeftImageSourceProperty, value); }
        //}

        //public static readonly DependencyProperty TopRightImageSourceProperty = DependencyProperty.Register("TopRightImageSource", typeof(BitmapImage), typeof(TrackerButton));
        //public BitmapImage TopRightImageSource
        //{
        //    get { return (BitmapImage)GetValue(TopRightImageSourceProperty); }
        //    set { SetValue(TopRightImageSourceProperty, value); }
        //}

        //public static readonly DependencyProperty BottomLeftImageSourceProperty = DependencyProperty.Register("BottomLeftImageSource", typeof(BitmapImage), typeof(TrackerButton));
        //public BitmapImage BottomLeftImageSource
        //{
        //    get { return (BitmapImage)GetValue(BottomLeftImageSourceProperty); }
        //    set { SetValue(BottomLeftImageSourceProperty, value); }
        //}

        //public static readonly DependencyProperty BottomRightImageSourceProperty = DependencyProperty.Register("BottomRightImageSource", typeof(BitmapImage), typeof(TrackerButton));
        //public BitmapImage BottomRightImageSource
        //{
        //    get { return (BitmapImage)GetValue(BottomRightImageSourceProperty); }
        //    set { SetValue(BottomRightImageSourceProperty, value); }
        //}

        //public static readonly DependencyProperty DesaturationFactorProperty = DependencyProperty.Register("DesaturationFactor", typeof(double), typeof(TrackerButton));
        //public double DesaturationFactor
        //{
        //    get { return (double)GetValue(DesaturationFactorProperty); }
        //    set { SetValue(DesaturationFactorProperty, value); }
        //}

        public TrackerButton()
        {
            InitializeComponent();
        }

        private void MainImageControl_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (sender.GetType() == typeof(Image))
            {
                var img = sender as Image;
                var itemChain = (ItemChain)img.DataContext;

                switch (e.ChangedButton)
                {
                    case MouseButton.Left:
                        itemChain.NextInChain();
                        break;
                    case MouseButton.Right:
                        itemChain.PreviousInChain();
                        break;

                        // not sure if I want this
                        //case MouseButton.Middle:
                        //    itemChain.ResetChain();
                        //    break;
                }
            }

        }
    }
}
