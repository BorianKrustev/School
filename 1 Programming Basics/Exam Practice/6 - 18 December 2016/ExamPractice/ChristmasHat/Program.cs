using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristmasHat
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int lenght = 4 * number + 1;
            int rowls = 2 * number + 5;

            int dots = lenght - 3;
            Console.WriteLine($"{new string ('.', dots / 2)}/|\\{new string('.', dots / 2)}");
            Console.WriteLine($"{new string ('.', dots / 2)}\\|/{new string('.', dots / 2)}");
            Console.WriteLine($"{new string('.', dots / 2)}***{new string('.', dots / 2)}");

            int mid = 2;
            dots = lenght - 3 - 2;
            for (int i = 0; i < rowls - 6; i++)
            {
                Console.WriteLine($"{new string('.', dots / 2)}*{new string ('-', mid / 2)}*{new string('-', mid / 2)}*{new string('.', dots / 2)}");
                mid += 2;
                dots -= 2;
            }

            Console.WriteLine($"{new string ('*', lenght)}");

            for (int i = 0; i < lenght / 2; i++)
            {
                Console.Write("*.");
            }
            Console.WriteLine("*");

            Console.WriteLine($"{new string('*', lenght)}");
        }
    }
}
