using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firm
{
    class Program
    {
        static void Main(string[] args)
        {
            double houers = double.Parse(Console.ReadLine());
            double days = double.Parse(Console.ReadLine());
            double worckersOvertime = double.Parse(Console.ReadLine());

            worckersOvertime *= 2;
            worckersOvertime *= days;

            days = days - (days * 10 / 100);
            days *= 8;

            double all = Math.Floor(days + worckersOvertime);

            if (all >= houers)
            {
                Console.WriteLine($"Yes!{all - houers} hours left.");
            }
            else
            {
                Console.WriteLine($"Not enough time!{houers - all} hours needed.");
            }
        }
    }
}
