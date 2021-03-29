using System;
using System.Linq;
using StockMarketSimulator;

namespace TestSimulator
{
    public class TestSimulator
    {
        private static Random random = new Random();

        static void Main(string[] args)
        {
            Market market = new Market();
            PopulateMarket(market);

            Console.ReadLine();
        }

        public static void PopulateMarket(Market market)
        {
            for (int i = 0; i < 10; i++)
            {
                Stock stock = new Stock(RandomString(3), 100);
                market.AddStock(stock);
            }
            Console.WriteLine("Market Populated:");
            foreach (Stock s in market.GetStocks())
                Console.WriteLine(s.Symbol + " - $" + s.GetPrice());
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
