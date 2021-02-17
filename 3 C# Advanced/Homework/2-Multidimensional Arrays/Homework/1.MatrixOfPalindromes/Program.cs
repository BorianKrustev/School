using System;
using System.Collections.Generic;
using System.Linq;

namespace _02MatrixPolindromes
{
    class MatrixPolindromes
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int matrixRow = list[0];
            int matrixCol = list[1];
            string[,] matrix = new string[matrixRow, matrixCol];

            for (int i = 0; i < matrixRow; i++)
            {
                for (int f = 0; f < matrixCol; f++)
                {
                    matrix[i, f] = "" + (char)('a' + i) + (char)('a' + i + f) + (char)('a' + i);
                }
            }

            for (int i = 0; i < matrixRow; i++)
            {
                for (int f = 0; f < matrixCol; f++)
                {
                    Console.Write($"{matrix[i, f]} ");
                }
                Console.WriteLine();
            }
        }
    }
}