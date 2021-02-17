using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRace
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal mladshi = decimal.Parse(Console.ReadLine());
            decimal starshi = decimal.Parse(Console.ReadLine());
            string track = Console.ReadLine();

            decimal allRiders = mladshi + starshi;
            decimal pMladshi = 0;
            decimal pStarshi = 0;

            if (track == "trail")
            {
                pMladshi = 5.50m;
                pStarshi = 7m;
            }
            else if (track == "cross-country")
            {
                pMladshi = 8m;
                pStarshi = 9.50m;
            }
            else if (track == "downhill")
            {
                pMladshi = 12.25m;
                pStarshi = 13.75m;
            }
            else
            {
                pMladshi = 20m;
                pStarshi = 21.50m;
            }

            pMladshi *= mladshi;
            pStarshi *= starshi;
            decimal allMony = pMladshi + pStarshi;

            if (allRiders >= 50 && track == "cross-country")
            {
                allMony -= allMony * 25 / 100;
            }

            allMony -= allMony * 5 / 100;

            Console.WriteLine($"{allMony:f2}");
        }
    }
}
