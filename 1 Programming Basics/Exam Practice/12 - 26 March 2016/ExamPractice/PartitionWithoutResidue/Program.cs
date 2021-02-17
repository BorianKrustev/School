using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartitionWithoutResidue
{
    class Program
    {
        static void Main(string[] args)
        {
            double spin = double.Parse(Console.ReadLine());

            double p1 = 0;
            double p2 = 0;
            double p3 = 0;

            for (int i = 1; i <= spin; i++)
            {
                double number = double.Parse(Console.ReadLine());

                if (number % 2 == 0)
                {
                    p1 += 1;
                }
                if (number % 3 == 0)
                {
                    p2 += 1;
                }
                if (number % 4 == 0)
                {
                    p3 += 1;
                }
            }

            p1 = p1 / spin * 100;
            p2 = p2 / spin * 100;
            p3 = p3 / spin * 100;

            Console.WriteLine($"{p1:f2}%");
            Console.WriteLine($"{p2:f2}%");
            Console.WriteLine($"{p3:f2}%");
        }
    }
}
