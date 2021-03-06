using System;
using System.Collections.Generic;

namespace StockMarketSimulator
{
    public class Market
    {
        // List of public stock on market
        private Dictionary<string, Stock> StockList;

        public Market()
        {
            StockList = new Dictionary<string, Stock>();
        }

        public bool AddStock(Stock stock)
        {
            if (!StockUtilities.IsValidTicker(stock.Symbol))
                return false;
            if (StockList.ContainsKey(stock.Symbol))
                return false;
            else
            {
                StockList.Add(stock.Symbol, stock);
                return true;
            }
        }

        /// <summary>
        /// Executes a buy order for the requested stock
        /// </summary>
        /// <param name="symbol">Stock ticker to create order</param>
        /// <param name="quantity">Quantity of buy order</param>
        /// <returns>Tuple with two values: <order successful, total cost></returns>
        public Tuple<bool, float> BuyOrder(string symbol, int quantity)
        {
            if (!StockList.TryGetValue(symbol, out _))
                throw new InvalidTicker();
            if (quantity < 1)
                throw new InvalidQuantity();
            float cost = StockList[symbol].BuyOrder(quantity);
            return new Tuple<bool, float>(true, cost);
        }

        /// <summary>
        /// Executes a sell order for the requested stock
        /// </summary>
        /// <param name="symbol">Stock ticker to create order</param>
        /// <param name="quantity">Quantity of sell order</param>
        /// <returns>Tuple with two values: <order successful, number of shares sold></returns>
        public Tuple<bool, float> SellOrder(string symbol, int quantity)
        {
            if (!StockList.TryGetValue(symbol, out _))
                throw new InvalidTicker();
            if (quantity < 1)
                throw new InvalidQuantity();
            float total = StockList[symbol].SellOrder(quantity);
            return new Tuple<bool, float>(true, total);
        }

        /// <summary>
        /// Get a Stock object by ticker symbol
        /// </summary>
        /// <param name="symbol">Ticker to get</param>
        /// <returns>Stock object</returns>
        public Stock GetStock(string symbol)
        {
            if (!StockList.TryGetValue(symbol, out _))
                throw new InvalidTicker();
            else
                return StockList[symbol];
        }

        public float GetStockPrice(string symbol)
        {
            if (!StockList.TryGetValue(symbol, out _))
                throw new InvalidTicker();
            else
                return StockList[symbol].GetPrice();
        }

        public IEnumerable<Stock> GetStocks()
        {
            //List<Stock> list = new List<Stock>();
            //foreach (KeyValuePair<string, Stock> pair in StockList)
            //    list.Add(pair.Value);
            return StockList.Values;
            //return list;
        }

    }

    public class InvalidTicker : Exception
    {
        public InvalidTicker() : base("Invalid ticker provided!") { }
    }

    public class InvalidQuantity : Exception
    {
        public InvalidQuantity() : base("Invalid quantity provided!") { }
    }

}
