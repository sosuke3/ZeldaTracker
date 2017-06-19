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
        public BitmapImage Icon { get; set; }
        public double GrayscaleEffect { get; set; } = 0.0;
        public string ItemName { get; set; }

        public InventoryItem(string name, string path)
        {
            this.ItemName = name;
            this.Icon = new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, path)));
        }

        public void FoundItem()
        {
            this.GrayscaleEffect = 1.0;
            RaisePropertyChanged("GrayscaleEffect");
        }

        public void ResetItem()
        {
            this.GrayscaleEffect = 0.0;
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
