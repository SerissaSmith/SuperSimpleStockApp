using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleStockApp
{
    public class StockItem : IStockItem
    {
        //auto properties, keeping the Sets to private to avoid eronious updating of stock statistics
        public string StockSymbol { get; private set; }
        public decimal LastDividend { get; private set; }
        public decimal FixedDividend { get; private set; }
        public decimal ParValue { get; private set; }
        public string StockType { get; private set; }

        public StockItem (string stockSymbol = null, string stockType = null , decimal lastDividend = 0.00m, decimal fixedDividend = 0.00m, decimal parValue = 0.00m)
        {
            if (stockSymbol != null)
            {
                if (stockSymbol.Length == 3)
                {
                    StockSymbol = stockSymbol.ToUpper();
                }
            }
            if (stockType == "Preferred" || stockType == "preferred" || stockType == "PREFERRED")
            {
                StockType = "Preferred";//assumption, only Common or Preferred exist as states
            }
            LastDividend = lastDividend;
            FixedDividend = fixedDividend;
            ParValue = parValue;
        }

        public decimal CalculateDividendYeild (decimal input)
        {
            decimal result = 0.00m;
            if (input != 0.00m)
            {
                if (StockType == "Common")
                {
                    if (LastDividend != 0.00m)
                    {
                        result = LastDividend / input;
                    }
                }
                else
                {
                    /*
                    * unsure if this is what is being requested, the Formula seems to be asking for a dot product of two none vector
                    * numbers, have moved forwards under the assumption that the . was intended as a *, but would have asked for clarification here,
                    * as i am unfamiliar with the stock market and thus unable to determine the correct course of action.
                    */
                    result = (FixedDividend * ParValue) / input;
                }
            }

            return result;
        }

        public decimal CalculatePERatio (decimal input)
        {
            decimal result = 0.00m;

            if (StockType == "Common")
            {
                if (LastDividend != 0.00m)
                {
                    result = input / LastDividend;
                }
            }
            else
            {
                result = input / (FixedDividend * ParValue);
            }

            return result;
        }

    }
}

