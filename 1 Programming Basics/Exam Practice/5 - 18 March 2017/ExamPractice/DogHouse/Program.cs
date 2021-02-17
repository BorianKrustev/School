using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            double A = double.Parse(Console.ReadLine());
            double B = double.Parse(Console.ReadLine());

            double sideWalls = (A * (A / 2)) * 2;
            double backWall = (A / 2) * (A / 2);
            backWall += (A / 2 * (B - A / 2)) / 2;
            double fruntWall = backWall - ((A / 5) * (A / 5));
            double allWalls = sideWalls + backWall + fruntWall;
            allWalls /= 3;

            double rofe = A * (A / 2) * 2;
            rofe /= 5;

            Console.WriteLine($"{allWalls:f2}");
            Console.WriteLine($"{rofe:f2}");
        }
    }
}
