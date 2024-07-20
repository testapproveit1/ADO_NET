using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1C_Sharp_Assign_2___Lab_4___Delegate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArithmeticOperation operation = new ArithmeticOperation();
            ArithmeticDelegate arithmeticDelegate = null;

            Console.WriteLine("Enter first number:");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter second number:");
            int num2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Choose an operation:");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Multiply");
            Console.WriteLine("3. Divide");
            Console.WriteLine("4. Subtract");
            Console.WriteLine("5. Find Max");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    arithmeticDelegate = operation.AddNumbers;
                    break;
                case 2:
                    arithmeticDelegate = operation.MultiplyNumbers;
                    break;
                case 3:
                    arithmeticDelegate = operation.DivideNumbers;
                    break;
                case 4:
                    arithmeticDelegate = operation.SubtractNumbers;
                    break;
                case 5:
                    arithmeticDelegate = operation.FindMaxNumber;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    return;
            }

            // Execute the delegate and get the result
            int result = arithmeticDelegate(num1, num2);
            Console.WriteLine($"Result: {result}");
            Console.ReadLine();
        }
    }
}
