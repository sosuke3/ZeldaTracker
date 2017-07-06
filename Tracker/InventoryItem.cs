using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Tracker
{
    public class InventoryItem
    {
        public BitmapImage Icon { get; set; }
        public string ItemName { get; set; }

        private string _path { get; set; }

        public InventoryItem(string name, string path)
        {
            this.ItemName = name;
            this._path = path;
        }

        public void LoadImage()
        {
            try
            {
                this.Icon = new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, _path)));
            }
            catch (Exception ex)
            {
                this.Icon = MissingBitmapImage.GenerateMissingImage();

                // TODO: log it or something
                var msg = "Image '" + _path + "' could not be loaded. Loaded missing image icon instead. Fix your 'items.json'.";
                //MessageBox.Show(msg); // eww but what's a boy to do?
                throw new ImageNotFoundException(msg);
            }
        }
    }

    public class ImageNotFoundException : Exception
    {
        public ImageNotFoundException(string message) : base(message)
        {

        }
    }
}
