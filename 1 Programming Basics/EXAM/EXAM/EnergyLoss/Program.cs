using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyLoss
{
    class Program
    {
        static void Main(string[] args)
        {
            double days = double.Parse(Console.ReadLine());
            double dancers = double.Parse(Console.ReadLine());

            double energy = 0;

            for (int i = 1; i <= days; i++)
            {
                double houers = double.Parse(Console.ReadLine());

                if (i % 2 == 0 && houers % 2 == 0)
                {
                    energy += dancers * 68;
                }
                else if (i % 2 != 0 && houers % 2 == 0)
                {
                    energy += dancers * 49;
                }
                else if (i % 2 == 0 && houers % 2 != 0)
                {
                    energy += dancers * 65;
                }
                else if (i % 2 != 0 && houers % 2 != 0)
                {
                    energy += dancers * 30;
                }
            }

            double stratEnergy = (100 * dancers * days) - energy;
            energy = stratEnergy / dancers / days;

            if (energy >= 50)
            {
                Console.WriteLine($"They feel good! Energy left: {energy:f2}");
            }
            else
            {
                Console.WriteLine($"They are wasted! Energy left: {energy:f2}");
            }
        }
    }
}
