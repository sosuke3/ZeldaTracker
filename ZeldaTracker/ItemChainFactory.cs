using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaTracker
{
    public static class ItemChainFactory
    {
        public static ItemChain BuildItemChain(string chainName, string chainType, List<ItemIcon> icons, bool startEnabled = false, bool loopable = false, bool countable = false, int maxCount = 0)
        {
            if (startEnabled)
            {
                return new DefaultEnabledItemChain(chainName, chainType, icons, startEnabled, loopable, countable);
            }
            if (countable)
            {
                return new CountableItemChain(chainName, chainType, icons, startEnabled, loopable, countable, maxCount);
            }
            if (loopable)
            {
                return new LoopableItemChain(chainName, chainType, icons, startEnabled, loopable, countable);
            }
            return new ItemChain(chainName, chainType, icons, startEnabled, loopable, countable, maxCount);
        }
    }
}
