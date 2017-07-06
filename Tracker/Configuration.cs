using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker
{
    public class Configuration : ICloneable
    {
        public List<string> DisplayOrder { get; set; } = new List<string>();
        public int WindowWidth { get; set; }
        public int WindowHeight { get; set; }
        public int WindowX { get; set; }
        public int WindowY { get; set; }
        public bool ShowMapWindowsOnStartup { get; set; }

        public object Clone()
        {
            var copy = new Configuration();
            copy.DisplayOrder = this.DisplayOrder.ToList();
            copy.WindowHeight = this.WindowHeight;
            copy.WindowWidth = this.WindowWidth;
            copy.WindowX = this.WindowX;
            copy.WindowY = this.WindowY;
            copy.ShowMapWindowsOnStartup = this.ShowMapWindowsOnStartup;
            return copy;
        }
    }
}
