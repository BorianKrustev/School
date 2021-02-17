using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishland
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal pSkomria = decimal.Parse(Console.ReadLine());
            decimal pSasa = decimal.Parse(Console.ReadLine());
            decimal palamudKg = decimal.Parse(Console.ReadLine());
            decimal safridKg = decimal.Parse(Console.ReadLine());
            decimal midiKg = decimal.Parse(Console.ReadLine());

            decimal pPalamud = pSkomria + pSkomria * 60 / 100;
            decimal pSafrit = pSasa + pSasa * 80 / 100;
            midiKg *= 7.50m;
            pSafrit *= safridKg;
            pPalamud *= palamudKg;

            decimal all = midiKg + pSafrit + pPalamud;

            Console.WriteLine($"{all:f2}");
        }
    }
}
