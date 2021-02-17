using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrapeAndRakia
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal loznisa = decimal.Parse(Console.ReadLine());
            decimal kg = decimal.Parse(Console.ReadLine());
            decimal brak = decimal.Parse(Console.ReadLine());

            kg = kg * loznisa - brak;
            decimal rakia = kg * 45 / 100;
            decimal grozde = kg * 55 / 100;

            rakia = rakia / 7.5m;
            rakia *= 9.80m;
            grozde *= 1.50m;

            Console.WriteLine($"{rakia:f2}");
            Console.WriteLine($"{grozde:f2}");
        }
    }
}
