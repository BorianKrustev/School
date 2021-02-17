using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string eyar = Console.ReadLine().ToLower();
            double seleb = int.Parse(Console.ReadLine());
            double homeT = int.Parse(Console.ReadLine());
            double wickends = 48;

            double playInSofia = (wickends - homeT) * 3 / 4;
            double playInSeleb = seleb * 2 / 3;
            double playTimeTotal = playInSofia + homeT + playInSeleb;

            if (eyar == "leap")
            {
                double lep = playTimeTotal * 15 / 100;
                Console.WriteLine(Math.Floor(playTimeTotal + lep));
            }
            else
            {
                Console.WriteLine(Math.Floor(playTimeTotal));
            }

        }
    }
}
