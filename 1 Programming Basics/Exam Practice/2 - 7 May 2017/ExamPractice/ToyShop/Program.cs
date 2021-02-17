using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal prise = decimal.Parse(Console.ReadLine());
            decimal pazel = decimal.Parse(Console.ReadLine());
            decimal kykla = decimal.Parse(Console.ReadLine());
            decimal me4e = decimal.Parse(Console.ReadLine());
            decimal minior = decimal.Parse(Console.ReadLine());
            decimal kamion = decimal.Parse(Console.ReadLine());

            decimal pPazel = 2.60m;
            decimal pKykla = 3m;
            decimal pMe4e = 4.10m;
            decimal pMinior = 8.20m;
            decimal pKamion = 2m;

            pPazel = pPazel * pazel;
            pKykla = pKykla * kykla;
            pMe4e = pMe4e * me4e;
            pMinior = pMinior * minior;
            pKamion = pKamion * kamion;

            decimal allToys = pazel + kykla + me4e + minior + kamion;
            decimal allMony = pPazel + pKykla + pMe4e + pMinior + pKamion;

            if (allToys >= 50)
            {
                allMony = allMony - (allMony * 25 / 100);
            }
            allMony -= allMony * 10 / 100;

            if (allMony >= prise)
            {
                Console.WriteLine($"Yes! {allMony - prise:f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {prise - allMony:f2} lv needed.");
            }
        }
    }
}
