using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaTracker
{
    public class DefaultEnabledItemChain : ItemChain
    {
        public DefaultEnabledItemChain(string chainName, string chainType, List<ItemIcon> icons, bool startEnabled = false, bool loopable = false, bool countable = false)
            :base(chainName, chainType, icons, startEnabled, loopable, countable)
        {
            SetSetState();
        }

        protected override bool CanSetUnsetState()
        {
            // default enabled can never be set to unset state
            return false;
        }

        protected override void SetUnsetState()
        {
            // cannot be set to unset state
            // base.SetUnsetState();
        }
    }
}
