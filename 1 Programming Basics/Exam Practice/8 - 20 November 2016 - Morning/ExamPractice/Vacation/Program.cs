using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal olld = decimal.Parse(Console.ReadLine());
            decimal students = decimal.Parse(Console.ReadLine());
            decimal nights = decimal.Parse(Console.ReadLine());
            string transport = Console.ReadLine();

            nights *= 82.99m;
            decimal pOlld = 0;
            decimal pStudents = 0;

            if (transport == "train")
            {
                pOlld = 24.99m;
                pStudents = 14.99m;
            }
            else if (transport == "bus")
            {
                pOlld = 32.50m;
                pStudents = 28.50m;
            }
            else if (transport == "boat")
            {
                pOlld = 42.99m;
                pStudents = 39.99m;
            }
            else if (transport == "airplane")
            {
                pOlld = 70.00m;
                pStudents = 50.00m;
            }

            pOlld *= olld;
            pStudents *= students;
            decimal travel = (pOlld + pStudents) * 2;

            if (transport == "train" && olld + students >= 50)
            {
                travel = travel - travel * 50 / 100;
            }

            decimal comision = travel + nights;
            comision = comision * 10 / 100;

            decimal all = travel + nights + comision;

            Console.WriteLine($"{all:f2}");
        }
    }
}
