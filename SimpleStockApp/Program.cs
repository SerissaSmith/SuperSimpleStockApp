using System;
using System.Collections.Generic;

namespace SimpleStockApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string result;
            ITradeRecords Record = new TradeRecords();


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
                switch(result)
                {
                    case "l":
                    case "L":
                        Record.ListAllStock();
                        break;

                    case "y":
                    case "Y":
                        Record.CalculateDividendForSpecificStock();
                        break;

                    case "r":
                    case "R":
                        Record.CalculatePERatioForSpecificStock();
                        break;

                    case "b":
                    case "B":
                        Record.AddTradePurchase();
                        break;


                    case "s":
                    case "S":
                        Record.AddTradeSale();
                        break;

                    case "w":
                    case "W":
                        Record.CalculateVolumeWeightedStockPrice();
                        break;

                    case "g":
                    case "G":
                        Record.CalculateGeometricMean();
                        break;

                    case "x":
                    case "X":
                        break;

                    default:
                        Console.WriteLine("Unrecognised Command");
                        break;

                }

            } while (result != "x" && result != "X");
        }
    }
}
