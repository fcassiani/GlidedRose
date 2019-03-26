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

        // Added: Increase item quality (by reference), keeping it at max 50.  
        public static void increaseQuality(Item item)
        {
            if(item.Quality<50) item.Quality++;
        }

        // Added: Decrease item quality (by reference), keeping it at min 0.  
        public static void decreaseQuality(Item item)
        {
            if(item.Quality > 0) item.Quality--;
        }

        //Refactored:
        public void UpdateQuality()
        {
            // Iterate through all items in the list.  
            // Better than recovering the item several times, referencing its index. 
            // currentItem will be a reference to the original object into the list.   
            foreach (Item currentItem in Items)
            {
                //Prefix simplification of items
                string itemName = currentItem.Name.ToUpper();
                string[] keys = new string[] {"AGED BRIE","SULFURAS", "BACKSTAGE PASSES", "CONJURED" };
                string currentItemName = keys.FirstOrDefault<string>(s => itemName.Contains(s));

                currentItem.SellIn--;

                switch (currentItemName)
                {
                    case "SULFURAS": //Do not decrease in quality or sellin
                        currentItem.SellIn++;
                        break;
                    case "AGED BRIE": //Quality of Aged Brie always increase
                        //sellIn not passed increase quality in once
                        if (currentItem.SellIn >= 0)
                        {
                            increaseQuality(currentItem);
                        }
                        //sellIn passed increase quality by 2
                        else
                        {
                            for (int i = 0; i < 2; i++)
                                increaseQuality(currentItem);
                        }

                        break;

                    case "BACKSTAGE PASSES":
                        //control if quality is above 0 to calculate 
                        if (currentItem.Quality > 0)
                        {
                            increaseQuality(currentItem);

                            //if 10 days increase twice
                            if (currentItem.SellIn < 10) increaseQuality(currentItem);                                

                                //if 5 days increase three times
                            if (currentItem.SellIn < 5) increaseQuality(currentItem);
                                
                            //passed the concert day set quality to 0    
                            if (currentItem.SellIn < 0)
                                currentItem.Quality = 0;
                        }

                        break;
                    case "CONJURED":
                        //conjured items decrease in quality twice as fast as normal items (default case)
                        if (currentItem.SellIn >= 0)
                        {
                            for (int i = 0; i < 2; i++)
                                decreaseQuality(currentItem);
                        }
                        //if sellin passed decrease twice more times
                        else
                        {
                            for (int i = 0; i < 4; i++)
                                decreaseQuality(currentItem);
                        }
                        
                        break;
                    default:
                        //sellIn has not passed decrease once
                        if (currentItem.SellIn >= 0)
                        {
                            decreaseQuality(currentItem);
                        }
                        //sellIn passed decrease twice
                        else
                        {
                            for (int i = 0; i < 2; i++)
                                decreaseQuality(currentItem);
                        }

                        break;
                }
            }
        }
    }
}
