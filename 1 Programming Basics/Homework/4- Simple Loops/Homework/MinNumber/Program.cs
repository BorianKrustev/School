using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberToRoteat = int.Parse(Console.ReadLine());
            int lowNumber = int.MaxValue;

            for (int i = 0; i < numberToRoteat; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (lowNumber > number)
                {
                    lowNumber = number;
                }
            }
            Console.WriteLine(lowNumber);
        }
    }
}
