using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfIntervals
{
    class Program
    {
        static void Main(string[] args)
        {
            int game = int.Parse(Console.ReadLine());

            int m1 = 0;
            int m2 = 0;
            int m3 = 0;
            int m4 = 0;
            int m5 = 0;
            int m6 = 0;
            double points = 0;

            for (int i = 1; i <= game; i++)
            {
                double number = double.Parse(Console.ReadLine());

                if (number >= 0 && number <=9)
                {
                    m1 += 1;
                    points += number * 20 / 100;
                }
                else if (number >=10 && number <= 19)
                {
                    m2 += 1;
                    points += number * 30 / 100;
                }
                else if (number >= 20 && number <= 29)
                {
                    m3 += 1;
                    points += number * 40 / 100;
                }
                else if (number >= 30 && number <= 39)
                {
                    m4 += 1;
                    points += 50;
                }
                else if (number >= 40 && number <= 50)
                {
                    m5 += 1;
                    points += 100;
                }
                else
                {
                    m6 += 1;
                    points /= 2;
                }
            }

            Console.WriteLine($"{points:f2}");
            Console.WriteLine($"From 0 to 9: {m1 / game * m1 / game}%");
            Console.WriteLine($"From 10 to 19: {game * m2 / 100}%");
            Console.WriteLine($"From 20 to 29: {game * m3 / 100}%");
            Console.WriteLine($"From 30 to 39: {game * m4 / 100}%");
            Console.WriteLine($"From 40 to 50: {game * m5 / 100}%");
            Console.WriteLine($"Invalid numbers: {game * m6 / 100}%");
        }
    }
}
