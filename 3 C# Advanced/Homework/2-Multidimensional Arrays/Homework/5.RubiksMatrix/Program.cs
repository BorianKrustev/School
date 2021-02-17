namespace p05_RubiksMatrix
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class RubiksMatrix
    {
        public static void Main()
        {
            int[] siz = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int allMoves = int.Parse(Console.ReadLine());

            int rows = siz[0];
            int colums = siz[1];

            int[][] matrix = new int[rows][];

            getMatrix(matrix, colums);

            for (int i = 0; i < allMoves; i++)
            {
                string[] comands = Console.ReadLine().Split();

                int rowOrCol = int.Parse(comands[0]);
                string direction = comands[1];
                int moves = int.Parse(comands[2]);

                if (direction == "up")
                {
                    moveUp(matrix, moves % rows, rowOrCol);
                }
                else if (direction == "down")
                {
                    moveDown(matrix, moves % rows, rowOrCol);
                }
                else if (direction == "left")
                {
                    moveLeft(matrix, moves % colums, rowOrCol);
                }
                else if (direction == "right")
                {
                    moveRight(matrix, moves % colums, rowOrCol);
                }
            }

            int count = 1;
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int f = 0; f < matrix[i].Length; f++)
                {
                    if (matrix[i][f] == count)
                    {
                        Console.WriteLine("No swap required");
                        count += 1;
                    }
                    else
                    {
                        matricReareng(matrix, count, i, f);
                        count += 1;
                    }
                }
            }
        }

        private static void matricReareng(int[][] matrix, int count, int i, int f)
        {
            for (int newI = 0; newI < matrix.Length; newI++)
            {
                for (int newF = 0; newF < matrix[newI].Length; newF++)
                {
                    if (matrix[newI][newF] == count)
                    {
                        Console.WriteLine($"Swap ({i}, {f}) with ({newI}, {newF})");
                        matrix[newI][newF] = matrix[i][f];
                        matrix[i][f] = count;
                        return;
                    }
                }
            }
        }

        private static void moveUp(int[][] matrix, int movs, int col)
        {
            for (int i = 0; i < movs; i++)
            {
                int hold = matrix[0][col];

                for (int f = 0; f < matrix.Length - 1; f++)
                {
                    matrix[f][col] = matrix[f + 1][col];
                }

                matrix[matrix.Length - 1][col] = hold;
            }
        }

        private static void moveDown(int[][] matrix, int moves, int col)
        {
            for (int i = 0; i < moves; i++)
            {
                int hold = matrix[matrix.Length - 1][col];
                for (int f = matrix.Length - 1; f > 0; f--)
                {
                    matrix[f][col] = matrix[f - 1][col];
                }

                matrix[0][col] = hold;
            }
        }

        private static void moveRight(int[][] matrix, int moves, int rol)
        {
            for (int i = 0; i < moves; i++)
            {
                int hold = matrix[rol][matrix[rol].Length - 1];
                for (int f = matrix[rol].Length - 1; f > 0; f--)
                {
                    matrix[rol][f] = matrix[rol][f - 1];
                }

                matrix[rol][0] = hold;
            }
        }

        private static void moveLeft(int[][] matrix, int moves, int rol)
        {
            for (int i = 0; i < moves; i++)
            {
                int hold = matrix[rol][0];
                for (int f = 0; f < matrix[rol].Length - 1; f++)
                {
                    matrix[rol][f] = matrix[rol][f + 1];
                }

                matrix[rol][matrix[rol].Length - 1] = hold;
            }
        }

        private static void getMatrix(int[][] matrix, int colums)
        {
            int count = 1;

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new int[colums];

                for (int f = 0; f < matrix[i].Length; f++)
                {
                    matrix[i][f] = count;
                    count += 1;
                }
            }
        }
    }
}