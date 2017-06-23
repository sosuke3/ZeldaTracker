using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ZeldaTracker
{
    public class InventoryItem
    {
        public BitmapImage Icon { get; set; }
        public string ItemName { get; set; }

        public InventoryItem(string name, string path)
        {
            this.ItemName = name;
            try
            {
                this.Icon = new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, path)));
            }
            catch(Exception ex)
            {
                this.Icon = MissingBitmapImage.GenerateMissingImage();

                // TODO: log it or something
            }
        }
    }
}
