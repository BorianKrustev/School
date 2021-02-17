using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fox
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int lenght = 2 * number + 3;

            int stars = 2;
            int mid = lenght - 4;
            for (int i = 0; i < number; i++)
            {
                Console.WriteLine($"{new string ('*', stars / 2)}\\{new string ('-', mid)}/{new string('*', stars / 2)}");
                stars += 2;
                mid -= 2;
            }

            mid = number;
            stars = lenght - number - 4;
            for (int i = 0; i < number / 3; i++)
            {
                Console.WriteLine($"|{new string ('*', stars / 2)}\\{new string ('*', mid)}/{new string('*', stars / 2)}|");
                stars += 2;
                mid -= 2;
            }

            stars = 2;
            mid = lenght - stars - 2;
            for (int i = 0; i < number; i++)
            {
                Console.WriteLine($"{new string('-', stars / 2)}\\{new string('*', mid)}/{new string('-', stars / 2)}");
                stars += 2;
                mid -= 2;
            }
        }
    }
}
