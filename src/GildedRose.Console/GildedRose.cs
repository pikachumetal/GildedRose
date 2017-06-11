using GildedRose.Console.Helpers;
using GildedRose.Console.Models;
using System.Collections.Generic;
using System.Linq;
using GildedRose.Console.Strategies;

namespace GildedRose.Console
{
    public class GildedRose
    {
        private readonly IList<Item> _items;
        private int _day = 0;

        public GildedRose()
        {
            _items = new List<Item>
            {
                new Item {Name = ItemType.DexterityVest, SellIn = 10, Quality = 20},
                new Item {Name = ItemType.AgedBrie, SellIn = 2, Quality = 0},
                new Item {Name = ItemType.ElixirOfTheMongoose, SellIn = 5, Quality = 7},
                new Item {Name = ItemType.Sulfuras, SellIn = 0, Quality = 80},
                new Item {Name = ItemType.Pass, SellIn = 15, Quality = 20},
                new Item {Name = ItemType.ConjuredManaCake, SellIn = 3, Quality = 40}
            };
        }

        /// <summary>
        /// For testing...
        /// </summary>
        /// <param name="items"></param>
        public GildedRose(IList<Item> items)
        {
            _items = items;
        }

        public Item GetItem(string name)
        {
            return _items.Single(o => name.Equals(o.Name));
        }

        public void UpdateQuality()
        {
            _day++;
            foreach (var current in _items)
            {
                var updateQualityStrategy = UpdateQualityStrategyFactory.GetStrategy(current);
                updateQualityStrategy.RunUpdateQuality(current);
            }
        }

        public void ToConsole()
        {
            System.Console.WriteLine($"++++ Day: {_day} ++++");
            foreach (var current in _items)
            {
                System.Console.WriteLine($"Item: {current.Name} | Quality: {current.Quality} | SellIn: {current.SellIn}");
            }
            System.Console.WriteLine("++++ +++++++++++ ++++");
            System.Console.WriteLine("");
        }
    }
}
