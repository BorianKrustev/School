using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvest
{
    class Program
    {
        static void Main(string[] args)
        {
            double lozia = double.Parse(Console.ReadLine());
            double grozde = double.Parse(Console.ReadLine());
            double vinoNeed = double.Parse(Console.ReadLine());
            double worckers = double.Parse(Console.ReadLine());

            grozde *= lozia;
            grozde = grozde * 40 / 100;
            grozde /= 2.5;

            double left = Math.Abs(grozde - vinoNeed);

            if (grozde >= vinoNeed)
            {
                Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(grozde)} liters.");
                Console.WriteLine($"{Math.Ceiling(left)} liters left -> {Math.Ceiling(left / worckers)} liters per person.");
            }
            else
            {
                Console.WriteLine($"It will be a tough winter! More {Math.Floor(left)} liters wine needed.");
            }
        }
    }
}
