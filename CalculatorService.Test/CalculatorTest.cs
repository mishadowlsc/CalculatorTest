using NUnit.Framework;

namespace CalculatorService.Test
{
    public class CalculatorTest
    {
        [TestCase("1 + 1", 2)]
        [TestCase("2 * 2", 4)]
        [TestCase("1 + 2 + 3", 6)]
        [TestCase("6 / 2", 3)]
        [TestCase("11 + 23", 34)]
        [TestCase("11.1 + 23", 34.1)]
        [TestCase("1 + 1 * 3", 4)]
        [TestCase("( 11.5 + 15.4 ) + 10.1", 37)]
        [TestCase("23 - ( 29.3 - 12.5 )", 6.2)]
        [TestCase("( 1 / 2 ) - 1 + 1", 0.5)]
        [TestCase("10 - ( 2 + 3 * ( 7 - 5 ) )", 2)]
        public void Calculate_ShouldReturnCorrectResult(string sum, double expected)
        {
            double result = Calculator.Calculate(sum);
            Assert.AreEqual(result, expected, $"{sum} should return {expected}");
        }
    }
}