using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int lengt = 1;
            int bestLengt = 0;
            int element = 0;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] == arr[i + 1])
                {
                    for (int f = i; f < arr.Length - 1; f++)
                    {
                        if (arr[f] == arr[f + 1])
                        {
                            lengt += 1;
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (bestLengt < lengt)
                    {
                        bestLengt = lengt;
                        element = arr[i];
                    }
                    lengt = 1;
                }
            }

            for (int i = 0; i < bestLengt; i++)
            {
                Console.Write($"{element} ");
            }
        }
    }
}
