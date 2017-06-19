using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ZeldaTracker
{
    public class InventoryItem : INotifyPropertyChanged
    {
        private const double UnsetValue = 0.0;
        private const double SetValue = 1.0;

        public BitmapImage Icon { get; set; }
        public double GrayscaleEffect { get; set; } = UnsetValue;
        public string ItemName { get; set; }

        public InventoryItem(string name, string path)
        {
            this.ItemName = name;
            this.Icon = new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, path)));
        }

        public void FoundItem()
        {
            this.GrayscaleEffect = SetValue;
            RaisePropertyChanged("GrayscaleEffect");
        }

        public void ResetItem()
        {
            this.GrayscaleEffect = UnsetValue;
            RaisePropertyChanged("GrayscaleEffect");
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
