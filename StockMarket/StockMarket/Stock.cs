using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarketSimulator
{
    public class Stock
    {
        // Stock symbol (3-4 char)
        private string Symbol;
        // Current price of stock
        private float Price;
        // Current trade volume
        private int Volume;
        // Current outstanding shares
        private int OutstandingShares;

        public Stock(string _Symbol, int _Price)
        {
            Symbol = _Symbol;
            Price = _Price;
            Volume = 0;
            OutstandingShares = 0;
        }

        /// <summary>
        /// Creates buy order for current stock, returns total cost
        /// </summary>
        /// <param name="quantity">Quantity of purchase</param>
        public float BuyOrder(int quantity)
        {
            Volume += quantity;
            OutstandingShares += quantity;
            return this.Price * quantity;
        }

        /// <summary>
        /// Creates sell order for current stock
        /// </summary>
        /// <param name="quantity">Quantity of sell</param>
        public void SellOrder(int quantity)
        {
            OutstandingShares -= quantity;
        }

        /// <summary>
        /// Set current stock price
        /// </summary>
        /// <param name="price">New price</param>
        private void SetPrice(float price)
        {
            Price = price;
        }

        /// <summary>
        /// Get current stock price
        /// </summary>
        /// <returns>Stock price</returns>
        public float GetPrice()
        {
            return Price;
        }

    }
}
