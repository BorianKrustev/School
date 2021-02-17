using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.GeometryCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();
            double a = double.Parse(Console.ReadLine());

            double resout = 0;
            if (figure == "triangle") resout = triangle(a);
            if (figure == "square") resout = square(a);
            if (figure == "rectangle") resout = rectangle(a);
            if (figure == "circle") resout = circle(a);

            Console.WriteLine($"{resout:f2}");
        }

        static double triangle (double a)
        {
            double b = double.Parse(Console.ReadLine());
            double resout = (a * b) / 2;
            return resout;
        }

        static double square (double a)
        {
            double resout = a * a;
            return resout;
        }

        static double rectangle (double a)
        {
            double b = double.Parse(Console.ReadLine());
            double resout = a * b;
            return resout;
        }

        static double circle (double a)
        {
            double resout = Math.PI * (a * a);
            return resout;
        }
    }
}
