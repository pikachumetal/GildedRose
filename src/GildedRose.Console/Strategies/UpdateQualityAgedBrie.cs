using GildedRose.Console.Helpers;
using GildedRose.Console.Models;

namespace GildedRose.Console.Strategies
{
    public class UpdateQualityAgedBrie : IUpdateQualityStrategy
    {
        public  void RunUpdateQuality(Item item)
        {
            Quality.Increase(item);
            SellIn.Decrease(item);
            if (!SellIn.IsExpired(item)) return;
            Quality.Increase(item);
        }
    }
}