using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ZeldaTracker
{
    /// <summary>
    /// Interaction logic for ConfigDialog.xaml
    /// </summary>
    public partial class ConfigDialog : Window
    {
        protected Configuration _config { get; set; }
        public Configuration Config { get { return _config; } }

        public ConfigDialog(Configuration config)
        {
            InitializeComponent();

            _config = (Configuration)config.Clone();

            this.DataContext = _config;
        }

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            File.WriteAllText(@"config.json", JsonConvert.SerializeObject(_config));
            // TODO: save to file
        }
    }
}
