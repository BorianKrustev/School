using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.TriangleOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                for (int f = 1; f <= i; f++)
                {
                    Console.Write($"{i} ");
                }
                Console.WriteLine($"");
            }
        }
    }
}
