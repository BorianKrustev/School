using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profit
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal days = decimal.Parse(Console.ReadLine());
            decimal mony = decimal.Parse(Console.ReadLine());
            decimal dl = decimal.Parse(Console.ReadLine());

            decimal month = days * mony;
            decimal eayr = (month * 12) + (month * 2.5m);
            eayr = eayr - (eayr * 25 / 100);
            decimal lv = eayr * dl;
            lv /= 365;

            Console.WriteLine($"{lv:f2}");
        }
    }
}
