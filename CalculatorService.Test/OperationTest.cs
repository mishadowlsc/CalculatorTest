using NUnit.Framework;

namespace CalculatorService.Test
{
    class OperationTest
    {
        [TestCase("+", 1, 1, "2")]
        [TestCase("-", 1, 1, "0")]
        [TestCase("*", 2, 2, "4")]
        [TestCase("/", 4, 2, "2")]
        public void SumOfLeftAndRight_ShouldReturnCorrectResult(string symbol, double left, double right, string expected)
        {
            Operation operation = new Operation();
            string result = operation.SumOfLeftAndRight(symbol, left, right);
            Assert.AreEqual(result, expected, $"{left}{symbol}{right} should return {expected}");
        }
    }
}
