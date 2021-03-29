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
    public class UtilTests
    {
        [TestMethod]
        public void IsValidTicker()
        {
            Assert.IsTrue(StockUtilities.IsValidTicker("ABC"));
            Assert.IsTrue(StockUtilities.IsValidTicker("ABCD"));
            Assert.IsTrue(StockUtilities.IsValidTicker("ABCDE"));
        }

        [TestMethod]
        public void IsInvalidTicker()
        {
            Assert.IsFalse(StockUtilities.IsValidTicker("A"));
            Assert.IsFalse(StockUtilities.IsValidTicker("AB"));
            Assert.IsFalse(StockUtilities.IsValidTicker("AB1"));
            Assert.IsFalse(StockUtilities.IsValidTicker("ABC1"));
            Assert.IsFalse(StockUtilities.IsValidTicker("A_BC"));
        }
    }
}
