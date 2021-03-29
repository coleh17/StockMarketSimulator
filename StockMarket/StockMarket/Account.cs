using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarketSimulator
{
    public class Account
    {
        private Market market;
        private float balance;
        private Dictionary<string, StockOrder> portfolio;

        public Account(Market _market, float startingBalance)
        {
            market = _market;
            balance = startingBalance;
            portfolio = new Dictionary<string, StockOrder>();
        }

        /// <summary>
        /// Creates buy order for the user to execute
        /// </summary>
        /// <param name="symbol">symbol of stock</param>
        /// <param name="quantity">quantity to purchase</param>
        /// <returns>Tuple <success(bool), total cost, message></returns>
        public Tuple<bool, float, string> CreateBuyOrder(string symbol, int quantity)
        {
            try
            {
                if (balance < market.GetStockPrice(symbol))
                    return new Tuple<bool, float, string>(false, 0, "Not enough money in account!");
                Tuple<bool, float> orderResponse = market.BuyOrder(symbol, quantity);
                if (orderResponse.Item1)
                {
                    balance -= orderResponse.Item2;
                    if (portfolio.ContainsKey(symbol))
                    {
                        StockOrder order = portfolio[symbol];
                        order.symbol += quantity;
                    }
                    else
                    {
                        StockOrder order = new StockOrder
                        {
                            symbol = symbol,
                            quantity = quantity,
                            orderDate = new DateTime()
                        };
                        portfolio.Add(symbol, order);
                    }
                    return new Tuple<bool, float, string>(true, orderResponse.Item2, "Success!");
                }
                else
                    return new Tuple<bool, float, string>(false, 0, "Order failed!");
            }
            // Catch InvalidTicker, InvalidQuantity, or any other exception
            catch (Exception e)
            {
                return new Tuple<bool, float, string>(false, 0, e.Message);
            }
        }

        /// <summary>
        /// Creates sell order for the user to execute
        /// </summary>
        /// <param name="symbol">symbol of stock</param>
        /// <param name="quantity">quantity to sell</param>
        /// <returns>Tuple <success(bool), total sale, message></returns>
        public Tuple<bool, float, string> CreateSellOrder(string symbol, int quantity)
        {
            StockOrder order;
            if (portfolio.TryGetValue(symbol, out order))
            {
                if (order.quantity < quantity)
                    return new Tuple<bool, float, string>(false, 0, "You only own " + order.quantity.ToString() + " " + symbol.ToUpper());
            }
            else
                return new Tuple<bool, float, string>(false, 0, "You do not own any " + symbol.ToUpper());
            try
            {
                Tuple<bool, float> orderResponse = market.SellOrder(symbol, quantity);
                if (orderResponse.Item1)
                {
                    balance += orderResponse.Item2;
                    return new Tuple<bool, float, string>(true, orderResponse.Item2, "Success!");
                }
                else
                    return new Tuple<bool, float, string>(false, 0, "Order failed!");
            }
            // Catch InvalidTicker, InvalidQuantity, or any other exception
            catch (Exception e)
            {
                return new Tuple<bool, float, string>(false, 0, e.Message);
            }
        }

    }
}
