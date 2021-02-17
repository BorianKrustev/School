using System;
using System.Linq;
using System.Collections.Generic;

namespace _7.LegoBlocks
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] firstMatrix = new int[rows][];
            int[][] secondMatrix = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                firstMatrix[i] = input;
            }

            for (int i = 0; i < rows; i++)
            {
                int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                secondMatrix[i] = input.Reverse().ToArray();
            }

            int[][] fullMatrix = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                List<int> hold = new List<int>(firstMatrix[i]);
                hold.AddRange(secondMatrix[i]);

                fullMatrix[i] = hold.ToArray();
            }

            bool chek = false;
            for (int i = 0; i < rows - 1; i++)
            {
                if (fullMatrix[i].Length == fullMatrix[i + 1].Length)
                {
                    chek = true;
                }
                else
                {
                    chek = false;
                    break;
                }
            }

            if (chek == true)
            {
                foreach (var item in fullMatrix)
                {
                    Console.WriteLine($"[{string.Join(", ", item)}]");
                }
            }
            else
            {
                int count = 0;
                for (int i = 0; i < fullMatrix.Length; i++)
                {
                    for (int f = 0; f < fullMatrix[i].Length; f++)
                    {
                        count += 1;
                    }
                }

                Console.WriteLine($"The total number of cells is: {count}");
            }
        }
    }
}
