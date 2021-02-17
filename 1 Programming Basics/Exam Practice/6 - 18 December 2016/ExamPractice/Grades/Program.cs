using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            double students = double.Parse(Console.ReadLine());

            double m1 = 0;
            double m2 = 0;
            double m3 = 0;
            double m4 = 0;
            double avrig = 0;

            for (int i = 1; i <= students; i++)
            {
                double grade = double.Parse(Console.ReadLine());

                avrig += grade;
                if (grade >= 2 && grade <3)
                {
                    m1 += 1;
                }
                else if (grade >= 3 && grade < 4)
                {
                    m2 += 1;
                }
                else if (grade >= 4 && grade < 5)
                {
                    m3 += 1;
                }
                else if (grade >= 5)
                {
                    m4 += 1;
                }
            }

            avrig /= students;

            Console.WriteLine($"Top students: {m4 / students * 100:f2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {m3 / students * 100:f2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {m2 / students * 100:f2}%");
            Console.WriteLine($"Fail: {m1 / students * 100:f2}%");
            Console.WriteLine($"Average: {avrig:f2}");
        }
    }
}
