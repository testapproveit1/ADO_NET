using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_HOL_Part_1___LAB_2___Q2___BUGS
{
    public class Shape
    {
        public virtual void WhoamI()
        {
            Console.WriteLine("I'm Shape");
        }
    }

    public class Triangle : Shape
    {
        public override void WhoamI()
        {
            Console.WriteLine("I'm Triangle");
        }
    }

    public class Circle : Shape
    {
        public override void WhoamI()
        {
            Console.WriteLine("I'm Circle");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Shape s;

            // Create Triangle object and call overridden WhoamI method
            s = new Triangle();
            s.WhoamI();

            // Create Circle object and call overridden WhoamI method
            s = new Circle();
            s.WhoamI();

            Console.ReadKey();
        }
    }
}
