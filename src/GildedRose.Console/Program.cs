namespace GildedRose.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");
            var shop = new GildedRose();
            for (var i = 0; i < 20; i++)
            {
                shop.UpdateQuality();
                shop.ToConsole();
            }
            System.Console.ReadKey();
        }
    }
}
