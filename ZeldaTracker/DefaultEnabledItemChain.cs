using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaTracker
{
    public class DefaultEnabledItemChain : ItemChain
    {
        public DefaultEnabledItemChain(JsonItemChain chain)
            :base(chain)
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
