using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangl
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int rowLengt = (4 * number) + 1;
            int rows = (2 * number) + 1;

            Console.WriteLine($"{new string ('#', rowLengt)}");

            int dots = 2;
            int spase = 1;
            int hastag = 0;

            for (int i = 1; i <= number; i++)
            {
                if (i == number / 2 + 1)
                {
                    hastag = rowLengt - dots - spase;
                    spase -= 3;
                    Console.WriteLine($"{new string('.', dots / 2)}{new string('#', hastag / 2)}{new string(' ', spase / 2)}(@){new string(' ', spase / 2)}{new string('#', hastag / 2)}{new string('.', dots / 2)}");
                    dots += 2;
                    spase += 5;
                }
                else
                {
                    hastag = rowLengt - dots - spase;
                    Console.WriteLine($"{new string('.', dots / 2)}{new string('#', hastag / 2)}{new string(' ', spase)}{new string('#', hastag / 2)}{new string('.', dots / 2)}");
                    dots += 2;
                    spase += 2;
                }
            }

            spase -= 2;
            for (int i = 1; i <= number; i++)
            {
                Console.WriteLine($"{new string ('.', dots / 2)}{new string ('#', spase)}{new string('.', dots / 2)}");
                dots += 2;
                spase -= 2;
            }
        }
    }
}
