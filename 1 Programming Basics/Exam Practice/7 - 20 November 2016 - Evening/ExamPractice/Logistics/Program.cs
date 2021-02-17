using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal number = decimal.Parse(Console.ReadLine());

            decimal allTon = 0m;
            decimal microbus = 0m;
            decimal kamion = 0m;
            decimal vlak = 0m;

            for (int i = 0; i < number; i++)
            {
                decimal ton = decimal.Parse(Console.ReadLine());

                allTon += ton;
                if (ton <= 3)
                {
                    microbus += ton;
                }
                else if (ton >= 4 && ton <=11)
                {
                    kamion += ton;
                }
                else if (ton >= 12)
                {
                    vlak += ton;
                }
            }

            decimal pMicrobus = microbus * 200m;
            decimal pKamion = kamion * 175m;
            decimal pVlak = vlak * 120m;

            decimal allMony = pMicrobus + pKamion + pVlak;
            allMony /= allTon;

            microbus = microbus / allTon * 100;
            kamion = kamion / allTon * 100;
            vlak = vlak / allTon * 100;

            Console.WriteLine($"{allMony:f2}");
            Console.WriteLine($"{microbus:f2}%");
            Console.WriteLine($"{kamion:f2}%");
            Console.WriteLine($"{vlak:f2}%");
        }
    }
}
