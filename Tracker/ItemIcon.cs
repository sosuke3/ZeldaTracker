using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Tracker
{
    public class ItemIcon
    {
        public string ImagePath { get; set; }
        public string Name { get; set; }

        public ItemIcon(string name, string path)
        {
            this.Name = name;
            this.ImagePath = System.IO.Path.Combine(Environment.CurrentDirectory, path);
        }
    }
}
