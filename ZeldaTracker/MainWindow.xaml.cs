using GrayscaleEffect;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

        public MainWindow()
        {
            LoadItems();

            InitializeComponent();

            DataContext = this;
        }

        private void MouseButtonUp(object sender, MouseButtonEventArgs e)
        {
            //e.ChangedButton;
            //((Image)sender).Name;

            if (sender.GetType() == typeof(Image))
            {
                var img = sender as Image;

                if (e.ChangedButton == MouseButton.Left)
                {
                    ((ItemChain)img.DataContext).NextInChain();
                }
                else
                {
                    ((ItemChain)img.DataContext).PreviousInChain();
                }
            }
        }

        private void LoadItems()
        {
            this.itemChains.Add(new ItemChain("Armos", @"images\Armos.png"));
            this.itemChains.Add(new ItemChain("Lanmola", @"images\Lanmola.png"));
            this.itemChains.Add(new ItemChain("Moldorm", @"images\Moldorm.png"));
            this.itemChains.Add(new ItemChain("Agahnim", @"images\agahnim.png"));

            this.itemChains.Add(new ItemChain("Tunic", new[] { @"images\greentunic.png", @"images\bluetunic.png", @"images\redtunic.png" }, true));

            this.itemChains.Add(new ItemChain("Blue Boomerang", @"images\blueboomerang.png"));
            this.itemChains.Add(new ItemChain("Magic Boomerang", @"images\magicboomerang.png"));

            this.itemChains.Add(new ItemChain("Bow & Arrows", new string[] { @"images\bow.png", @"images\bowarrow.png", @"images\bowsilverarrow.png" }));

            this.itemChains.Add(new ItemChain("Bug Net", @"images\bugnet.png"));

            this.itemChains.Add(new ItemChain("Empty Bottle", @"images\emptybottle.png"));
            this.itemChains.Add(new ItemChain("Bee Bottle", @"images\beebottle.png"));
            this.itemChains.Add(new ItemChain("Red Medicine", @"images\redmedicine.png"));
            this.itemChains.Add(new ItemChain("Green Potion", @"images\greenpotion.png"));
            this.itemChains.Add(new ItemChain("Blue Potion", @"images\bluepotion.png"));
            this.itemChains.Add(new ItemChain("Farie in Bottle", @"images\fariebottle.png"));

            this.itemChains.Add(new ItemChain("Bottles", new string[] { @"images\emptybottle.png", @"images\onebottle.png", @"images\twobottles.png", @"images\threebottles.png", @"images\fourbottles.png" }, true));

            this.itemChains.Add(new ItemChain("Green Pendant", @"images\greenpendant.png"));
            this.itemChains.Add(new ItemChain("Blue Pendant", @"images\bluependant.png"));
            this.itemChains.Add(new ItemChain("Red Pendant", @"images\redpendant.png"));

            this.itemChains.Add(new ItemChain("Bomb", @"images\bomb.png"));

            this.itemChains.Add(new ItemChain("Bombos", @"images\bombos.png"));
            this.itemChains.Add(new ItemChain("Ether", @"images\ether.png"));
            this.itemChains.Add(new ItemChain("Quake", @"images\quake.png"));

            this.itemChains.Add(new ItemChain("Book", @"images\book.png"));

            this.itemChains.Add(new ItemChain("Boots", @"images\boots.png"));

            this.itemChains.Add(new ItemChain("Cane of Byrna", @"images\byrna.png"));
            this.itemChains.Add(new ItemChain("Cane of Somaria", @"images\somaria.png"));

            this.itemChains.Add(new ItemChain("Chest", new string[] { @"images\closedchest.png", @"images\openedchest.png" }, true));

            this.itemChains.Add(new ItemChain("Crystal", @"images\crystal.png"));
            this.itemChains.Add(new ItemChain("Crystal 1", @"images\crystal1.png"));
            this.itemChains.Add(new ItemChain("Crystal 2", @"images\crystal2.png"));
            this.itemChains.Add(new ItemChain("Crystal 3", @"images\crystal3.png"));
            this.itemChains.Add(new ItemChain("Crystal 4", @"images\crystal4.png"));
            this.itemChains.Add(new ItemChain("Crystal 5", @"images\crystal5.png"));
            this.itemChains.Add(new ItemChain("Crystal 6", @"images\crystal6.png"));
            this.itemChains.Add(new ItemChain("Crystal 7", @"images\crystal7.png"));

            this.itemChains.Add(new ItemChain("Sword", new string[] { @"images\fightersword.png", @"images\mastersword.png", @"images\temperedsword.png", @"images\goldensword.png" }));

            this.itemChains.Add(new ItemChain("Fire Rod", @"images\firerod.png"));

            this.itemChains.Add(new ItemChain("Shield", new string[] { @"images\shield.png", @"images\fireshield.png", @"images\mirrorshield.png" }));

            this.itemChains.Add(new ItemChain("Flippers", @"images\flippers.png"));

            this.itemChains.Add(new ItemChain("Flute", @"images\flute.png"));
            this.itemChains.Add(new ItemChain("Shovel", @"images\shovel.png"));

            this.itemChains.Add(new ItemChain("Shovel & Flute", new string[] { @"images\shovelandflute.png", @"images\shovelnoflute.png", @"images\flutenoshovel.png" }));

            this.itemChains.Add(new ItemChain("Magic", new string[] { @"images\halfmagic.png", @"images\quartermagic.png" }));

            this.itemChains.Add(new ItemChain("Heart Container", @"images\heartcontainer.png"));

            this.itemChains.Add(new ItemChain("Piece of Heart", @"images\pieceofheart.png"));

            this.itemChains.Add(new ItemChain("Zero Pieces of Heart", new string[] { @"images\emptyheartcontainer.png", @"images\oneheartcontainerpiece.png", @"images\twoheartcontainerpiece.png", @"images\threeheartcontainerpiece.png" }, true));

            this.itemChains.Add(new ItemChain("Hookshot", @"images\hookshot.png"));

            this.itemChains.Add(new ItemChain("Ice Rod", @"images\icerod.png"));

            this.itemChains.Add(new ItemChain("Lamp", @"images\lamp.png"));

            this.itemChains.Add(new ItemChain("Magic Cape", @"images\magiccape.png"));

            this.itemChains.Add(new ItemChain("Mushroom", @"images\mushroom.png"));
            this.itemChains.Add(new ItemChain("Magic Powder", @"images\magicpowder.png"));

            this.itemChains.Add(new ItemChain("Magic Hammer", @"images\mchammer.png"));

            this.itemChains.Add(new ItemChain("Palace of Darkness", @"images\pod.png"));
            this.itemChains.Add(new ItemChain("Swamp Palace", @"images\swamppalace.png"));
            this.itemChains.Add(new ItemChain("Skull Woods", @"images\skullwoods.png"));
            this.itemChains.Add(new ItemChain("Thieves' Town", @"images\thievestown.png"));
            this.itemChains.Add(new ItemChain("Ice Palace", @"images\icepalace.png"));
            this.itemChains.Add(new ItemChain("Misery Mire", @"images\mire.png"));
            this.itemChains.Add(new ItemChain("Turtle Rock", @"images\turtlerock.png"));

            this.itemChains.Add(new ItemChain("Mirror", @"images\mirror.png"));

            this.itemChains.Add(new ItemChain("Moon Pearl", @"images\moonpearl.png"));

            this.itemChains.Add(new ItemChain("Master Sword Pedestal", @"images\pedestal.png"));

            this.itemChains.Add(new ItemChain("Gloves", new string[] { @"images\powerglove.png", @"images\titanmitts.png" }));

        }
    }
}
