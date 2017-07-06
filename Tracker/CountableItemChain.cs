using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker
{
    public class CountableItemChain : ItemChain
    {
        public CountableItemChain(JsonItemChain chain) 
            : base(chain)
        {
            Count = 0;

            SetSetState();
        }

        protected override bool CanGoNextState()
        {
            return Count < _maxCount;
        }

        protected override bool CanGoPreviousState()
        {
            return Count > 0;
        }

        protected override bool CanSetUnsetState()
        {
            return false;
        }

        protected override void GoNextState()
        {
            Count++;
            RaisePropertyChanged("Count");
        }

        protected override void GoPreviousState()
        {
            Count--;
            RaisePropertyChanged("Count");
        }

        public override void ResetChain()
        {
            Count = 0;
            RaisePropertyChanged("Count");
        }
    }
}
