using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int a = 1; a <= 9; a++)
            {
                for (int s = 1; s <= 9; s++)
                {
                    for (int d = 1; d <= 9; d++)
                    {
                        for (int f = 1; f <= 9; f++)
                        {
                            for (int g = 1; g <= 9; g++)
                            {
                                for (int h = 1; h <= 9; h++)
                                {
                                    if (a * s * d * f * g * h == number)
                                    {
                                        Console.Write($"{a}{s}{d}{f}{g}{h} ");
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
