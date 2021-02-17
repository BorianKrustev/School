using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlcoholMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal pYliski = decimal.Parse(Console.ReadLine());
            decimal bira = decimal.Parse(Console.ReadLine());
            decimal vino = decimal.Parse(Console.ReadLine());
            decimal rakia = decimal.Parse(Console.ReadLine());
            decimal yliski = decimal.Parse(Console.ReadLine());

            decimal pRakia = pYliski / 2;
            decimal pVino = pRakia - (pRakia * 40 / 100);
            decimal pBira = pRakia - (pRakia * 80 / 100);

            pYliski = pYliski * yliski;
            pRakia = pRakia * rakia;
            pVino = pVino * vino;
            pBira = pBira * bira;
            decimal all = pYliski + pRakia + pVino + pBira;

            Console.WriteLine($"{all:f2}");
        }
    }
}
