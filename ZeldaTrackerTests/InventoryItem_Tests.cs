using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Xunit;
using ZeldaTracker;
using ZeldaTrackerTests;

namespace ZeldaTrackerTests
{
    public class InventoryItem_Tests
    {
        public InventoryItem_Tests()
        {
            PackUriHelper.Create(new Uri("reliable://0"));
            var junk = new FrameworkElement();
            System.Windows.Application.ResourceAssembly = typeof(ZeldaTracker.App).Assembly;
        }

        [WpfFact]
        public async Task Loads_Correct_Name()
        {
            // Arrange
            var item = new InventoryItem("test", @"images/test.png");
            item.LoadImage();

            // Act
            await Task.Yield();

            // Assert
            Assert.Equal("test", item.ItemName);
        }

        [WpfFact]
        public async Task Loads_Image_File()
        {
            // Arrange
            var item = new InventoryItem("test", @"images/test.png");
            item.LoadImage();

            // Act
            await Task.Yield();

            // Assert
            Assert.Equal(32, item.Icon.PixelWidth);
            Assert.Equal(32, item.Icon.PixelHeight);
        }

        [WpfFact]
        public async Task Fail_to_load_image_and_load_not_found_image()
        {
            await Task.Yield();

            // Arrange
            var item = new InventoryItem("test", @"xxxx");
            Assert.Throws<ImageNotFoundException>(() => item.LoadImage());
            

            // Act
            // Assert
        }
    }
}
