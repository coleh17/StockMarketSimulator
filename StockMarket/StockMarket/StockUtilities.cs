using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace StockMarketSimulator
{
    public static class StockUtilities
    {
        /// <summary>
        /// Calculates new stock price based on volume and current price
        /// </summary>
        /// <param name="stock">Stock object</param>
        /// <returns>Float of new price</returns>
        public static float CalculatePrice (Stock stock)
        {
            float currPrice = stock.GetPrice();

            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to check if provided ticker is valid
        /// Valid ticker: 3-5 upper case letters
        /// </summary>
        /// <param name="ticker"></param>
        /// <returns></returns>
        public static bool IsValidTicker(string ticker)
        {
            return Regex.IsMatch(ticker, @"^[A-Z]{3,5}$");
        }

    }

    struct StockOrder
    {
        public string symbol;
        public int quantity;
        public DateTime orderDate;
    }
}
