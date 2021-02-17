using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Choreography
{
    class Program
    {
        static void Main(string[] args)
        {
            double steps = double.Parse(Console.ReadLine());
            double dancers = double.Parse(Console.ReadLine());
            double days = double.Parse(Console.ReadLine());

            steps = Math.Ceiling(((steps / days) / steps) * 100);
            dancers = steps / dancers;

            if (steps > 13)
            {
                Console.WriteLine($"No, They will not succeed in that goal! Required {dancers:f2}% steps to be learned per day.");
            }
            else
            {
                Console.WriteLine($"Yes, they will succeed in that goal! {dancers:f2}%.");
            }
        }
    }
}
