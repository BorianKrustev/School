using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareOfStars
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                Console.Write("*");
                for (int f = 0; f < number - 1; f++)
                {
                    Console.Write(" *");
                }
                Console.WriteLine();
            }
        }
    }
}
