using System.Collections.Generic;
using NUnit.Framework;

namespace GildedRose
{  
    // An example of how 100% Code Coverage doesn't correlate with 100% behavior coverage
    public class OneHundredPercentCoverage
    {
        private List<Item> createItemList(string itemName, int sellIn, int quality) {
            return new List<Item> { new Item { Name = itemName, SellIn = sellIn, Quality = quality } };
        }        

        [Test]
        public void AgedBrie_PastSellInDate_QualityBelowMax_QualityIncreasesTwiceAsFast() {
            GildedRose sut = new GildedRose(createItemList("Aged Brie", -1, 40));
    
            sut.UpdateQuality();
    
            Assert.AreEqual(42, sut.Items[0].Quality, "Quality increases twice as fast for old cheese");
        }

        
        [Test]
        [Ignore("adding this test bumps coverage to 67%")]
        public void BackstagePass_PastSellInDate_QualityDropsToZero()
        {
            GildedRose sut = new GildedRose(createItemList("Backstage passes to a TAFKAL80ETC concert", -1, 40));
    
            sut.UpdateQuality();
    
            Assert.AreEqual(0, sut.Items[0].Quality, "Backstage pass after the concert has no value");
        }

        [Test]
        [Ignore("adding this third test achieves 100% coverage")]
        public void AnyItem_PastSellInDate_QualityDropsTwiceAsFast()
        {
            GildedRose sut = new GildedRose(createItemList("any item", -1, 30));
    
            sut.UpdateQuality();
    
            Assert.AreEqual(28, sut.Items[0].Quality, "quality drops twice as fast after sellin date");
        }
        
    }
}