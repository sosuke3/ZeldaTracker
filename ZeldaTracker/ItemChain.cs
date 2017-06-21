﻿using Newtonsoft.Json;
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
        protected const double ItemUnsetValue = 0.0;
        protected const double ItemSetValue = 1.0;

        protected int _currentIndex = 0;
        protected List<InventoryItem> _itemChain = new List<InventoryItem>();
        protected bool _isUnset = true;
        protected bool _defaultEnabled = false;
        protected bool _loopable = false;
        protected bool _countable = false;
        protected int _maxCount = 0;

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
        public int Count { get; set; } = 0;
        public bool Countable { get { return _countable; } }
        public InventoryItem CurrentItem { get { return _itemChain[_currentIndex]; } }

        public ItemChain(string chainName, string chainType, List<ItemIcon> icons, bool startEnabled = false, bool loopable = false, bool countable = false, int maxCount = 0)
        {
            this.ItemChainName = chainName;
            this.ItemChainType = chainType;
            this._defaultEnabled = startEnabled;
            this._loopable = loopable;
            this._countable = countable;
            this._maxCount = maxCount;

            foreach (var i in icons)
            {
                this._itemChain.Add(new InventoryItem(i.Name, i.ImagePath));
            }
        }

        public void NextInChain()
        {
            if (CanGoNextState())
            {
                GoNextState();
                NotifyIconChanged();
            }
            UpdateSetState();
        }

        protected virtual bool CanGoNextState()
        {
            return _currentIndex + 1 < _itemChain.Count && _isUnset == false;
        }

        protected virtual void GoNextState()
        {
            _currentIndex++;
        }

        protected virtual void NotifyIconChanged()
        {
            RaisePropertyChanged("Icon");
        }

        protected virtual void NotifyStateChanged()
        {
            RaisePropertyChanged("GrayscaleEffect");
        }

        protected virtual void UpdateSetState()
        {
            SetSetState();
            NotifyStateChanged();
        }

        public void PreviousInChain()
        {
            UpdateUnsetState();

            if (CanGoPreviousState())
            {
                GoPreviousState();
                NotifyIconChanged();
            }
        }

        protected virtual bool CanGoPreviousState()
        {
            return _currentIndex > 0;
        }

        protected virtual void GoPreviousState()
        {
            _currentIndex--;
        }

        protected virtual void UpdateUnsetState()
        {
            if (CanSetUnsetState())
            {
                SetUnsetState();
                NotifyStateChanged();
            }
        }

        protected virtual bool CanSetUnsetState()
        {
            return _currentIndex == 0 && _isUnset == false;
        }

        protected virtual void SetSetState()
        {
            _isUnset = false;
            GrayscaleEffect = ItemSetValue;
        }

        protected virtual void SetUnsetState()
        {
            _isUnset = true;
            GrayscaleEffect = ItemUnsetValue;
        }

        public virtual void ResetChain()
        {
            SetUnsetState();
            NotifyStateChanged();
            _currentIndex = 0;
            RaisePropertyChanged("Icon");
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
