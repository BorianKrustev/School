using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int stars = 1;
            if (number % 2 == 0)
            {
                stars += 1;
            }
            int line = number - stars;

            for (int i = 0; i < number / 2; i++)
            {
                Console.WriteLine($"{new string ('-', line / 2)}{new string ('*', stars)}{new string('-', line / 2)}");
                stars += 2;
                line -= 2;
            }

            if (number % 2 != 0)
            {
                Console.WriteLine($"{new string ('*', number)}");
            }

            for (int i = 0; i < number / 2; i++)
            {
                Console.WriteLine($"|{new string ('*', number -2)}|");
            }
        }
    }
}
