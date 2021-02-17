using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_15Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int houer = int.Parse(Console.ReadLine());
            int min = int.Parse(Console.ReadLine());

            min += 15;

            if (min >= 60)
            {
                houer += 1;
                min -= 60;
            }
            if (houer >23)
            {
                houer = 0;
            }

            Console.WriteLine($"{houer}:{min:00}");
        }
    }
}
