using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Styrofoam
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal budget = decimal.Parse(Console.ReadLine());
            decimal houseKM = decimal.Parse(Console.ReadLine());
            decimal widowls = decimal.Parse(Console.ReadLine());
            decimal stiropor = decimal.Parse(Console.ReadLine());
            decimal pStiropor = decimal.Parse(Console.ReadLine());

            widowls *= 2.4m;
            houseKM -= widowls;
            houseKM += houseKM * 10 / 100;
            stiropor = Math.Ceiling(houseKM / stiropor);
            stiropor *= pStiropor;

            if (stiropor < budget)
            {
                Console.WriteLine($"Spent: {stiropor:f2}");
                Console.WriteLine($"Left: {budget - stiropor:f2}");
            }
            else
            {
                Console.WriteLine($"Need more: {stiropor - budget:f2}");
            }
        }
    }
}
