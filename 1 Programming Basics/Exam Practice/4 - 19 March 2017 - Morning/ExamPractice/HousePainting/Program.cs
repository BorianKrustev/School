using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousePainting
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double wall1 = x * x - (1.2 * 2);
            double wall2 = x * x;
            double wall3 = (x * y) * 2;
            double windows = (1.5 * 1.5) * 2;
            wall3 -= windows;
            double allWalls = wall1 + wall2 + wall3;
            allWalls = allWalls / 3.4;

            double rofe1 = (x * y) * 2;
            double rofe2 = 2 *(x * h / 2);
            double allRofe = rofe1 + rofe2;
            allRofe = allRofe / 4.3;

            Console.WriteLine($"{allWalls:f2}");
            Console.WriteLine($"{allRofe:f2}");
        }
    }
}
