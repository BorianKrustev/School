using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rocket
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int lenght = 3 * number;

            int mid = 0;
            int dots = lenght - 2;
            for (int i = 0; i < number; i++)
            {
                Console.WriteLine($"{new string ('.', dots / 2)}/{new string (' ', mid)}\\{new string('.', dots / 2)}");
                dots -= 2;
                mid += 2;
            }

            dots += 2;
            Console.WriteLine($"{new string('.', dots / 2)}{new string('*', mid)}{new string('.', dots / 2)}");

            mid -= 2;
            for (int i = 0; i < number * 2; i++)
            {
                Console.WriteLine($"{new string('.', dots / 2)}|{new string('\\', mid)}|{new string('.', dots / 2)}");
            }

            for (int i = 0; i < number / 2; i++)
            {
                Console.WriteLine($"{new string('.', dots / 2)}/{new string('*', mid)}\\{new string('.', dots / 2)}");
                dots -= 2;
                mid += 2;
            }
        }
    }
}
