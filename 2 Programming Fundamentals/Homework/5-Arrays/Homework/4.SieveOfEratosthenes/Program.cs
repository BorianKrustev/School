using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.SieveOfEratosthenes
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            bool[] boolNumbers = new bool[number + 1];
            for (int i = 2; i <= number; i++)
            {
                boolNumbers[i] = true;
            }

            for (int i = 2; i <= number; i++)
            {
                if (boolNumbers[i] == true)
                {
                    Console.WriteLine($"{i}");

                    for (int f = i + 1; f <= number; f++)
                    {
                        if (f % i == 0)
                        {
                            boolNumbers[f] = false;
                        }
                    }
                }
            }
        }
    }
}
