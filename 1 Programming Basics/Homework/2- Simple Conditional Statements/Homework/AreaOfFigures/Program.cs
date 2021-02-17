using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaOfFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            string fig = Console.ReadLine();

            double a = 0;
            double b = 0;

            bool square = fig == "square";
            bool rectangle = fig == "rectangle";
            bool circle = fig == "circle";
            bool triangle = fig == "triangle";

            if (square)
            {
                a = double.Parse (Console.ReadLine());
                Console.WriteLine(a * a);
            }
            else if (rectangle)
            {
                a = double.Parse(Console.ReadLine());
                b = double.Parse(Console.ReadLine());
                Console.WriteLine(a * b);
            }
            else if (circle)
            {
                a =double.Parse (Console.ReadLine());
                Console.WriteLine(Math.PI * (a * a));
            }
            else if (triangle)
            {
                a = double.Parse(Console.ReadLine());
                b = double.Parse(Console.ReadLine());
                Console.WriteLine((double)1 / 2 * a * b);
            }
        }
    }
}
