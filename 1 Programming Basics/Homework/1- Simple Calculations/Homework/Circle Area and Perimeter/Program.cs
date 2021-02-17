using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle_Area_and_Perimeter
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = double.Parse(Console.ReadLine());
            var area = Math.PI * a * a;
            var peri = 2 * Math.PI * a;
            Console.WriteLine(area);
            Console.WriteLine(peri);

        }
    }
}
