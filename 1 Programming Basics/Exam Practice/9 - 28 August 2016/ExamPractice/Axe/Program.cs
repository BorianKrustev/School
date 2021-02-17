using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axe
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int lenght = 5 * number;

            int left = 3 * number;
            int mid = 0;
            int right = lenght - left - 2;
            for (int i = 0; i < number; i++)
            {
                Console.WriteLine($"{new string ('-', left)}*{new string ('-', mid)}*{new string ('-', right)}");
                mid += 1;
                right -= 1;
            }

            mid -= 1;
            right += 1;
            for (int i = 0; i < number / 2; i++)
            {
                Console.WriteLine($"{new string('*', left)}*{new string('-', mid)}*{new string('-', right)}");
            }

            for (int i = 0; i < number / 2 - 1; i++)
            {
                Console.WriteLine($"{new string('-', left)}*{new string('-', mid)}*{new string('-', right)}");
                mid += 2;
                left -= 1;
                right -= 1;
            }

            Console.WriteLine($"{new string('-', left)}*{new string('*', mid)}*{new string('-', right)}");
        }
    }
}
