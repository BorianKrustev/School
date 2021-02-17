using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileRepair
{
    class Program
    {
        static void Main(string[] args)
        {
            double plo6tadkaStrana = double.Parse(Console.ReadLine());
            double sideTile = double.Parse(Console.ReadLine());
            double tallTile = double.Parse(Console.ReadLine());
            double benchTall = double.Parse(Console.ReadLine());
            double benchSide = double.Parse(Console.ReadLine());

            double bench = benchSide * benchTall;
            double plo6tadka = plo6tadkaStrana * plo6tadkaStrana;
            double tile = sideTile * tallTile;

            plo6tadka -= bench;
            tile = plo6tadka / tile;
            double time = tile * 0.2;

            Console.WriteLine($"{tile:f2}");
            Console.WriteLine($"{time:f2}");
        }
    }
}
