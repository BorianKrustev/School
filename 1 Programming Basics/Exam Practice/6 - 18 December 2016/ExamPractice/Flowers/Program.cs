using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flowers
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal hrizantini = decimal.Parse(Console.ReadLine());
            decimal rozi = decimal.Parse(Console.ReadLine());
            decimal laleta = decimal.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string seleb = Console.ReadLine();

            decimal pHrizantini = 3.75m;
            decimal pRozi = 4.50m;
            decimal pLaleta = 4.15m;

            if (season == "Spring" || season == "Summer")
            {
                pHrizantini = 2.00m;
                pRozi = 4.10m;
                pLaleta = 2.50m;
            }

            pHrizantini *= hrizantini;
            pRozi *= rozi;
            pLaleta *= laleta;

            decimal all = pHrizantini + pRozi + pLaleta;

            if (seleb == "Y")
            {
                all += all * 15 / 100;
            }
            if (laleta > 7 && season == "Spring")
            {
                all -= all * 5 / 100;
            }
            if (rozi >= 10 && season == "Winter")
            {
                all -= all * 10 / 100;
            }
            if (hrizantini + rozi + laleta > 20)
            {
                all -= all * 20 / 100;
            }

            Console.WriteLine($"{all + 2:f2}");
        }
    }
}
