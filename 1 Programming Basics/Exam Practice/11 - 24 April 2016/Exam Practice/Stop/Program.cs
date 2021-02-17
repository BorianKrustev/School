using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stop
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int dots = number + 1;
            int mid = number * 2 + 1;
            Console.WriteLine($"{new string ('.', dots)}{new string('_', mid)}{new string('.', dots)}");

            dots -= 1;
            mid -= 2;
            for (int i = 0; i < number; i++)
            {
                Console.WriteLine($"{new string('.', dots)}//{new string('_', mid)}\\\\{new string('.', dots)}");
                dots -= 1;
                mid += 2;
            }

            mid -= 5;
            Console.WriteLine($"{new string('.', dots)}//{new string('_', mid / 2)}STOP!{new string('_', mid / 2)}\\\\{new string('.', dots)}");

            mid += 5;
            for (int i = 0; i < number; i++)
            {
                Console.WriteLine($"{new string('.', dots)}\\\\{new string('_', mid)}//{new string('.', dots)}");
                dots += 1;
                mid -= 2;
            }
        }
    }
}
