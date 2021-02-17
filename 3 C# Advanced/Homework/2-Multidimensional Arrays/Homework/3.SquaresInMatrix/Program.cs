using System;
using System.Linq;
using System.Collections.Generic;

namespace _3.SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[,] matrix = new char[n[0], n[1]];

            for (int i = 0; i < n[0]; i++)
            {
                char[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int f = 0; f < n[1]; f++)
                {
                    matrix[i, f] = input[f];
                }
            }

            int coutn = 0;
            for (int i = 0; i < n[0] - 1; i++)
            {
                for (int f = 0; f < n[1] - 1; f++)
                {
                    if (matrix[i, f] == matrix[i , f + 1] && matrix[i, f] == matrix[i + 1,  f] && matrix[i, f] == matrix[i + 1, f + 1])
                    {
                        coutn += 1;
                    }
                }
            }

            Console.WriteLine(coutn);
        }
    }
}
