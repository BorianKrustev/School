using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.SoftUniReseption
{
    class Program
    {
        static void Main(string[] args)
        {
            double first = double.Parse(Console.ReadLine());
            double second = double.Parse(Console.ReadLine());
            double tird = double.Parse(Console.ReadLine());
            double students = double.Parse(Console.ReadLine());

            double totalTimeNeedet = first + second + tird;
            int houers = 0;

            for (int i = 1; i > 0; i++)
            {
                if (students <= 0) break;
                if (i % 4 == 0)
                {
                    continue;
                }
                houers = i;
                students -= totalTimeNeedet;   
            }

            Console.WriteLine($"Time needed: {houers}h.");
        }
    }
}
