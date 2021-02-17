using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SborNaProizvedeni
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int tes = 0;
            for (int a = 1; a <= 30; a++)
            {
                for (int b = 1; b <= 30; b++)
                {
                    for (int c = 1; c <= 30; c++)
                    {
                        if (a + b + c == number && a < b && b < c)
                        {
                            Console.WriteLine($"{a} + {b} + {c} = {number}");
                            tes += 1;
                        }
                        if (a * b * c == number && a > b && b > c)
                        {
                            Console.WriteLine($"{a} * {b} * {c} = {number}");
                            tes += 1;
                        }
                    }
                }
            }
            if (tes == 0)
            {
                Console.WriteLine("No!");
            }
        }
    }
}
