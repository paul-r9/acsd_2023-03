using System.Collections.Generic;
using NUnit.Framework;


namespace GildedRose
{
    [TestFixture]
    public class GildedRoseTest
    {

        [SetUp]
        public void CallsBeforeEachTest() {
            
        }
        
        [Test]
        public void this_test_needs_a_better_name()
        {
            // Arrange
            IList<Item> items = new List<Item> { new Item { Name = "generic item", SellIn = 0, Quality = 0 } };
            GildedRose sut = new GildedRose(items);
            
            // Act
            sut.UpdateQuality();
            
            // Assert
            Assert.AreEqual("generic item", items[0].Name);
        }

        [Test]
        public void Generic_Item_Quality_Decreases_At_The_End_Of_Day() {
            
            // assemble
            IList<Item> items = new List<Item> { new Item { Name = "generic item", SellIn = 10, Quality = 20 } };
            GildedRose sut = new GildedRose(items);
            
            // act
            sut.UpdateQuality();
            
            
            // assert
            Assert.AreEqual(expected: 19, actual:items[0].Quality);
        }
        
        [Test]
        public void Generic_Item_Quality_Decreases_Twice_As_Fast_After_Expiration() {
            IList<Item> items = new List<Item> { new Item { Name = "generic item", SellIn = 0, Quality = 20 } };
            GildedRose sut = new GildedRose(items);
            
            sut.UpdateQuality();
            
            Assert.AreEqual(expected: 18, actual:items[0].Quality);
        }
        
        [Test]
        public void All_Items_That_Decrease_Quality_Are_Never_Negative() {
            IList<Item> items = new List<Item> {
                new Item { Name = "generic item", SellIn = 0, Quality = 0 },
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert",SellIn = 0,Quality = 0}
            };
            GildedRose sut = new GildedRose(items);
            
            sut.UpdateQuality();
            
            Assert.AreEqual(expected: 0, actual:items[0].Quality);
            Assert.AreEqual(0,items[1].Quality);
        }

        [Test]
        [Ignore("Finish this later")]
        public void Backstage_Pass_Quality_Increases_By_2_When_10_Days_Left() {
            // Arrange
            IList<Item> items = new List<Item>() {new Item {Name = "Backstage passes to a TAFKAL80ETC concert"}};
            // Act
            // Assert

        }
    }
}
