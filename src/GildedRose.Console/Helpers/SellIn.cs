using GildedRose.Console.Models;

namespace GildedRose.Console.Helpers
{
    public class SellIn
    {
        public const int Granurality = 1;
        public const int DoubleIncrementThreshold = 10;
        public const int TripleIncrementThreshold = 5;
        public const int Minimum = 0;

        public static bool IsExpired(Item current)
        {
            return current.SellIn < Minimum;
        }

        public static bool IsDoubleIncrementThresholdReached(Item current)
        {
            return current.SellIn <= DoubleIncrementThreshold;
        }

        public static bool IsTripleIncrementThresholdReached(Item current)
        {
            return current.SellIn <= TripleIncrementThreshold;
        }

        public static void Decrease(Item current)
        {
            if (ItemType.IsLegendary(current)) return;
            current.SellIn = current.SellIn - Granurality;
        }
    }
}