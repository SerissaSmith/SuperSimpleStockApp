using System;
using System.Collections.Generic;

namespace SimpleStockApp
{
    public class TradeRecords
    {
        private List<StockTradeRecord> Record = new List<StockTradeRecord>();

        //to mock a database connection, this list has been pre-populated with the provided data
        private List<StockItem> CurrentStockOfferings = new List<StockItem>
        {
            new StockItem("TEA", "COMMON", 0.00m, 0.00m, 100m),
            new StockItem("POP", "COMMON", 8.00m, 0.00m, 100m),
            new StockItem("ALE", "COMMON", 23.00m, 0.00m, 60m),
            new StockItem("GIN", "PREFERRED", 8.00m, 0.02m, 100m),
            new StockItem("JOE", "COMMON", 13.00m, 0.00m, 250m)
        };

        public void ListAllStock()
        {
            foreach (var element in CurrentStockOfferings)
            {
                Console.WriteLine(element.StockSymbol + "   " + element.StockType + "   " 
                    + element.LastDividend + "   " + element.FixedDividend + "   " 
                    + element.ParValue);
            }
        }

        public void CalculateDividendForSpecificStock()
        {
            Console.WriteLine("which stock symbol should the opperation be performed on?");
            var StockSymbolInput = Console.ReadLine();
            if (StockSymbolInput.Length == 3)
            {
                foreach (var element in CurrentStockOfferings)
                {
                    if (StockSymbolInput.ToUpper() == element.StockSymbol)
                    {
                        decimal StockPriceInput;
                        Console.WriteLine("what is the input price?");
                        var price = Console.ReadLine();
                        if(!decimal.TryParse(price, out StockPriceInput))
                        {
                            Console.WriteLine("INCORRECT INPUT, please enter a decimal value");
                            return;
                        }
                        Console.WriteLine("Dividend Yeild for " + element.StockSymbol + 
                            " = " + element.CalculateDividendYeild(StockPriceInput));
                        return;
                    }
                    
                }
                Console.WriteLine("Stock not found");
            }
        }

        public void CalculatePERatioForSpecificStock()
        {
            Console.WriteLine("which stock symbol should the opperation be performed on?");
            var StockSymbolInput = Console.ReadLine();
            if (StockSymbolInput.Length == 3)
            {
                foreach (var element in CurrentStockOfferings)
                {
                    if (StockSymbolInput.ToUpper() == element.StockSymbol)
                    {
                        decimal StockPriceInput;
                        Console.WriteLine("what is the input price?");
                        var price = Console.ReadLine();
                        if (!decimal.TryParse(price, out StockPriceInput))
                        {
                            Console.WriteLine("INCORRECT INPUT, please enter a decimal value");
                            return;
                        }
                        Console.WriteLine("P/E ratio for " + element.StockSymbol +
                            " = " + element.CalculatePERatio(StockPriceInput));
                        return;
                    }

                }
                Console.WriteLine("Stock not found");
            }
        }

        public void AddTrade (string stockSymbol, int quantity, BuyOrSell buyorSell, decimal tradePrice)
        {
            Record.Add(new StockTradeRecord(stockSymbol, quantity, buyorSell, tradePrice));
            Console.WriteLine("Not yet implimented");
        }

        public decimal CalculateVolumeWeightedStockPrice (string stockSymbol)
        {
            var Result = 0.00m;
            Console.WriteLine("Not yet implimented");
            return Result;
        }
    }
}
