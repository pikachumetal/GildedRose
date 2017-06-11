using GildedRose.Console.Helpers;
using GildedRose.Console.Models;

namespace GildedRose.Console.Strategies
{
    public class UpdateQualityConjured : IUpdateQualityStrategy
    {
        public void RunUpdateQuality(Item item)
        {
            Quality.Decrease(item);
            Quality.Decrease(item);

            SellIn.Decrease(item);
            if (!SellIn.IsExpired(item)) return;

            Quality.Decrease(item);
            Quality.Decrease(item);
        }
    }
}
