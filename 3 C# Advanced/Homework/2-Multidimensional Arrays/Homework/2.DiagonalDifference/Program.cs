using System;
using System.Linq;

namespace _2.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                int[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int f = 0; f < size; f++)
                {
                    matrix[i, f] = input[f];
                }
            }

            int diagonal1 = 0;
            int diagonal2 = 0;

            for (int i = 0; i < size; i++)
            {
                diagonal1 += matrix[i, i];
            }

            int hold = size;
            for (int i = 0; i < size; i++)
            {
                hold -= 1;
                diagonal2 += matrix[i, hold];
            }

            Console.WriteLine(Math.Abs(diagonal1 - diagonal2));
        }
    }
}
