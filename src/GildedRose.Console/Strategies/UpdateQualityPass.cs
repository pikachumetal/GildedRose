using GildedRose.Console.Helpers;
using GildedRose.Console.Models;

namespace GildedRose.Console.Strategies
{
    public class UpdateQualityPass : IUpdateQualityStrategy
    {
        public void RunUpdateQuality(Item item)
        {
            Quality.Increase(item);
            if (SellIn.IsDoubleIncrementThresholdReached(item)) Quality.Increase(item);
            if (SellIn.IsTripleIncrementThresholdReached(item)) Quality.Increase(item);

            SellIn.Decrease(item);
            if (!SellIn.IsExpired(item)) return;

            Quality.ResetToMinimum(item);
        }
    }
}
