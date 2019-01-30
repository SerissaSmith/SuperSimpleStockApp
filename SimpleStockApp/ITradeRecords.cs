using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleStockApp
{
    interface ITradeRecords
    {
        void ListAllStock();
        void CalculateDividendForSpecificStock();
        void CalculatePERatioForSpecificStock();
        void AddTradePurchase();
        void AddTradeSale();
        void CalculateVolumeWeightedStockPrice();
        void CalculateGeometricMean();
    }
}
