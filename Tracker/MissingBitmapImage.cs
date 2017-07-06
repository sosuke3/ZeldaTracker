using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Tracker
{
    public static class MissingBitmapImage
    {
        public static BitmapImage GenerateMissingImage()
        {
            return new BitmapImage(new Uri("pack://application:,,,/ZeldaTracker;component/missingicon.png"));
        }
    }
}
