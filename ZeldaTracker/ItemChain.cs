using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ZeldaTracker
{
    public class ItemChain : INotifyPropertyChanged
    {
        private const double UnsetValue = 0.0;
        private const double SetValue = 1.0;

        private int _currentIndex = 0;
        private List<InventoryItem> _itemChain = new List<InventoryItem>();
        private bool _isUnset = true;

        public BitmapImage Icon
        {
            get
            {
                return _itemChain[_currentIndex].Icon;
            }
        }

        public double GrayscaleEffect { get; set; } = UnsetValue;
        public string ItemChainName { get; set; }

        public ItemChain(string chainName, string imagePath)
            :this(chainName, new[] { imagePath } )
        {
        }

        public ItemChain(string chainName, string[] imagePaths)
        {
            this.ItemChainName = chainName;
            foreach(string s in imagePaths)
            {
                this._itemChain.Add(new InventoryItem(s, s));
            }
        }

        public void NextInChain()
        {
            if(_currentIndex + 1 < _itemChain.Count && _isUnset == false)
            {
                _currentIndex++;
                RaisePropertyChanged("Icon");
            }
            _isUnset = false;
            GrayscaleEffect = SetValue;
            RaisePropertyChanged("GrayscaleEffect");
        }

        public void PreviousInChain()
        {
            if (_currentIndex == 0 && _isUnset == false)
            {
                _isUnset = true;
                GrayscaleEffect = UnsetValue;
                RaisePropertyChanged("GrayscaleEffect");
            }
            if (_currentIndex > 0)
            {
                _currentIndex--;
            }
            RaisePropertyChanged("Icon");
        }

        public void ResetChain()
        {
            _isUnset = true;
            _currentIndex = 0;
            GrayscaleEffect = UnsetValue;
            RaisePropertyChanged("Icon");
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
