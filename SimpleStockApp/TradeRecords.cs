using System;
using System.Collections.Generic;

namespace SimpleStockApp
{
    public class TradeRecords
    {
        private const float V = 1f;
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

        public void CalculateVolumeWeightedStockPrice()
        {
            decimal Result = 0.00m;
            int count = 0;
            string stockSymbol = null;
            Console.WriteLine("Which stock symbol would you like to view the Volume Weighted Stock Price for?");
            stockSymbol = Console.ReadLine();
            foreach (var element in Record)
            {
                if (element.StockSymbol == stockSymbol.ToUpper())
                {
                    if (element.TradeTime.AddMinutes(15) >= DateTime.UtcNow)
                    {
                        /*
                         * as we are storing the total price of the trade as it happens and the quantity of the stock sold in that trade
                         * rather than the price paid for each individual stock, we do not need to calculate Tradeprice X Quantity,
                         * as the stored value is already this result.
                         */
                        Result += element.TradePrice;
                        count += element.Quantity;
                    }

                }
            }
            if (Result != 0 && count != 0)
            {
                Result = Result / count;
                Console.WriteLine("Volume Weighted Stock Price based on trades in past 15 minutes = " + Result);
                return;
            }
            Console.WriteLine("Could not match stock symbol with transaction records");
            return;
        }

        public void CalculateGeometricMean()
        {
            /*
             * here the method of storing the total transaction price rather than the price of transaction 
             * comes back to bit us a little, requring us to divide the total transaction price by the quantity
             * of stocks traded to get the individual prices
             * 
             * being unfammiliar with exactly what the GBCE is, i have made the assumption that this will also be 
             * based on the prices of stocks currently on the record as traded, but not limited to a timeframe.
             */
            int individualStockCount = 0;
            if (Record.Count > 0)
            {
                float result = 1f;
                foreach (var element in Record)
                {
                    if (element.TradePrice != 0.00m)
                    {
                        for (int i = 0; i < element.Quantity; i++)
                        {
                            result = result * (float)(element.TradePrice / element.Quantity);
                            individualStockCount++;
                        }
                    }
                }
                float GeometricMean = (float)Math.Pow(result, V / individualStockCount);
                Console.WriteLine("the GBCE All Share Index for all currently recorded transactions is: " + GeometricMean);
                return;
            }

            Console.WriteLine("No records present on which to opperate");
        }
    }//EndOfClass
}
