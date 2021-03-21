using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarketSimulator
{
    static class StockUtilities
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

    }
}
