using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockMarketSimulator;

namespace MarketTests
{
    [TestClass]
    public class StockTests
    {
        [TestMethod]
        public void CreateNewStock()
        {
            Stock stock = new Stock("ABC", 10);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidTicker))]
        public void CreateNewStockWithInvalidTicker()
        {
            Stock stock = new Stock("AB", 10);
        }

        [TestMethod]
        public void GetStockInfo()
        {
            Stock stock = new Stock("ABC", 10);
            Assert.AreEqual(10.0, stock.GetPrice());
            Assert.AreEqual("ABC", stock.Symbol);
        }

        [TestMethod]
        public void BuyOrder()
        {
            Stock stock = new Stock("ABC", 10);
            stock.BuyOrder(10);
            Assert.AreEqual(10, stock.GetVolume());
            Assert.AreEqual(10, stock.GetOutstandingShares());
        }

        [TestMethod]
        public void BuyOrderReturnType()
        {
            Stock stock = new Stock("ABC", 10);
            Assert.AreEqual(100.0, stock.BuyOrder(10));
        }

        [TestMethod]
        public void SellOrder()
        {
            Stock stock = new Stock("ABC", 10);
            stock.SellOrder(10);
            Assert.AreEqual(-10.0, stock.GetOutstandingShares());
        }

        [TestMethod]
        public void BuyAndSellOrders()
        {
            Stock stock = new Stock("ABC", 10);
            stock.BuyOrder(10);
            Assert.AreEqual(10, stock.GetOutstandingShares());
            stock.SellOrder(5);
            Assert.AreEqual(5, stock.GetOutstandingShares());
            stock.BuyOrder(50);
            Assert.AreEqual(55, stock.GetOutstandingShares());
        }

    }
}
