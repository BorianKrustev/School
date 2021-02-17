using System;
using System.Linq;
using System.Collections.Generic;

namespace _4.MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[n[0], n[1]];

            for (int i = 0; i < n[0]; i++)
            {
                int[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int f = 0; f < n[1]; f++)
                {
                    matrix[i, f] = input[f];
                }
            }

            int maxSum = int.MinValue;
            List<int> startingIndex = new List<int>();
            for (int i = 0; i < n[0] - 2; i++)
            {
                for (int f = 0; f < n[1] - 2; f++)
                {
                    int sum = matrix[i, f] + matrix[i, f + 1] + matrix[i, f + 2] + matrix[i + 1, f] + matrix[i + 1, f + 1] + matrix[i + 1, f + 2] + matrix[i + 2, f] + matrix[i + 2, f + 1] + matrix[i + 2, f + 2];

                    if (sum > maxSum)
                    {
                        startingIndex.Clear();
                        startingIndex.Add(i);
                        startingIndex.Add(f);
                        maxSum = sum;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            Console.WriteLine($"{matrix[startingIndex[0], startingIndex[1]]} {matrix[startingIndex[0], startingIndex[1] + 1]} {matrix[startingIndex[0], startingIndex[1] + 2]}");
            Console.WriteLine($"{matrix[startingIndex[0] + 1, startingIndex[1]]} {matrix[startingIndex[0] + 1, startingIndex[1] + 1]} {matrix[startingIndex[0] + 1, startingIndex[1] + 2]}");
            Console.WriteLine($"{matrix[startingIndex[0] + 2, startingIndex[1]]} {matrix[startingIndex[0] + 2, startingIndex[1] + 1]} {matrix[startingIndex[0] + 2, startingIndex[1] + 2]}");
        }
    }
}
