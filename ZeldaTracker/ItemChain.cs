using Newtonsoft.Json;
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
        private const double ItemUnsetValue = 0.0;
        private const double ItemSetValue = 1.0;

        private int _currentIndex = 0;
        private List<InventoryItem> _itemChain = new List<InventoryItem>();
        private bool _isUnset = true;
        private bool _defaultEnabled = false;
        private bool _loopable = false;
        private bool _countable = false;

        public BitmapImage Icon
        {
            get
            {
                return _itemChain[_currentIndex].Icon;
            }
        }

        public double GrayscaleEffect { get; set; } = ItemUnsetValue;
        public string ItemChainName { get; set; }
        public string ItemChainType { get; set; }

        public ItemChain(string chainName, string chainType, List<ItemIcon> icons, bool startEnabled = false, bool loopable = false, bool countable = false)
        {
            this.ItemChainName = chainName;
            this.ItemChainType = chainType;
            this._defaultEnabled = startEnabled;
            this._loopable = loopable;
            this._countable = countable;

            if(startEnabled)
            {
                _isUnset = false;
                GrayscaleEffect = ItemSetValue;
            }
            foreach(var i in icons)
            {
                this._itemChain.Add(new InventoryItem(i.Name, i.ImagePath));
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
            GrayscaleEffect = ItemSetValue;
            RaisePropertyChanged("GrayscaleEffect");
        }

        public void PreviousInChain()
        {
            if (_currentIndex == 0 && _isUnset == false && _defaultEnabled != true)
            {
                _isUnset = true;
                GrayscaleEffect = ItemUnsetValue;
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
            if (_defaultEnabled != true)
            {
                _isUnset = true;
                GrayscaleEffect = ItemUnsetValue;
                RaisePropertyChanged("GrayscaleEffect");
            }
            _currentIndex = 0;
            RaisePropertyChanged("Icon");
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
