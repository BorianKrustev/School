using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLily
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal age = decimal.Parse(Console.ReadLine());
            decimal prise = decimal.Parse(Console.ReadLine());
            decimal pToy = decimal.Parse(Console.ReadLine());

            decimal toy = 0;
            decimal givMony = 0;
            decimal B = 0;
            decimal givMonyCount = 0;

            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    givMonyCount += 1;

                    givMony += 10 + B;
                    B += 10;
                }
                else
                {
                    toy += 1;
                }
            }

            toy *= pToy;
            givMony -= givMonyCount;
            decimal allMony = toy + givMony;

            if (allMony >= prise)
            {
                Console.WriteLine($"Yes! {allMony - prise:f2}");
            }
            else
            {
                Console.WriteLine($"No! {prise - allMony:f2}");
            }
        }
    }
}
