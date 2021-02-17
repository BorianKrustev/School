using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crown
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int lenght = 2 * number - 1;
            int rows = number / 2 + 4;

            lenght -= 3;
            Console.WriteLine($"@{new string (' ', lenght / 2)}@{new string(' ', lenght / 2)}@");

            lenght -= 2;
            Console.WriteLine($"**{new string(' ', lenght / 2)}*{new string(' ', lenght / 2)}**");

            lenght += 5;
            int dots = 2;
            int midDots = 1;
            int spase = spase = lenght - dots - midDots - 6; ;
            for (int i = 1; i <= rows - 6; i++)
            {
                Console.WriteLine($"*{new string ('.', dots / 2)}*{new string (' ', spase / 2)}*{new string ('.', midDots)}*{new string(' ', spase / 2)}*{new string('.', dots / 2)}*");
                dots += 2;
                midDots += 2;
                spase -= 4;
            }

            Console.WriteLine($"*{new string ('.', dots / 2)}*{new string ('.', midDots)}*{new string('.', dots / 2)}*");

            dots += 2;
            int midStars = lenght - 3 - dots;
            Console.WriteLine($"*{new string ('.', dots / 2)}{new string ('*', midDots / 2)}.{new string('*', midDots / 2)}{new string('.', dots / 2)}*");

            Console.WriteLine($"{new string ('*', lenght)}");
            Console.WriteLine($"{new string('*', lenght)}");
        }
    }
}
