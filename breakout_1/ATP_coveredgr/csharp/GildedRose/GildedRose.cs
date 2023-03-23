using System.Collections.Generic;

namespace GildedRose
{
    public class GildedRose
    {
        private readonly IList<Item> _items;
        public IList<Item> Items => _items;
        private const int MinimumQuantity = 0;
        private const int MaximumQuality = 50;
        private const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";

        public GildedRose(IList<Item> items)
        {
            this._items = items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < _items.Count; i++)
            {
                var item = _items[i];
                if (!item.Name.Equals("Aged Brie") && !item.Name.Equals(BackstagePasses))
                {
                    IncreaseQuality(item);
                }
                else
                {
                    if (item.Quality < MaximumQuality)
                    {
                        item.Quality += 1;

                        if (item.Name.Equals(BackstagePasses))
                        {
                            if (item.SellIn < 11)
                            {
                                if (item.Quality < MaximumQuality)
                                {
                                    item.Quality += 1;
                                }
                            }

                            if (item.SellIn < 6)
                            {
                                if (item.Quality < MaximumQuality)
                                {
                                    item.Quality += 1;
                                }
                            }
                        }
                    }
                }

                if (!item.Name.Equals("Sulfuras, Hand of Ragnaros"))
                {
                    item.SellIn -= 1;
                }

                if (item.SellIn < 0)
                {
                    if (!item.Name.Equals("Aged Brie"))
                    {
                        if (!item.Name.Equals(BackstagePasses))
                        {
                            if (item.Quality > MinimumQuantity)
                            {
                                if (!item.Name.Equals("Sulfuras, Hand of Ragnaros"))
                                {
                                    item.Quality -= 1;
                                }
                            }
                        }
                        else
                        {
                            item.Quality = 0;
                        }
                    }
                    else
                    {
                        if (item.Quality < MaximumQuality)
                        {
                            item.Quality += 1;
                        }
                    }
                }
            }
        }

        private static void IncreaseQuality(Item item)
        {
            if (item.Quality > MinimumQuantity && !item.Name.Equals("Sulfuras, Hand of Ragnaros"))
            {
                item.Quality -= 1;
            }
        }
    }
}
