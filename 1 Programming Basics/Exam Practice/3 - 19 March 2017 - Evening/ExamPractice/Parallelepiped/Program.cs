using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallelepiped
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int lenght = 3 * number + 1;
            int rows = 4 * number + 4;

            int dots = number * 2 + 1;
            int mid = lenght - dots - 2;
            Console.WriteLine($"+{new string ('~', mid)}+{new string ('.', dots)}");
            dots -= 1;

            int sical = (rows - 2) / 2;
            int dotsLeft = lenght - dots - mid - 3;
            for (int i = 0; i < sical; i++)
            {
                Console.WriteLine($"|{new string ('.', dotsLeft)}\\{new string ('~', mid)}\\{new string ('.', dots)}");
                dotsLeft += 1;
                dots -= 1;
            }

            dotsLeft -= 1;
            dots += 1;
            for (int i = 0; i < sical; i++)
            {
                Console.WriteLine($"{new string ('.', dots)}\\{new string ('.' , dotsLeft)}|{new string ('~', mid)}|");
                dots += 1;
                dotsLeft -= 1;
            }

            Console.WriteLine($"{new string ('.', dots)}+{new string ('~', mid)}+");
        }
    }
}
