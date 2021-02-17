using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= 9; i++)
            {
                for (int f = 1; f <= 9; f++)
                {
                    for (int g = 1; g <= 9; g++)
                    {
                        for (int h = 1; h <= 9; h++)
                        {
                            if (number % i == 0 && number % f == 0 && number % g == 0 && number % h == 0)
                            {
                                Console.Write($"{i}{f}{g}{h} ");
                            }
                        }
                    }
                }
            }
        }
    }
}
