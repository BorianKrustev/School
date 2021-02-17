using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string prise = Console.ReadLine();
            double rows = double.Parse(Console.ReadLine());
            double pilers = double.Parse(Console.ReadLine());

            double Premiere = 12.00;
            double Normal = 7.50;
            double Discount = 5.00;

            if (prise == "Premiere")
            {
                Console.WriteLine($"{Premiere * rows * pilers:f2} leva");
            }
            else if (prise == "Normal")
            {
                Console.WriteLine($"{Normal * rows * pilers:f2} leva");
            }
            else if (prise == "Discount")
            {
                Console.WriteLine($"{Discount * rows * pilers:f2} leva");
            }
        }
    }
}
