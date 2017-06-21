using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaTracker
{
    public class CountableItemChain : ItemChain
    {
        public CountableItemChain(string chainName, string chainType, List<ItemIcon> icons, bool startEnabled = false, bool loopable = false, bool countable = false, int maxCount = 0) 
            : base(chainName, chainType, icons, startEnabled, loopable, countable, maxCount)
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
