using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distance
{
    class Program
    {
        static void Main(string[] args)
        {
            double speed = double.Parse(Console.ReadLine());
            double oneSpeed = double.Parse(Console.ReadLine());
            double twoSpeed = double.Parse(Console.ReadLine());
            double treeTrip = double.Parse(Console.ReadLine());

            oneSpeed /= 60;
            twoSpeed /= 60;
            treeTrip /= 60;

            oneSpeed *= speed;
            double two = speed + speed * 10 / 100;
            double tree = two - two * 5 / 100;

            twoSpeed *= two;
            treeTrip *= tree;

            Console.WriteLine($"{oneSpeed + twoSpeed + treeTrip:f2}");
        }
    }
}
