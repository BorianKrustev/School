using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int a = number / 100;
            int b = number % 100;
                b = b / 10;
            int c = number % 10;

            for (int i = 0; i < a + b; i++)
            {
                for (int f = 0; f < a + c; f++)
                {
                    if (number % 5 == 0)
                    {
                        number -= a;
                    }
                    else if (number % 3 == 0)
                    {
                        number -= b;
                    }
                    else
                    {
                        number += c;
                    }

                    Console.Write($"{number} ");
                }

                Console.WriteLine();
            }
        }
    }
}
