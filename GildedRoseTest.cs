using Xunit;
using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRoseTest
    {
        [Fact]
        public void Foo()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "BackStage passes Metallica", SellIn = 3, Quality = 10 },
                new Item { Name = "conjured backstage Apple", SellIn = 3, Quality = 10 }
            };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            
            
            Assert.Equal(13, Items[0].Quality);
            Assert.Equal(8, Items[1].Quality);
        }
    }
}