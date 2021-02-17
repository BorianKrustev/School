using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague
{
    class Program
    {
        static void Main(string[] args)
        {
            double stadiam = int.Parse(Console.ReadLine());
            double fans = int.Parse(Console.ReadLine());
            
            double A = 0;
            double B = 0;
            double V = 0;
            double G = 0;

            for (int i = 1; i <= fans; i++)
            {
                string sector = Console.ReadLine();

                if (sector == "A")
                {
                    A += 1;
                }
                else if (sector == "B")
                {
                    B += 1;
                }
                else if (sector == "V")
                {
                    V += 1;
                }
                else
                {
                    G += 1;
                }
            }

            Console.WriteLine($"{A / fans * 100:f2}%");
            Console.WriteLine($"{B / fans * 100:f2}%");
            Console.WriteLine($"{V / fans * 100:f2}%");
            Console.WriteLine($"{G / fans * 100:f2}%");
            Console.WriteLine($"{fans / stadiam * 100:f2}%");
        }
    }
}
