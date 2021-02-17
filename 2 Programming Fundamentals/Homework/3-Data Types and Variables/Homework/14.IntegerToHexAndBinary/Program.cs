using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.IntegerToHexAndBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine($"{Convert.ToString(number, 16).ToUpper()}");
            Console.WriteLine($"{Convert.ToString(number, 2)}");
        }
    }
}
