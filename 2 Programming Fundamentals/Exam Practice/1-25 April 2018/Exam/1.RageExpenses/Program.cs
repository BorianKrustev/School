using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.RageExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal lostGamesCount = decimal.Parse(Console.ReadLine());
            decimal headsetPrice = decimal.Parse(Console.ReadLine());
            decimal mousePrice = decimal.Parse(Console.ReadLine());
            decimal keyboardPrice = decimal.Parse(Console.ReadLine());
            decimal displayPrice = decimal.Parse(Console.ReadLine());

            decimal headsetDestroit = 0;
            decimal mouseDestroit = 0;
            decimal keyboardDestroit = 0;
            decimal displayDestroit = 0;

            for (int i = 1; i <= lostGamesCount; i++)
            {
                if (i % 2 == 0)
                {
                    headsetDestroit += 1;
                }
                if (i % 3 == 0)
                {
                    mouseDestroit += 1;
                }
                if (i % 2 == 0 && i % 3 == 0)
                {
                    keyboardDestroit += 1;
                }
            }

            displayDestroit = Math.Floor(keyboardDestroit / 2);
            decimal totalExpenses = (headsetDestroit * headsetPrice) + (mouseDestroit * mousePrice) + (keyboardDestroit * keyboardPrice) + (displayDestroit * displayPrice);

            Console.WriteLine($"Rage expenses: {totalExpenses:f2} lv.");
        }
    }
}
