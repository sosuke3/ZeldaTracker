using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ZeldaTrackerTests
{
    public class ItemChain_Tests
    {
        [Fact]
        public void ATest()
        {
            // Arrange

            // Act

            // Assert
            Assert.Equal(true, true);
        }

        [Fact]
        public void Fail_to_find_mapping_that_does_not_exist()
        {
            // Arrange

            // Act
            //Exception ex = Assert.Throws<Exception>(() => MapperHelper.Instance.MapProjectFieldName("I don't exist"));

            // Assert
            //Assert.Equal("Mapping not found for field: I don't exist", ex.Message);
        }
    }
}
