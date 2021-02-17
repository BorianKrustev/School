using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int lenght = 5 * number;
            int rowls = 3 * number + 2;

            int dots = number * 2;
            int mid = lenght - number * 2;
            Console.WriteLine($"{new string ('.', dots / 2)}{new string('*', mid)}{new string('.', dots / 2)}");

            dots -= 2;
            for (int i = 0; i < number - 1; i++)
            {
                Console.WriteLine($"{new string('.', dots / 2)}*{new string('.', mid)}*{new string('.', dots / 2)}");
                dots -= 2;
                mid += 2;
            }

            Console.WriteLine($"{new string ('*', lenght)}");

            int rowlsLeft = rowls - number - 2;
            dots += 2;
            mid -= 2;
            for (int i = 0; i < rowlsLeft; i++)
            {
                Console.WriteLine($"{new string('.', dots / 2)}*{new string('.', mid)}*{new string('.', dots / 2)}");
                dots += 2;
                mid -= 2;
            }

            Console.WriteLine($"{new string('.', dots / 2)}*{new string('*', mid)}*{new string('.', dots / 2)}");
        }
    }
}
