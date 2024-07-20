using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1C_Sharp_Assign_2___Lab_4___Delegate
{
    public delegate int ArithmeticDelegate(int num1, int num2);

    internal class ArithmeticOperation
    {
        public int AddNumbers(int num1, int num2)
        {
            return num1 + num2;
        }

        public int MultiplyNumbers(int num1, int num2)
        {
            return num1 * num2;
        }

        public int DivideNumbers(int num1, int num2)
        {
            if (num2 != 0)
                return num1 / num2;
            else
                throw new ArgumentException("Division by zero error.");
        }

        public int SubtractNumbers(int num1, int num2)
        {
            return num1 - num2;
        }

        public int FindMaxNumber(int num1, int num2)
        {
            return Math.Max(num1, num2);
        }
    }
}
