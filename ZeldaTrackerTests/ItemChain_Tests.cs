using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ZeldaTracker;
using Tracker;

namespace ZeldaTrackerTests
{
    public class ItemChain_Tests
    {
        public JsonItemChain MakeMockItemChain(string name)
        {
            var jsonChain = new JsonItemChain();
            jsonChain.Countable = false;
            jsonChain.DefaultEnabled = false;
            jsonChain.ItemChain.Add(new JsonItem() { IconPath = @"images/" + name + ".png", ItemName = name });
            jsonChain.ItemChainName = name;
            jsonChain.ItemChainType = name;
            jsonChain.Loopable = false;
            jsonChain.MaxCount = 0;
            return jsonChain;
        }

        JsonItemChain loadableMockChain;
        JsonItemChain unloadableMockChain;

        public ItemChain_Tests()
        {
            loadableMockChain = MakeMockItemChain("test");
            unloadableMockChain = MakeMockItemChain("junk");
        }

        [WpfFact]
        public async Task Chain_Name_Gets_Set()
        {
            // Arrange
            var chain = new ItemChain(loadableMockChain);

            // Act
            await Task.Yield();

            // Assert
            Assert.Equal("test", chain.ItemChainName);
        }

        [WpfFact]
        public async Task Icon_Gets_Loaded()
        {
            // Arrange
            var chain = new ItemChain(loadableMockChain);

            // Act
            await Task.Yield();

            // Assert
            Assert.Equal(32, chain.Icon.PixelWidth);
            Assert.Equal(32, chain.Icon.PixelHeight);
        }

        [WpfFact]
        public async Task Misisng_Image_Gets_Loaded()
        {
            // TODO: should this even be a test? It's testing logic from InventoryItem, which is already tested....
            // Arrange
            var chain = new ItemChain(unloadableMockChain);

            // Act
            await Task.Yield();

            // Assert
            Assert.Equal(64, chain.Icon.PixelWidth);
            Assert.Equal(64, chain.Icon.PixelHeight);
        }
    }
}
