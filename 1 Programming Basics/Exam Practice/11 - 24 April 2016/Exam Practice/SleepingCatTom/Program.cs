using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepingCatTom
{
    class Program
    {
        static void Main(string[] args)
        {
            double daysOff = double.Parse(Console.ReadLine());

            double worckDays = 365 - daysOff;
            worckDays *= 63;
            daysOff *= 127;
            double all = worckDays + daysOff;
            double tMin = Math.Abs(all - 30000);
            int houers = (int)tMin / 60;
            double min = Math.Abs(houers * 60 - tMin);

            if (all > 30000 )
            {
                Console.WriteLine($"Tom will run away");
                Console.WriteLine($"{houers} hours and {min} minutes more for play");
            }
            else
            {
                Console.WriteLine($"Tom sleeps well");
                Console.WriteLine($"{houers} hours and {min} minutes less for play");
            }
        }
    }
}
