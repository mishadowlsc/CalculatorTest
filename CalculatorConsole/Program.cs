using CalculatorService;
using System;

namespace CalculatorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string input = "";
                Console.WriteLine("Key in \"EXIT\" to exit\n");
                while (input.ToLower() != "exit")
                {
                    Console.WriteLine("Please enter mathematical expression: ");
                    input = Console.ReadLine();

                    if (input.ToLower() == "exit")
                    {
                        return;
                    }
                    Console.WriteLine("Result: {0}\n", Calculator.Calculate(input));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid mathematical expression.");
                Console.ReadKey();
            }
        }
    }
}
