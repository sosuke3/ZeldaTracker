﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaTracker
{
    public class LoopableItemChain : ItemChain
    {
        public LoopableItemChain(JsonItemChain chain) 
            : base(chain)
        {
            SetSetState();
        }

        protected override bool CanGoNextState()
        {
            return true;
        }

        protected override bool CanGoPreviousState()
        {
            return true;
        }

        protected override void GoNextState()
        {
            _currentIndex++;
            if (_currentIndex >= _itemChain.Count)
            {
                _currentIndex = 0;
            }
        }

        protected override void GoPreviousState()
        {
            _currentIndex--;
            if(_currentIndex < 0)
            {
                _currentIndex = _itemChain.Count - 1;
            }
        }

        protected override bool CanSetUnsetState()
        {
            return false;
        }

        public override void ResetChain()
        {
            _currentIndex = 0;
            NotifyIconChanged();
        }
    }
}
