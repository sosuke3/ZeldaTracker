using GrayscaleEffect;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ZeldaTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<InventoryItem> items { get; set; } = new List<InventoryItem>();
        public List<ItemChain> itemChains { get; set; } = new List<ItemChain>();
        public Configuration Config { get; set; } = new Configuration();

        public MainWindow()
        {
            LoadItems();
            LoadConfig();

            InitializeComponent();

            this.Loaded += Window1_Loaded;

            DataContext = this;

            MapsWindow maps = new MapsWindow();
            maps.DataContext = this;
            maps.Show();
        }

        #region Win32 API Stuff
        // Define the Win32 API methods we are going to use
        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("user32.dll")]
        private static extern bool InsertMenu(IntPtr hMenu, Int32 wPosition, Int32 wFlags, Int32 wIDNewItem, string lpNewItem);

        [DllImport("User32")]
        private static extern int GetMenuItemCount(IntPtr hWnd);

        [DllImport("User32")]
        private static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);

        /// Define our Constants we will use
        public const Int32 WM_SYSCOMMAND = 0x112;
        public const Int32 MF_SEPARATOR = 0x800;
        public const Int32 MF_BYPOSITION = 0x400;
        public const Int32 MF_STRING = 0x0;

        #endregion

        #region Title Bar Context Menu Stuff
        // The constants we'll use to identify our custom system menu items
        public const Int32 _ResetMenuID = 1000;
        public const Int32 _ConfigMenuID = 1001;

        /// <summary>
        /// This is the Win32 Interop Handle for this Window
        /// </summary>
        public IntPtr Handle
        {
            get
            {
                return new WindowInteropHelper(this).Handle;
            }
        }

        private void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            /// Get the Handle for the Forms System Menu
            IntPtr systemMenuHandle = GetSystemMenu(this.Handle, false);

            int num_menu_items = GetMenuItemCount(systemMenuHandle);
            RemoveMenu(systemMenuHandle, 4, MF_BYPOSITION); // maximize
            RemoveMenu(systemMenuHandle, 3, MF_BYPOSITION); // minimize
            RemoveMenu(systemMenuHandle, 0, MF_BYPOSITION); // restore

            /// Create our new System Menu items just before the Close menu item
            InsertMenu(systemMenuHandle, 5, MF_BYPOSITION | MF_SEPARATOR, 0, string.Empty); // <-- Add a menu seperator
            InsertMenu(systemMenuHandle, 6, MF_BYPOSITION, _ResetMenuID, "Reset Tracker");
            InsertMenu(systemMenuHandle, 7, MF_BYPOSITION, _ConfigMenuID, "Config");

            // Attach our WndProc handler to this Window
            HwndSource source = HwndSource.FromHwnd(this.Handle);
            source.AddHook(new HwndSourceHook(WndProc));
        }

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            // Check if a System Command has been executed
            if (msg == WM_SYSCOMMAND)
            {
                // Execute the appropriate code for the System Menu item that was clicked
                switch (wParam.ToInt32())
                {
                    case _ResetMenuID:
                        ResetItems();
                        handled = true;
                        break;
                    case _ConfigMenuID:
                        ConfigDialog dialog = new ConfigDialog(this.Config);
                        if(dialog.ShowDialog() == true)
                        {
                            this.Config = dialog.Config;
                            ReorderItems();
                            // save config?
                        }
                        //MessageBox.Show("\"About\" was clicked");
                        handled = true;
                        break;
                }
            }

            return IntPtr.Zero;
        }
        #endregion

        private void MouseButtonUp(object sender, MouseButtonEventArgs e)
        {
            //e.ChangedButton;
            //((Image)sender).Name;

            if (sender.GetType() == typeof(Image))
            {
                var img = sender as Image;
                var itemChain = (ItemChain)img.DataContext;

                switch (e.ChangedButton)
                {
                    case MouseButton.Left:
                        itemChain.NextInChain();
                        break;
                    case MouseButton.Right:
                        itemChain.PreviousInChain();
                        break;

                    // not sure if I want this
                    //case MouseButton.Middle:
                    //    itemChain.ResetChain();
                    //    break;
                }
            }
        }

        private void LoadItems()
        {
            List<JsonItemChain> chains = JsonConvert.DeserializeObject<List<JsonItemChain>>(File.ReadAllText(@"items.json"));

            chains.ForEach((c) => this.itemChains.Add(ItemChainFactory.BuildItemChain(c)));
        }

        private void LoadConfig()
        {
            try
            {
                this.Config = JsonConvert.DeserializeObject<Configuration>(File.ReadAllText(@"config.json"));
            }
            catch(Exception ex)
            {
                MessageBox.Show("Invalid configuration file. Loading defaults");
                this.Config = MakeDefaultConfiguration();
            }

            MoveAndResizeWindow();
            ReorderItems();
        }

        private void ReorderItems()
        {
            try
            {
                this.itemChains = this.itemChains.OrderBySequence<ItemChain, string>(this.Config.DisplayOrder, t => t.ItemChainName).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in configuration. " + ex.Message, "Config Error");
            }

        }

        private void MoveAndResizeWindow()
        {
            this.Height = this.Config.WindowHeight;
            this.Width = this.Config.WindowWidth;
            if(this.Config.WindowX > -1)
            {

            }
            if(this.Config.WindowY > -1)
            {

            }
        }

        private Configuration MakeDefaultConfiguration()
        {
            var ret = new Configuration();
            ret.DisplayOrder = this.itemChains.Select(i => i.ItemChainName).ToList();
            ret.WindowHeight = 380;
            ret.WindowWidth = 244;
            ret.WindowX = -1;
            ret.WindowY = -1;
            return ret;
        }

        private void ResetItems()
        {            
            foreach(var i in itemChains)
            {
                i.ResetChain();
            }
        }
    }
}
