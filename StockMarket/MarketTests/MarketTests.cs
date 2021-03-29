using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using StockMarketSimulator;

namespace MarketTests
{
    [TestClass]
    public class MarketTests
    {
        [TestMethod]
        public void TestMarketCreation()
        {
            Market market = new Market(); 
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidTicker))]
        public void BuyOrderInvalidTicker()
        {
            Market market = new Market();
            market.BuyOrder("ABC", 5);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidTicker))]
        public void SellOrderInvalidTicker()
        {
            Market market = new Market();
            market.SellOrder("ABC", 5);
        }

        [TestMethod]
        public void AddNewTicker()
        {
            Market market = new Market();
            market.AddStock(new Stock("ABC", 10));
        }

        [TestMethod]
        public void AddNewInvalidTicker()
        {
            Market market = new Market();
            Assert.IsFalse(market.AddStock(new Stock("A1", 10)));
        }

        [TestMethod]
        public void GetTickerInfo()
        {
            Market market = new Market();
            market.AddStock(new Stock("ABC", 10));
            Assert.AreEqual(10.0, market.GetStockPrice("ABC"));
        }
    }
}
