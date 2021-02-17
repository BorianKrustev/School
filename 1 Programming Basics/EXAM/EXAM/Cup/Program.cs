using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cup
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int lenght = number * 5;

            int dots = number * 2;
            int mid = lenght - dots;
            for (int i = 0; i < number / 2; i++)
            {
                Console.WriteLine($"{new string ('.', dots / 2)}{new string('#', mid)}{new string('.', dots / 2)}");
                dots += 2;
                mid -= 2;
            }

            mid -= 2;
            for (int i = 0; i < number / 2 + 1; i++)
            {
                Console.WriteLine($"{new string('.', dots / 2)}#{new string('.', mid)}#{new string('.', dots / 2)}");
                dots += 2;
                mid -= 2;
            }

            mid += 4;
            dots -= 2;
            Console.WriteLine($"{new string('.', dots / 2)}{new string('#', mid)}{new string('.', dots / 2)}");

            mid += 4;
            dots -= 4;
            for (int i = 1; i <= number + 2; i++)
            {
                if (i == (number / 2) + 1)
                {
                    int toDo = lenght - 10; 
                    Console.WriteLine($"{new string('.', toDo / 2)}D^A^N^C^E^{new string('.', toDo / 2)}");
                }
                else
                {
                    Console.WriteLine($"{new string('.', dots / 2)}{new string('#', mid)}{new string('.', dots / 2)}");
                }
            }
        }
    }
}
