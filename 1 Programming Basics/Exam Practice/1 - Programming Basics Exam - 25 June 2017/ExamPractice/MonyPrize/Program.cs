using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonyPrize
{
    class Program
    {
        static void Main(string[] args)
        {
            int parts = int.Parse(Console.ReadLine());
            decimal mony = decimal.Parse(Console.ReadLine());

            decimal allPoints = 0;
            for (int i = 1; i <= parts; i++)
            {
                decimal points = decimal.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    points = points * 2;
                }
                allPoints += points;
            }
            mony = mony * allPoints;

            Console.WriteLine($"The project prize was {mony:f2} lv.");
        }
    }
}
