using GildedRose.Console.Models;

namespace GildedRose.Console.Helpers
{
    public class ItemType
    {
        public const string DexterityVest = "+5 Dexterity Vest";
        public const string ConjuredManaCake = "Conjured Mana Cake";
        public const string ElixirOfTheMongoose = "Elixir of the Mongoose";
        public const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        public const string Pass = "Backstage passes to a TAFKAL80ETC concert";
        public const string AgedBrie = "Aged Brie";

        public static bool IsCommon(Item current)
        {
            return !IsLegendary(current);
        }

        public static bool IsLegendary(Item current)
        {
            return Sulfuras.Equals(current.Name);
        }        
    }
}