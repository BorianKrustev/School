using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalCompetition
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal dancers = decimal.Parse(Console.ReadLine());
            decimal points = decimal.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string plase = Console.ReadLine();

            decimal mony = 0m;

            if (plase == "Bulgaria")
            {
                mony = dancers * points;

                if (season == "summer")
                {
                    mony = mony - (mony * 5 / 100);
                }
                else
                {
                    mony = mony - (mony * 8 / 100);
                }
            }
            else
            {
                mony = dancers * points;
                mony = mony + (mony * 50 / 100);

                if (season == "summer")
                {
                    mony = mony - (mony * 10 / 100);
                }
                else
                {
                    mony = mony - (mony * 15 / 100);
                }
            }

            decimal cherety = mony * 75 / 100;
            decimal tacke = (mony - cherety) / dancers;

            Console.WriteLine($"Charity - {cherety:f2}");
            Console.WriteLine($"Money per dancer - {tacke:f2}");
        }
    }
}
