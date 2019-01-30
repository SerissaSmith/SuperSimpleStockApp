using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleStockApp
{
    interface IStockTradeRecord
    {
        string StockSymbol { get; }
        int Quantity { get; }
        DateTime TradeTime { get; }
        BuyOrSell BuyOrSell { get; }
        decimal TradePrice { get; }
    }
}
