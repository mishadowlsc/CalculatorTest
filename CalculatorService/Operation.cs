namespace CalculatorService
{
    public class Operation
    {
        private double Add(double left, double right)
        {
            return (double)(decimal)(left + right);
        }

        private double Minus(double left, double right)
        {
            return (double)(decimal)(left - right);
        }

        private double Times(double left, double right)
        {
            return (double)(decimal)(left * right);
        }

        private double Divide(double left, double right)
        {
            return (double)(decimal)(left / right);
        }

        public string SumOfLeftAndRight(string symbol, double left, double right)
        {
            double total = 0;
            switch (symbol)
            {
                case "+":
                    total = Add(left, right);
                    break;
                case "-":
                    total = Minus(left, right);
                    break;
                case "*":
                    total = Times(left, right);
                    break;
                case "/":
                    total = Divide(left, right);
                    break;

            }
            return total.ToString();
        }
    }
}
