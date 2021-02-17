using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int doctors = 7;

            int treted = 0;
            int untrited = 0;

            for (int i = 1; i <= number; i++)
            {
                if (untrited > treted && i % 3 == 0)
                {
                    doctors += 1;
                }

                int paisonts = int.Parse(Console.ReadLine());

                if (paisonts >= doctors)
                {
                    treted += doctors;
                    untrited += paisonts - doctors;
                }
                else
                {
                    treted += paisonts;
                }
            }

            Console.WriteLine($"Treated patients: {treted}.");
            Console.WriteLine($"Untreated patients: {untrited}.");
        }
    }
}
