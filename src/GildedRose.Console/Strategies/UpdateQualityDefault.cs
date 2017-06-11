using GildedRose.Console.Helpers;
using GildedRose.Console.Models;

namespace GildedRose.Console.Strategies
{
    public class UpdateQualityDefault : IUpdateQualityStrategy
    {
        public void RunUpdateQuality(Item item)
        {
            Quality.Decrease(item);
            SellIn.Decrease(item);
            if (!SellIn.IsExpired(item)) return;
            Quality.Decrease(item);
        }
    }
}
