using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.NumbersInReversedOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            Console.WriteLine($"{revers(number)}");
        }

        static string revers (string num)
        {
            string reverst = "";
            for (int i = num.Length - 1; i >= 0; i--)
            {
                reverst += num[i];
            }

            return reverst;
        }
    }
}
