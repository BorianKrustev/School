using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcellentOrNot
{
    class Program
    {
        static void Main(string[] args)
        {
            double Number = double.Parse(Console.ReadLine());

            if (Number >= 5.50)
            {
                Console.WriteLine("Excellent!");
            }

            else if (Number < 5.50)
            {
                Console.WriteLine("Not excellent.");
            }
        }
    }
}
