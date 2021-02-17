using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int f1 = 1;
            int f2 = 1;

            if (n < 2)
            {
                Console.WriteLine("1");
            }

            else
            {
                for (int i = 0; i < n - 1; i++)
                {
                    int fNex = f1 + f2;
                    f1 = f2;
                    f2 = fNex;
                }
                Console.WriteLine($"{f2}");
            }
        }
    }
}
