﻿using System;
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

            Console.WriteLine("Enter X at any time to Exit.");
            do
            {
                Console.WriteLine("L to list stocks and their data");
                Console.WriteLine("Y to calculate the Dividend Yeild of a specific stock option");
                Console.WriteLine("R to calculate the P/E Ratio of a specific stock option");
                Console.WriteLine("B to buy a quantity of a specific stock option");
                Console.WriteLine("S to sell a quantity of a specific stock option");
                Console.WriteLine("W to calculate the volume weighted stock price for the last 15 minutes");


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
                    Console.WriteLine("Not yet implimented");
                }
                if (result == "S" || result == "s")
                {
                    Console.WriteLine("Not yet implimented");
                }
                if (result == "W" || result == "w")
                {
                    Console.WriteLine("Not yet implimented");
                }
            } while (result != "x" && result != "X");
        }
    }
}