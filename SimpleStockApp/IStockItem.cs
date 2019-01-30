using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleStockApp
{
    interface IStockItem
    {
        string StockSymbol { get; }
        decimal LastDividend { get; }
        decimal FixedDividend { get; }
        decimal ParValue { get; }
        string StockType { get; }

        decimal CalculateDividendYeild(decimal input);
        decimal CalculatePERatio(decimal input);
    }
}
