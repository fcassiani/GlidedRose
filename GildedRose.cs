using System.Collections.Generic;
using System.Linq;

namespace csharpcore
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                string itemName = Items[i].Name.ToUpper();
                string[] keys = new string[] {"AGED BRIE","SULFURAS", "BACKSTAGE PASSES", "CONJURED" };
                string sKeyResult = keys.FirstOrDefault<string>(s => itemName.Contains(s));

                Items[i].SellIn--;

                switch (sKeyResult)
                {
                    case "SULFURAS":
                        Items[i].SellIn++;
                        break;
                    case "AGED BRIE":
                        if (Items[i].SellIn >= 0)
                        {
                            if (Items[i].Quality < 50)
                                Items[i].Quality++;
                        }
                        else
                        {
                            if (Items[i].Quality < 50)
                                Items[i].Quality += 2;
                        }
                        if (Items[i].Quality > 50)
                            Items[i].Quality = 50;

                        break;

                    case "BACKSTAGE PASSES":
                        if (Items[i].Quality > 0)
                        {
                            if (Items[i].SellIn >= 10)
                                Items[i].Quality++;
                            else if (Items[i].SellIn < 10 && Items[i].SellIn >= 5)
                                Items[i].Quality += 2;
                            else if (Items[i].SellIn < 5 && Items[i].SellIn >= 0)
                                Items[i].Quality += 3;
                            else if (Items[i].SellIn < 0)
                                Items[i].Quality = 0;
                        }
                        if (Items[i].SellIn >= 0 && Items[i].Quality > 50)
                            Items[i].Quality = 50;

                        break;
                    case "CONJURED":
                        if (Items[i].SellIn >= 0)
                        {
                            if (Items[i].Quality > 0)
                                Items[i].Quality -= 2;
                        }
                        if (Items[i].Quality < 0)
                            Items[i].Quality = 0;

                        break;
                    default:
                        if (Items[i].SellIn >= 0)
                        {
                            if (Items[i].Quality > 0)
                                Items[i].Quality--;
                        }
                        else
                        {
                            if (Items[i].Quality > 0)
                                Items[i].Quality -= 2;
                        }
                        if (Items[i].Quality < 0)
                            Items[i].Quality = 0;

                        break;
                }
            }
        }
    }
}
