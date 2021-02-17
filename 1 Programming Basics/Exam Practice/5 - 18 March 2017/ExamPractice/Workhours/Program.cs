using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workhours
{
    class Program
    {
        static void Main(string[] args)
        {
            int houers = int.Parse(Console.ReadLine());
            int worckers = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

            int worck = days * worckers* 8;
            int overtime = (houers - worck) * days;
            if (worck >= houers)
            {
                Console.WriteLine($"{worck - houers} hours left");
            }
            else
            {
                Console.WriteLine($"{houers - worck} overtime");
                Console.WriteLine($"Penalties: {overtime}");
            }
        }
    }
}
