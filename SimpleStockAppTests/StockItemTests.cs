using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleStockApp;
namespace SuperSimpleStockAppTests
{
    [TestClass]
    public class StockItemTests
    {
        [TestMethod]
        public void CreateStockItem_NoValuesProvided_CreatesBlankStockItem()
        {
            var itemUnderTest = new StockItem();

            Assert.AreEqual (null, itemUnderTest.StockSymbol);
            Assert.AreEqual ("Common", itemUnderTest.StockType);
            Assert.AreEqual (0.00m, itemUnderTest.FixedDividend);
            Assert.AreEqual (0.00m, itemUnderTest.LastDividend);
            Assert.AreEqual (0.00m, itemUnderTest.ParValue);
        }
        [TestMethod]
        public void CreateStockItem_ValuesProvided_CreatesExpectedStockItem()
        {
            var itemUnderTest = new StockItem("TST", "Preferred", 1.00m, 0.01m, 1000m);

            Assert.AreEqual ("TST", itemUnderTest.StockSymbol);
            Assert.AreEqual ("Preferred", itemUnderTest.StockType);
            Assert.AreEqual (0.01m, itemUnderTest.FixedDividend);
            Assert.AreEqual (1.00m, itemUnderTest.LastDividend);
            Assert.AreEqual (1000.00m, itemUnderTest.ParValue);
        }
        [TestMethod]
        public void CreateStockItem_LowerCaseStockSymbolProvided_CreatesExpectedStockItemWithStockItemConvertedToUpper()
        {
            var itemUnderTest = new StockItem("tst", "Preferred", 1.00m, 0.01m, 1000m);

            Assert.AreEqual("TST", itemUnderTest.StockSymbol);
            Assert.AreEqual("Preferred", itemUnderTest.StockType);
            Assert.AreEqual(0.01m, itemUnderTest.FixedDividend);
            Assert.AreEqual(1.00m, itemUnderTest.LastDividend);
            Assert.AreEqual(1000.00m, itemUnderTest.ParValue);
        }
        [TestMethod]
        public void CreateStockItem_LowerCaseStockTypeProvided_CreatesExpectedStockItemWithStockTypeConverted()
        {
            var itemUnderTest = new StockItem("TST", "preferred", 1.00m, 0.01m, 1000m);

            Assert.AreEqual("TST", itemUnderTest.StockSymbol);
            Assert.AreEqual("Preferred", itemUnderTest.StockType);
            Assert.AreEqual(0.01m, itemUnderTest.FixedDividend);
            Assert.AreEqual(1.00m, itemUnderTest.LastDividend);
            Assert.AreEqual(1000.00m, itemUnderTest.ParValue);
        }
        [TestMethod]
        public void CreateStockItem_UpperCaseStockTypeProvided_CreatesExpectedStockItemWithStockTypeConverted()
        {
            var itemUnderTest = new StockItem("TST", "PREFERRED", 1.00m, 0.01m, 1000m);

            Assert.AreEqual("TST", itemUnderTest.StockSymbol);
            Assert.AreEqual("Preferred", itemUnderTest.StockType);
            Assert.AreEqual(0.01m, itemUnderTest.FixedDividend);
            Assert.AreEqual(1.00m, itemUnderTest.LastDividend);
            Assert.AreEqual(1000.00m, itemUnderTest.ParValue);
        }
        [TestMethod]
        public void CalculateDividendYeildOnCommonStock_NoZeroValuesProvided_Returns1()
        {
            var itemUnderTest = new StockItem("TST", "COMMON", 1.00m, 0.01m, 1000m);
            var result = itemUnderTest.CalculateDividendYeild(1.00m);
            Assert.AreEqual(1.00m, result);
        }
        [TestMethod]
        public void CalculateDividendYeildOnCommonStock_ZeroinputProvided_Returns0()
        {
            var itemUnderTest = new StockItem("TST", "COMMON", 1.00m, 0.01m, 1000m);

            var result = itemUnderTest.CalculateDividendYeild(0.00m); // potential /0 error

            Assert.AreEqual(0.00m, result);
        }
        [TestMethod]
        public void CalculateDividendYeildOnPreferredStock_NoZeroValuesProvided_Returns2()
        {
            var itemUnderTest = new StockItem("TST", "PREFERRED", 1.00m, 0.02m, 100m);
            var result = itemUnderTest.CalculateDividendYeild(1.00m);
            Assert.AreEqual(2.00m, result);
        }
        [TestMethod]
        public void CalculateDividendYeildOnPreferredStock_ZeroinputProvided_Returns0()
        {
            var itemUnderTest = new StockItem("TST", "PREFERRED", 1.00m, 0.02m, 100m);

            var result = itemUnderTest.CalculateDividendYeild(0.00m); // potential /0 error

            Assert.AreEqual(0.00m, result);
        }
    }
}
