using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaTracker
{
    public static class ItemChainFactory
    {
        public static ItemChain BuildItemChain(JsonItemChain chain)
        {
            if (chain.DefaultEnabled)
            {
                return new DefaultEnabledItemChain(chain);
            }
            if (chain.Countable)
            {
                return new CountableItemChain(chain);
            }
            if (chain.Loopable)
            {
                return new LoopableItemChain(chain);
            }
            return new ItemChain(chain);
        }
    }
}
