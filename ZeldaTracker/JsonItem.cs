using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaTracker
{
    public class JsonItemChain
    {
        public string ItemChainName { get; set; }
        public string ItemChainType { get; set; }
        public List<JsonItem> ItemChain { get; set; }
        public bool DefaultEnabled { get; set; }
        public bool Loopable { get; set; }
        public bool Countable { get; set; }
    }
    public class JsonItem
    {
        public string ItemName { get; set; }
        public string IconPath { get; set; }
    }
}
