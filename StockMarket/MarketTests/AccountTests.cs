using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockMarketSimulator;

namespace MarketTests
{
    [TestClass]
    public class AccountTests
    {
        Market market = new Market();
        
        [TestInitialize]
        public void Init()
        {
            market.AddStock(new Stock("ABC", 10));
        }

        [TestMethod]
        public void CreateAccount()
        {
            Account acct = new Account(market, 1000);
        }

        [TestMethod]
        public void BuyOrder()
        {
            Account acct = new Account(market, 1000);
            Tuple<bool, float, string> res = acct.CreateBuyOrder("ABC", 5);
            Assert.IsTrue(res.Item1);
            Assert.AreEqual(50.0, res.Item2);
        }

        [TestMethod]
        public void BuyOrderWithInvalidTicker()
        {
            Account acct = new Account(market, 1000);
            Tuple<bool, float, string> res = acct.CreateBuyOrder("A1", 5);
            Assert.IsFalse(res.Item1);
            Assert.AreEqual(0.0, res.Item2);
        }

        [TestMethod]
        public void SellOrder()
        {
            Account acct = new Account(market, 1000);
            acct.CreateBuyOrder("ABC", 5);
            Tuple<bool, float, string> res = acct.CreateSellOrder("ABC", 2);
            Assert.IsTrue(res.Item1);
            Assert.AreEqual(20.0, res.Item2);
        }

        [TestMethod]
        public void SellOrderWithoutOwning()
        {
            Account acct = new Account(market, 1000);
            Tuple<bool, float, string> res = acct.CreateSellOrder("ABC", 2);
            Assert.IsFalse(res.Item1);
            Assert.AreEqual(0.0, res.Item2);
        }

        [TestMethod]
        public void SellOrderWithoutOwningEnough()
        {
            Account acct = new Account(market, 1000);
            acct.CreateBuyOrder("ABC", 1);
            Tuple<bool, float, string> res = acct.CreateSellOrder("ABC", 2);
            Assert.IsFalse(res.Item1);
            Assert.AreEqual(0.0, res.Item2);
        }
    }
}
