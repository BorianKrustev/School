using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniLogo
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int lenght = 12 * number - 5;
            int rowls = 4 * number - 2;

            int mid = 1;
            int dots = lenght - 1;
            for (int i = 0; i < number * 2; i++)
            {
                Console.WriteLine($"{new string ('.', dots / 2)}{new string ('#', mid)}{new string('.', dots / 2)}");
                dots -= 6;
                mid += 6;
            }

            int leftDots = 2;
            int rightDots = 3;
            mid = lenght - leftDots - rightDots - 1;
            int toDo = rowls - (number * 2) - number;
            for (int i = 0; i < toDo; i++)
            {
                Console.WriteLine($"|{new string ('.', leftDots)}{new string ('#', mid)}{new string ('.', rightDots)}");
                leftDots += 3;
                rightDots += 3;
                mid -= 6;
            }

            for (int i = 0; i < number - 1; i++)
            {
                Console.WriteLine($"|{new string('.', leftDots)}{new string('#', mid)}{new string('.', rightDots)}");
            }

            Console.WriteLine($"@{new string('.', leftDots)}{new string('#', mid)}{new string('.', rightDots)}");
        }
    }
}
