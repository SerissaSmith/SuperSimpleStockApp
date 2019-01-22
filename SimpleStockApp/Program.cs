using System;
using System.Collections.Generic;

namespace SimpleStockApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string result;
            TradeRecords Record = new TradeRecords();


            Console.WriteLine("Welcome to the Super Simple Stock App");

            Console.WriteLine("Enter X to Exit.");
            do
            {
                Console.WriteLine("L to list stocks and their data");
                Console.WriteLine("Y to calculate the Dividend Yeild of a specific stock option");
                Console.WriteLine("R to calculate the P/E Ratio of a specific stock option");
                Console.WriteLine("B to buy a quantity of a specific stock option");
                Console.WriteLine("S to sell a quantity of a specific stock option");
                Console.WriteLine("W to calculate the volume weighted stock price for the last 15 minutes on a specific stock option");
                Console.WriteLine("G to calculate the GBCE All Share Index on all recorded stock trade");


                result = Console.ReadLine();
                if (result == "L" || result == "l")
                {
                    Record.ListAllStock();
                }

                if (result == "Y" || result == "y")
                {
                    Record.CalculateDividendForSpecificStock();
                }

                if (result == "R" || result == "r")
                {
                    Record.CalculatePERatioForSpecificStock();
                }

                if (result == "B" || result == "b")
                {
                    Record.AddTradePurchase();
                }

                if (result == "S" || result == "s")
                {
                    Record.AddTradeSale();
                }

                if (result == "W" || result == "w")
                {
                    Record.CalculateVolumeWeightedStockPrice();
                }

                if (result == "G" || result == "g")
                {
                    Record.CalculateGeometricMean();
                }

            } while (result != "x" && result != "X");
        }
    }
}
