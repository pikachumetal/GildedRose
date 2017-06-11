using GildedRose.Console.Models;

namespace GildedRose.Console.Helpers
{
    public class Quality
    {
        public const int Minimum = 0;
        public const int Maximum = 50;
        public const int Granurality = 1;

        public static bool HasSomeQuality(Item current)
        {
            return current.Quality > Minimum;
        }

        public static bool IsMaximumReached(Item current)
        {
            return current.Quality >= Maximum;
        }

        public static void Increase(Item current)
        {
            if (IsMaximumReached(current)) return;
            current.Quality = current.Quality + Granurality;
        }

        public static void Decrease(Item current)
        {
            if (ItemType.IsLegendary(current)) return;
            if (!HasSomeQuality(current)) return;
            current.Quality = current.Quality - Granurality;
        }

        public static void ResetToMinimum(Item current)
        {
            current.Quality = Minimum;
        }
    }
}