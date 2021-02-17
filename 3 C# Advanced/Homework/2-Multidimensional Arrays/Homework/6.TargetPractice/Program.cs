using System;
using System.Linq;
using System.Collections.Generic;

namespace _6.TargetPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] siz = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string input = Console.ReadLine();
            int[] target = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            char[][] matrix = new char[siz[0]][];

            getMatrix(matrix, input, siz[1]);

            shot(matrix, target);

            colaps(matrix);

            print(matrix);
        }

        private static void colaps(char[][] matrix)
        {
            Queue<char> elements = new Queue<char>(matrix.Length);

            for (int col = 0; col < matrix[0].Length; col++)
            {
                int counter = 0;

                for (int row = 0; row < matrix.Length; row++)
                {
                    if (matrix[row][col] != ' ')
                    {
                        elements.Enqueue(matrix[row][col]);
                    }
                    else
                    {
                        counter += 1;
                    }
                }

                for (int row = 0; row < counter; row++)
                {
                    matrix[row][col] = ' ';
                }

                for (int row = counter; row < matrix.Length; row++)
                {
                    matrix[row][col] = elements.Dequeue();
                }
            }
        }

        private static void shot(char[][] matrix, int[] target)
        {
            int targetRow = target[0];
            int targetCol = target[1];
            int radius = target[2];

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int f = 0; f < matrix[i].Length; f++)
                {
                    bool pitagorovaTeoremaIsInside = Math.Pow((targetRow - i), 2) + Math.Pow((targetCol - f), 2) <= Math.Pow(radius, 2);

                    if (pitagorovaTeoremaIsInside)
                    {
                        matrix[i][f] = ' ';
                    }
                }
            }
        }

        private static void print(char[][] matrix)
        {
            foreach (var item in matrix)
            {
                Console.WriteLine(string.Join("", item));
            }
        }

        private static void getMatrix(char[][] matrix, string input, int col)
        {
            int count = 0;
            bool isLeft = true;
            for (int i = matrix.Length - 1; i >= 0; i--)
            {
                matrix[i] = new char[col];
                
                if (isLeft)
                {
                    for (int f = matrix[i].Length - 1; f >= 0; f--)
                    {
                        if (count > input.Length - 1)
                        {
                            count = 0;
                        }
                        matrix[i][f] = input[count];
                        count += 1;
                    }

                    isLeft = false;
                }
                else
                {
                    for (int f = 0; f < matrix[i].Length; f++)
                    {
                        if (count > input.Length - 1)
                        {
                            count = 0;
                        }
                        matrix[i][f] = input[count];
                        count += 1;
                    }

                    isLeft = true;
                }
            }
        }
    }
}
