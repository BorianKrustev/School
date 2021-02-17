using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.FibonacciNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());

            if (number <= 1)
            {
                Console.WriteLine($"1");
            }
            else
            {
                Console.WriteLine($"{fib(number)}");
            }
        }

        static long fib (long number)
        {
            long a = 1;
            long b = 1;
            long res = 0;

            for (int i = 1; i < number; i++)
            {
                res = a + b;
                a = b;
                b = res;
            }

            return res;
        }
    }
}
