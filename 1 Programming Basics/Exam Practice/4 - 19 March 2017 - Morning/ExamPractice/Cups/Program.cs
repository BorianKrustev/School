using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cups
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal cups = decimal.Parse(Console.ReadLine());
            decimal workers = decimal.Parse(Console.ReadLine());
            decimal days = decimal.Parse(Console.ReadLine());

            workers *= 8;
            days *= workers;
            days = Math.Floor(days / 5);

            decimal mony = Math.Abs(days - cups);
            mony *= 4.2m;

            if (days >= cups)
            {
                Console.WriteLine($"{mony:f2} extra money");
            }
            else
            {
                Console.WriteLine($"Losses: {mony:f2}");
            }
        }
    }
}
