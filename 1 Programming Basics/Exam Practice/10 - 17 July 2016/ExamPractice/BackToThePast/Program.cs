using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackToThePast
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal mony = decimal.Parse(Console.ReadLine());
            decimal year = decimal.Parse(Console.ReadLine());

            decimal old = 17;

            for (int i = 1800; i <= year; i++)
            {
                old += 1;

                if (i % 2 == 0)
                {
                    mony -= 12000m;
                }
                else
                {
                    mony = mony - (12000 + (old * 50));
                }
            }

            if (mony >= 0)
            {
                Console.WriteLine($"Yes! He will live a carefree life and will have {mony:f2} dollars left.");
            }
            else
            {
                Console.WriteLine($"He will need {Math.Abs(mony):f2} dollars to survive.");
            }
        }
    }
}
