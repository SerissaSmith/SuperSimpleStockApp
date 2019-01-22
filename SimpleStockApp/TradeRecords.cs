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

        public void AddTradePurchase()
        {
            string stockSymbol = null;
            int quantity = 0;
            BuyOrSell buyorSell = BuyOrSell.Buy;
            decimal tradePrice = 0.00m;

            Console.WriteLine("Which stock symbol would you like to purchase?");
            stockSymbol = Console.ReadLine();
            foreach (var element in CurrentStockOfferings)
            {
                if (element.StockSymbol == stockSymbol.ToUpper())
                {
                    Console.WriteLine("how many of the stock would you like to purchase?");
                    var buffer = Console.ReadLine();
                    if (!int.TryParse(buffer, out quantity))
                    {
                        Console.WriteLine("INCORRECT INPUT, please enter a integer value greater than 0");
                        return;
                    }
                    if (quantity <= 0)
                    {
                        Console.WriteLine("INCORRECT INPUT, please enter a integer value greater than 0");
                        return;
                    }

                    //aware that there would be price checking of some type here, but not sure what would be required.
                    Console.WriteLine("what price would you like to pay for the total of this trade?");
                    var buffer1 = Console.ReadLine();
                    if (!decimal.TryParse(buffer1, out tradePrice))
                    {
                        Console.WriteLine("INCORRECT INPUT, please enter a decimal value greater than 0.00");
                        return;
                    }
                    if (tradePrice <= 0.00m)
                    {
                        Console.WriteLine("INCORRECT INPUT, please enter a decimal value greater than 0.00");
                        return;
                    }
                    Record.Add(new StockTradeRecord(stockSymbol, quantity, buyorSell, tradePrice));
                    return;
                }
            }
            Console.WriteLine("Could not match stock symbol");
            return;
        }

        public void AddTradeSale()
        {
            string stockSymbol = null;
            int quantity = 0;
            BuyOrSell buyorSell = BuyOrSell.Sell;
            decimal tradePrice = 0.00m;

            Console.WriteLine("Which stock symbol would you like to Sell?");
            stockSymbol = Console.ReadLine();
            foreach (var element in CurrentStockOfferings)
            {
                if (element.StockSymbol == stockSymbol.ToUpper())
                {
                    Console.WriteLine("how many of the stock would you like to Sell?");
                    var buffer = Console.ReadLine();
                    if (!int.TryParse(buffer, out quantity))
                    {
                        Console.WriteLine("INCORRECT INPUT, please enter a integer value greater than 0");
                        return;
                    }
                    if (quantity <= 0)
                    {
                        Console.WriteLine("INCORRECT INPUT, please enter a integer value greater than 0");
                        return;
                    }

                    //aware that there would be price checking of some type here, but not sure what would be required.
                    Console.WriteLine("what price would you like to charge for the total of this trade?");
                    var buffer1 = Console.ReadLine();
                    if (!decimal.TryParse(buffer1, out tradePrice))
                    {
                        Console.WriteLine("INCORRECT INPUT, please enter a decimal value greater than 0.00");
                        return;
                    }
                    if (tradePrice <= 0.00m)
                    {
                        Console.WriteLine("INCORRECT INPUT, please enter a decimal value greater than 0.00");
                        return;
                    }
                    Record.Add(new StockTradeRecord(stockSymbol, quantity, buyorSell, tradePrice));
                    return;
                }
            }
            Console.WriteLine("Could not match stock symbol");
            return;
        }

        public decimal CalculateVolumeWeightedStockPrice (string stockSymbol)
        {
            var Result = 0.00m;
            Console.WriteLine("Not yet implimented");
            return Result;
        }
    }
}
