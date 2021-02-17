using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeTiles
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal mony = decimal.Parse(Console.ReadLine());
            decimal lengtFlor = decimal.Parse(Console.ReadLine());
            decimal tollFlore = decimal.Parse(Console.ReadLine());
            decimal sideTriangel = decimal.Parse(Console.ReadLine());
            decimal tollTriangel = decimal.Parse(Console.ReadLine());
            decimal prise = decimal.Parse(Console.ReadLine());
            decimal worckers = decimal.Parse(Console.ReadLine());

            decimal flore = lengtFlor * tollFlore;
            decimal Tile = sideTriangel * tollTriangel / 2;
            flore = Math.Ceiling(flore / Tile);
            flore += 5;
            decimal monyNed = flore * prise + worckers;

            if (monyNed > mony)
            {
                Console.WriteLine($"You'll need {monyNed - mony:f2} lv more.");
            }
            else
            {
                Console.WriteLine($"{mony - monyNed:f2} lv left.");
            }
        }
    }
}
