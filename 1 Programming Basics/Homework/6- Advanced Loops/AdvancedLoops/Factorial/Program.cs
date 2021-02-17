using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int mul = 0;
            int final = number;

            for (int i = 1; i < number; i++)
            {
                mul += 1;
                final = final * mul;
            }
            Console.WriteLine(final);
        }
    }
}
