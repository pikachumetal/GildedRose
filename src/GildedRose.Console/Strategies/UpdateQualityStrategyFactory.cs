using GildedRose.Console.Helpers;
using System.Collections.Generic;
using GildedRose.Console.Models;

namespace GildedRose.Console.Strategies
{
    public static class UpdateQualityStrategyFactory
    {
        private static readonly Dictionary<string, IUpdateQualityStrategy> Strategies =
            new Dictionary<string, IUpdateQualityStrategy>
            {
                { ItemType.AgedBrie, new UpdateQualityAgedBrie()},
                { ItemType.ConjuredManaCake, new UpdateQualityConjured()},
                { ItemType.DexterityVest, new UpdateQualityDefault()},
                { ItemType.ElixirOfTheMongoose, new UpdateQualityDefault()},
                { ItemType.Pass, new UpdateQualityPass()},
                { ItemType.Sulfuras, new UpdateQualitySulfuras()}
            };

        public static IUpdateQualityStrategy GetStrategy(Item current)
        {
            var key = current.Name;
            return Strategies.ContainsKey(key) ? Strategies[key] : new UpdateQualityDefault();
        }
    }
}
