using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleOfDollars
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                Console.Write("$");
                for (int f = 1; f < i; f++)
                {
                    Console.Write(" $");
                }
                Console.WriteLine();
            }
        }
    }
}
