using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int lenght = 2 * number - 1;
            int rows = 2 * (number - 2) + 1;

            int toDo = (rows - 1) / 2;
            int outside = lenght - 3;
            for (int i = 1; i <= toDo; i++)
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine($"{new string ('*', outside / 2)}\\ /{new string('*', outside / 2)}");
                }
                else
                {
                    Console.WriteLine($"{new string('-', outside / 2)}\\ /{new string('-', outside / 2)}");
                }
            }

            outside += 2;
            Console.WriteLine($"{new string(' ', outside / 2)}@");
            outside -= 2;

            for (int i = 1; i <= toDo; i++)
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine($"{new string('*', outside / 2)}/ \\{new string('*', outside / 2)}");
                }
                else
                {
                    Console.WriteLine($"{new string('-', outside / 2)}/ \\{new string('-', outside / 2)}");
                }
            }
        }
    }
}
