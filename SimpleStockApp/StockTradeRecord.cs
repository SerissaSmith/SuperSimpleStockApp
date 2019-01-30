using System;

namespace SimpleStockApp
{
    public class StockTradeRecord : IStockTradeRecord
    {
        public string StockSymbol { get; private set; }
        public int Quantity { get; private set; }
        public DateTime TradeTime { get; private set; }
        public BuyOrSell BuyOrSell { get; private set; }
        public decimal TradePrice { get; private set; }

        public StockTradeRecord (string stockSymbol = null, int quantity = 0, BuyOrSell buyOrSell = BuyOrSell.Buy, decimal tradePrice = 0)
        {
            if(stockSymbol.Length == 3)
            {
                StockSymbol = stockSymbol.ToUpper();
            }
            Quantity = quantity;
            BuyOrSell = buyOrSell;
            TradePrice = tradePrice;
            TradeTime = DateTime.UtcNow;
        }
    }
}

public enum BuyOrSell
{
    Sell = 0,
    Buy
}
