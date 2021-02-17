using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumSeconds
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());

            double totalSec = a + b + c;
            double min = 0.0;

            if (totalSec >= 60)
            {
                min += 1;
                totalSec -= 60;
            }
            if (totalSec >= 60)
            {
                min += 1;
                totalSec -= 60;
            }
            if (totalSec <= 9)
            {
                Console.WriteLine($"{min}:0{totalSec}");
            }
            else
            {
                Console.WriteLine($"{min}:{totalSec}");
            }

        }
    }
}
