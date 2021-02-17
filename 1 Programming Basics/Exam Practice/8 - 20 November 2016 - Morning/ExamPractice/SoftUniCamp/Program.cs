using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniCamp
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());

            double all = 0;
            double m1 = 0;
            double m2 = 0;
            double m3 = 0;
            double m4 = 0;
            double m5 = 0;

            for (int i = 0; i < number; i++)
            {
                double grup = double.Parse(Console.ReadLine());

                all += grup;
                if (grup <= 5)
                {
                    m1 += grup;
                }
                else if (grup > 5 && grup <= 12)
                {
                    m2 += grup;
                }
                else if (grup > 12 && grup <= 25)
                {
                    m3 += grup;
                }
                else if (grup > 25 && grup <= 40)
                {
                    m4 += grup;
                }
                else if (grup >= 41)
                {
                    m5 += grup;
                }
            }

            Console.WriteLine($"{m1 / all * 100:f2}%");
            Console.WriteLine($"{m2 / all * 100:f2}%");
            Console.WriteLine($"{m3 / all * 100:f2}%");
            Console.WriteLine($"{m4 / all * 100:f2}%");
            Console.WriteLine($"{m5 / all * 100:f2}%");
        }
    }
}
