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
                    ((InventoryItem)img.DataContext).FoundItem();
                }
                else
                {
                    ((InventoryItem)img.DataContext).ResetItem();
                }
            }
        }

        private void LoadItems()
        {
            this.items.Add(new InventoryItem("Agahnim", @"images\agahnim.png"));
            this.items.Add(new InventoryItem("Armos", @"images\Armos.png"));
            this.items.Add(new InventoryItem("Bee Bottle", @"images\beebottle.png"));
            this.items.Add(new InventoryItem("Blue Boomerang", @"images\blueboomerang.png"));
            this.items.Add(new InventoryItem("Blue Pendant", @"images\bluependant.png"));
            this.items.Add(new InventoryItem("Blue Potion", @"images\bluepotion.png"));
            this.items.Add(new InventoryItem("Blue Tunic", @"images\bluetunic.png"));
            this.items.Add(new InventoryItem("Bomb", @"images\bomb.png"));
            this.items.Add(new InventoryItem("Bombos", @"images\bombos.png"));
            this.items.Add(new InventoryItem("Book", @"images\book.png"));
            this.items.Add(new InventoryItem("Boots", @"images\boots.png"));
            this.items.Add(new InventoryItem("Bow", @"images\bow.png"));
            this.items.Add(new InventoryItem("Bow & Arrows", @"images\bowarrow.png"));
            this.items.Add(new InventoryItem("Bow & Silver Arrows", @"images\bowsilverarrow.png"));
            this.items.Add(new InventoryItem("Bug Net", @"images\bugnet.png"));
            this.items.Add(new InventoryItem("Cane of Byrna", @"images\byrna.png"));
            this.items.Add(new InventoryItem("Closed Chest", @"images\closedchest.png"));
            this.items.Add(new InventoryItem("Crystal", @"images\crystal.png"));
            this.items.Add(new InventoryItem("Crystal 1", @"images\crystal1.png"));
            this.items.Add(new InventoryItem("Crystal 2", @"images\crystal2.png"));
            this.items.Add(new InventoryItem("Crystal 3", @"images\crystal3.png"));
            this.items.Add(new InventoryItem("Crystal 4", @"images\crystal4.png"));
            this.items.Add(new InventoryItem("Crystal 5", @"images\crystal5.png"));
            this.items.Add(new InventoryItem("Crystal 6", @"images\crystal6.png"));
            this.items.Add(new InventoryItem("Crystal 7", @"images\crystal7.png"));
            this.items.Add(new InventoryItem("Empty Bottle", @"images\emptybottle.png"));
            this.items.Add(new InventoryItem("Empty Heart Container", @"images\emptyheartcontainer.png"));
            this.items.Add(new InventoryItem("Ether", @"images\ether.png"));
            this.items.Add(new InventoryItem("Farie in Bottle", @"images\fariebottle.png"));
            this.items.Add(new InventoryItem("Fighter's Sword", @"images\fightersword.png"));
            this.items.Add(new InventoryItem("Fire Rod", @"images\firerod.png"));
            this.items.Add(new InventoryItem("Fire Shield", @"images\fireshield.png"));
            this.items.Add(new InventoryItem("Flippers", @"images\flippers.png"));
            this.items.Add(new InventoryItem("Flute", @"images\flute.png"));
            this.items.Add(new InventoryItem("Flute w/o Shovel", @"images\flutenoshovel.png"));
            this.items.Add(new InventoryItem("Four Bottles", @"images\fourbottles.png"));
            this.items.Add(new InventoryItem("Golden Sword", @"images\goldensword.png"));
            this.items.Add(new InventoryItem("Green Pendant", @"images\greenpendant.png"));
            this.items.Add(new InventoryItem("Green Potion", @"images\greenpotion.png"));
            this.items.Add(new InventoryItem("Green Tunic", @"images\greentunic.png"));
            this.items.Add(new InventoryItem("Half Magic", @"images\halfmagic.png"));
            this.items.Add(new InventoryItem("Heart Container", @"images\heartcontainer.png"));
            this.items.Add(new InventoryItem("Hookshot", @"images\hookshot.png"));
            this.items.Add(new InventoryItem("Ice Palace", @"images\icepalace.png"));
            this.items.Add(new InventoryItem("Ice Rod", @"images\icerod.png"));
            this.items.Add(new InventoryItem("Lamp", @"images\lamp.png"));
            this.items.Add(new InventoryItem("Lanmola", @"images\Lanmola.png"));
            this.items.Add(new InventoryItem("Magic Boomerang", @"images\magicboomerang.png"));
            this.items.Add(new InventoryItem("Magic Cape", @"images\magiccape.png"));
            this.items.Add(new InventoryItem("Magic Powder", @"images\magicpowder.png"));
            this.items.Add(new InventoryItem("Master Sword", @"images\mastersword.png"));
            this.items.Add(new InventoryItem("Magic Hammer", @"images\mchammer.png"));
            this.items.Add(new InventoryItem("Misery Mire", @"images\mire.png"));
            this.items.Add(new InventoryItem("Mirror", @"images\mirror.png"));
            this.items.Add(new InventoryItem("Mirror Shield", @"images\mirrorshield.png"));
            this.items.Add(new InventoryItem("Moldorm", @"images\Moldorm.png"));
            this.items.Add(new InventoryItem("Moon Pearl", @"images\moonpearl.png"));
            this.items.Add(new InventoryItem("Mushroom", @"images\mushroom.png"));
            this.items.Add(new InventoryItem("One Bottle", @"images\onebottle.png"));
            this.items.Add(new InventoryItem("One Heart Container", @"images\oneheartcontainerpiece.png"));
            this.items.Add(new InventoryItem("Opened Chest", @"images\openedchest.png"));
            this.items.Add(new InventoryItem("Master Sword Pedestal", @"images\pedestal.png"));
            this.items.Add(new InventoryItem("Piece of Heart", @"images\pieceofheart.png"));
            this.items.Add(new InventoryItem("Palace of Darkness", @"images\pod.png"));
            this.items.Add(new InventoryItem("Power Glove", @"images\powerglove.png"));
            this.items.Add(new InventoryItem("Quake", @"images\quake.png"));
            this.items.Add(new InventoryItem("Quarter Magic", @"images\quartermagic.png"));
            this.items.Add(new InventoryItem("Red Medicine", @"images\redmedicine.png"));
            this.items.Add(new InventoryItem("Red Pendant", @"images\redpendant.png"));
            this.items.Add(new InventoryItem("Red Tunic", @"images\redtunic.png"));
            this.items.Add(new InventoryItem("Shield", @"images\shield.png"));
            this.items.Add(new InventoryItem("Shovel", @"images\shovel.png"));
            this.items.Add(new InventoryItem("Shovel w/ Flute", @"images\shovelandflute.png"));
            this.items.Add(new InventoryItem("Shovel w/o Flute", @"images\shovelnoflute.png"));
            this.items.Add(new InventoryItem("Skull Woods", @"images\skullwoods.png"));
            this.items.Add(new InventoryItem("Cane of Somaria", @"images\somaria.png"));
            this.items.Add(new InventoryItem("Swamp Palace", @"images\swamppalace.png"));
            this.items.Add(new InventoryItem("Tempered Sword", @"images\temperedsword.png"));
            this.items.Add(new InventoryItem("Thieves' Town", @"images\thievestown.png"));
            this.items.Add(new InventoryItem("Three Bottles", @"images\threebottles.png"));
            this.items.Add(new InventoryItem("Three Heart Container Pieces", @"images\threeheartcontainerpiece.png"));
            this.items.Add(new InventoryItem("Titan's Mitt", @"images\titanmitts.png"));
            this.items.Add(new InventoryItem("Turtle Rock", @"images\turtlerock.png"));
            this.items.Add(new InventoryItem("Two Bottles", @"images\twobottles.png"));
            this.items.Add(new InventoryItem("Two Pieces of Heart", @"images\twoheartcontainerpiece.png"));
        }
    }
}
