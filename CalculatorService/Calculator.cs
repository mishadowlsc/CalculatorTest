using System;
using System.Collections.Generic;

namespace CalculatorService
{
    public class Calculator
    {
        private static readonly Operation operation = new Operation();

        public static double Calculate(string sum)
        {
            string[] array = sum.Split(' ');

            Stack<string> numbers = new Stack<string>();
            Stack<string> operators = new Stack<string>();
            double total = 0;

            for (int x = 0; x < array.Length; x++)
            {
                if ((array[x] == "*" || array[x] == "/") && array[x + 1] != "(")
                {
                    numbers.Push(operation.SumOfLeftAndRight(array[x], Convert.ToDouble(numbers.Pop()), Convert.ToDouble(array[x + 1])));
                    x++;
                }
                else if (array[x] == "+" || array[x] == "-" || array[x] == "(" || array[x] == "*" || array[x] == "/")
                {
                    operators.Push(array[x]);
                }
                else if (array[x] == ")")
                {
                    while (operators.Peek() != "(")
                    {
                        numbers.Push(Subtotal(operators, numbers));
                    }
                    operators.Pop(); //pop out "("
                }
                else
                {
                    numbers.Push(array[x]);
                }
            }

            total = Convert.ToDouble(Subtotal(operators, numbers));
            return total;
        }

        private static string Subtotal(Stack<string> operators, Stack<String> numbers)
        {
            Operation operation = new Operation();

            Stack<string> reverseOperators = new Stack<string>();
            Stack<string> reverseNumbers = new Stack<string>();

            while (operators.Count != 0 && operators.Peek() != "(")
            {
                if ((operators.Peek() == "*" || operators.Peek() == "/"))
                {
                    string right = numbers.Pop();
                    numbers.Push(operation.SumOfLeftAndRight(operators.Pop(), Convert.ToDouble(numbers.Pop()), Convert.ToDouble(right)));
                }
                else
                {
                    reverseOperators.Push(operators.Pop());
                    reverseNumbers.Push(numbers.Pop());
                }
            }

            reverseNumbers.Push(numbers.Pop());

            int operatorsCount = reverseOperators.Count;
            for (int y = 0; y < operatorsCount; y++)
            {
                reverseNumbers.Push(operation.SumOfLeftAndRight(reverseOperators.Pop(), Convert.ToDouble(reverseNumbers.Pop()), Convert.ToDouble(reverseNumbers.Pop())));
            }

            return reverseNumbers.Pop();
        }
    }
}
