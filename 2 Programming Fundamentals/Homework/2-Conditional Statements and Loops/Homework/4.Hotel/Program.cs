using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Hotel
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            decimal nightCount = int.Parse(Console.ReadLine());

            decimal studio = 0;
            decimal doublee = 0;
            decimal suite = 0;
            decimal priseStudio = 0;
            decimal priseDoublee = 0;
            decimal prisesuite = 0;

            if (month == "May" || month == "October")
            {
                studio = 50;
                doublee = 65;
                suite = 75;

                if (nightCount > 7)
                {
                    studio -= studio * 5 / 100;
                }
                decimal discountForOneNight = studio;

                priseStudio = nightCount * studio;
                priseDoublee = nightCount * doublee;
                prisesuite = nightCount * suite;

                if (nightCount > 7 && month == "October")
                {
                    priseStudio -= discountForOneNight;
                }
            }
            else if (month == "June" || month == "September")
            {
                studio = 60;
                doublee = 72;
                suite = 82;
                decimal discountForOneNight = studio;

                if (nightCount > 14)
                {
                    doublee -= doublee * 10 / 100;
                }

                priseStudio = nightCount * studio;
                priseDoublee = nightCount * doublee;
                prisesuite = nightCount * suite;

                if (nightCount > 7 && month == "September")
                {
                    priseStudio -= discountForOneNight;
                }
            }
            else
            {
                studio = 68;
                doublee = 77;
                suite = 89;

                if (nightCount > 14)
                {
                    suite -= suite * 15 / 100;
                }

                priseStudio = nightCount * studio;
                priseDoublee = nightCount * doublee;
                prisesuite = nightCount * suite;
            }

            Console.WriteLine($"Studio: {priseStudio:f2} lv.");
            Console.WriteLine($"Double: {priseDoublee:f2} lv.");
            Console.WriteLine($"Suite: {prisesuite:f2} lv.");
        }
    }
}