using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal bitcoin = decimal.Parse(Console.ReadLine());
            decimal ioni = decimal.Parse(Console.ReadLine());
            decimal comison = decimal.Parse(Console.ReadLine());

            bitcoin *= 1168;
            ioni *= 0.15m;
            ioni *= 1.76m;

            decimal all = (ioni + bitcoin) / 1.95m;
            all = all - (all * comison / 100);

            Console.WriteLine($"{all:f2}");
        }
    }
}
