using System;
using GildedRose.Console.Models;
using Xunit;

namespace GildedRose.Tests
{
    public class TestAssemblyTests
    {
        [Fact]
        public void TestTheTruth()
        {
            Assert.True(true);
        }

        [Fact]
        public void UpdateQuality_DecrementsItemsQualityAndSellInBy1()
        {
            var items = new[] { new Item() { Name = "foo", Quality = 1, SellIn = 1 } };
            var app = new Console.GildedRose(items);
            app.UpdateQuality();
            var item = app.GetItem("foo");
            Assert.Equal("foo", item.Name);
            Assert.Equal(0, item.Quality);
            Assert.Equal(0, item.SellIn);
        }

        [Fact]
        public void OnceTheSellByDateHasPassed_QualityDegradesTwiceAsFast()
        {
            var items = new[] { new Item() { Name = "bar", SellIn = -1, Quality = 2 } }; 
            var app = new Console.GildedRose(items);
            app.UpdateQuality();
            var item = app.GetItem("bar");
            Assert.Equal("bar", item.Name);
            Assert.Equal(0, item.Quality);
            Assert.Equal(-2, item.SellIn);
        }

        [Fact]
        public void QualityOfAnItemIsNeverNegative()
        {
            var items = new[] { new Item() { Name = "foo", SellIn = 2, Quality = 2 } };

            var app = new Console.GildedRose(items);

            app.UpdateQuality();
            app.UpdateQuality();
            app.UpdateQuality();

            var item = app.GetItem("foo");
            Assert.Equal("foo", item.Name);
            Assert.Equal(0, item.Quality);
            Assert.Equal(-1, item.SellIn);
        }

        [Fact]
        public void TheQualityOfAnItemIsNeverMoreThan50()
        {
            var items = new[]
            {
                new Item() { Name = "Aged Brie", SellIn = -1, Quality = 50 },
                new Item() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 3, Quality = 49 },
            };

            var app = new Console.GildedRose(items);
            app.UpdateQuality();

            var item = app.GetItem("Aged Brie");
            var item2 = app.GetItem("Backstage passes to a TAFKAL80ETC concert");

            Assert.Equal("Aged Brie", item.Name);
            Assert.Equal(50, item.Quality);
            Assert.Equal(-2, item.SellIn);

            Assert.Equal("Backstage passes to a TAFKAL80ETC concert", item2.Name);
            Assert.Equal(50, item2.Quality);
            Assert.Equal(2, item2.SellIn);
        }

        [Fact]
        public void BriesQualityIncrementsByOneForEachDayPastItsSellByDate()
        {
            var items = new[] { new Item() { Name = "Aged Brie", SellIn = -1, Quality = 1 } };

            var app = new Console.GildedRose(items);
            app.UpdateQuality();

            var item = app.GetItem("Aged Brie");
            Assert.Equal("Aged Brie", item.Name);
            Assert.Equal(3, item.Quality);
            Assert.Equal(-2, item.SellIn);
        }

        [Fact]
        public void SulfurasBeingALegendaryItemNeverHasToBeSoldOrDecreasesInQuality()
        {
            var items = new[] { new Item() { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 } };

            var app = new Console.GildedRose(items);
            app.UpdateQuality();

            var item = app.GetItem("Sulfuras, Hand of Ragnaros");
            Assert.Equal("Sulfuras, Hand of Ragnaros", item.Name);
            Assert.Equal(80, item.Quality);
            Assert.Equal(-1, item.SellIn);
        }

        [Fact]
        public void BackstagePassesQualityIncrementsByOneWithEachDayPassing()
        {
            var items = new[] { new Item() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 30 } };

            var app = new Console.GildedRose(items);
            app.UpdateQuality();

            var item = app.GetItem("Backstage passes to a TAFKAL80ETC concert");
            Assert.Equal("Backstage passes to a TAFKAL80ETC concert", item.Name);
            Assert.Equal(31, item.Quality);
            Assert.Equal(10, item.SellIn);
        }

        [Fact]
        public void BackstagePassesIncreaseInQualityBy2WhenThereAre10DaysOrLessRemaining()
        {
            var items = new[] { new Item() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 30 } };

            var app = new Console.GildedRose(items);
            app.UpdateQuality();

            var item = app.GetItem("Backstage passes to a TAFKAL80ETC concert");
            Assert.Equal("Backstage passes to a TAFKAL80ETC concert", item.Name);
            Assert.Equal(32, item.Quality);
            Assert.Equal(9, item.SellIn);
        }

        [Fact]
        public void BackstagePassesIncreaseInQualityBy3WhenThereAre5DaysOrLessRemaining()
        {
            var items = new[] { new Item() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 33 } };

            var app = new Console.GildedRose(items);
            app.UpdateQuality();

            var item = app.GetItem("Backstage passes to a TAFKAL80ETC concert");
            Assert.Equal("Backstage passes to a TAFKAL80ETC concert", item.Name);
            Assert.Equal(36, item.Quality);
            Assert.Equal(4, item.SellIn);
        }

        [Fact]
        public void BackstagePassesQualityDropsTo0AfterTheConcert()
        {
            var items = new[] { new Item() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 30 } };

            var app = new Console.GildedRose(items);
            app.UpdateQuality();

            var item = app.GetItem("Backstage passes to a TAFKAL80ETC concert");
            Assert.Equal("Backstage passes to a TAFKAL80ETC concert", item.Name);
            Assert.Equal(0, item.Quality);
            Assert.Equal(-2, item.SellIn);
        }

        [Fact]
        public void ConjuredItemsDegradeInQualityTwiceAsFastAsNormalItems()
        {
            var items = new[] { new Item() { Name = "Conjured Mana Cake", SellIn = 2, Quality = 30 } };
            var app = new Console.GildedRose(items);
            app.UpdateQuality();
            var item = app.GetItem("Conjured Mana Cake");
            Assert.Equal("Conjured Mana Cake", item.Name);
            Assert.Equal(28, item.Quality);
            Assert.Equal(1, item.SellIn);
        }

        [Fact]
        public void GetItem_throwsRuntimeExceptionIfRequestedItemDoesntExist()
        {
            var app = new Console.GildedRose(new Item[0]);
            var ex = Assert.Throws<InvalidOperationException>(() => app.GetItem("foobar"));
            Assert.Equal("La secuencia no contiene ningún elemento coincidente", ex.Message);
        }
    }
}