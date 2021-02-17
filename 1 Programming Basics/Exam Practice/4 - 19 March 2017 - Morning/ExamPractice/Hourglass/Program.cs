using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hourglass
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int lenght = 2 * number + 1;
            int rowls = 2 * number + 1;

            Console.WriteLine($"{new string ('*', lenght)}");
            Console.WriteLine($".*{new string (' ', lenght - 4)}*.");

            int toDo = (lenght - 5);
            int dots = 4;
            int mid = lenght - 2 - dots;
            for (int i = 0; i < toDo / 2; i++)
            {
                Console.WriteLine($"{new string ('.', dots / 2)}*{new string ('@', mid)}*{new string('.', dots / 2)}");
                dots += 2;
                mid -= 2;
            }

            Console.WriteLine($"{new string('.', dots / 2)}*{new string('.', dots / 2)}");

            dots -= 1;
            mid += 2;
            int spase = 0;
            for (int i = 0; i < toDo / 2; i++)
            {
                Console.WriteLine($"{new string('.', dots / 2)}*{new string (' ', spase)}{new string('@', mid)}{new string(' ', spase)}*{new string('.', dots / 2)}");
                spase += 1;
                dots -= 2;
            }

            Console.WriteLine($".*{new string('@', lenght - 4)}*.");
            Console.WriteLine($"{new string('*', lenght)}");
        }
    }
}
