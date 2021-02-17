using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace _2.Sneaking
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[][] rome = new char[n][];

            int row = -1;
            int col = -1;

            for (int i = 0; i < n; i++)
            {
                rome[i] = Console.ReadLine().ToCharArray();
                if (rome[i].Contains('S'))
                {
                    row = i;
                    col = Array.IndexOf(rome[i], 'S');
                }
            }

            char[] comands = Console.ReadLine().ToCharArray();

            if (rome[row].Contains('b') && Array.IndexOf(rome[row], 'b') < col)
            {
                rome[row][col] = 'X';
                Console.WriteLine($"Sam died at {row}, {col}");

                foreach (var item in rome)
                {
                    Console.WriteLine($"{string.Join("", item)}");
                }

                return;
            }
            else if (rome[row].Contains('d') && Array.IndexOf(rome[row], 'd') > col)
            {
                rome[row][col] = 'X';
                Console.WriteLine($"Sam died at {row}, {col}");

                foreach (var item in rome)
                {
                    Console.WriteLine($"{string.Join("", item)}");
                }

                return;
            }

            for (int i = 0; i < comands.Length; i++)
            {
                MoveEnemy(rome);

                if (rome[row].Contains('b') && Array.IndexOf(rome[row], 'b') < col)
                {
                    rome[row][col] = 'X';
                    Console.WriteLine($"Sam died at {row}, {col}");
                    break;
                }
                else if (rome[row].Contains('d') && Array.IndexOf(rome[row], 'd') > col)
                {
                    rome[row][col] = 'X';
                    Console.WriteLine($"Sam died at {row}, {col}");
                    break;
                }
                else if (rome[row].Contains('N'))
                {
                    int indexOfN = Array.IndexOf(rome[row], 'N');
                    rome[row][indexOfN] = 'X';
                    Console.WriteLine($"Nikoladze killed!");
                    break;
                }

                MoveSame(rome, ref row, ref col, comands[i]);

                if (rome[row].Contains('b') && Array.IndexOf(rome[row], 'b') < col)
                {
                    rome[row][col] = 'X';
                    Console.WriteLine($"Sam died at {row}, {col}");
                    break;
                }
                else if (rome[row].Contains('d') && Array.IndexOf(rome[row], 'd') > col)
                {
                    rome[row][col] = 'X';
                    Console.WriteLine($"Sam died at {row}, {col}");
                    break;
                }
                else if (rome[row].Contains('N'))
                {
                    int indexOfN = Array.IndexOf(rome[row], 'N');
                    rome[row][indexOfN] = 'X';
                    Console.WriteLine($"Nikoladze killed!");
                    break;
                }
            }

            foreach (var item in rome)
            {
                Console.WriteLine($"{string.Join("", item)}");
            }
        }

        private static void MoveSame(char[][] rome, ref int row, ref int col, char comand)
        {
            rome[row][col] = '.';
            switch (comand)
            {
                case 'U': row -= 1; break;
                case 'D': row += 1; break;
                case 'L': col -= 1; break;
                case 'R': col += 1; break;
                default:
                    break;
            }

            rome[row][col] = 'S';
        }

        private static void MoveEnemy(char[][] rome)
        {
            for (int i = 0; i < rome.Length; i++)
            {
                int indexD = Array.IndexOf(rome[i], 'd');
                int indexB = Array.IndexOf(rome[i], 'b');

                if (indexD != -1)
                {
                    if (indexD > 0)
                    {
                        rome[i][indexD] = '.';
                        rome[i][indexD - 1] = 'd';
                    }
                    if (indexD == 0)
                    {
                        rome[i][indexD] = 'b';
                    }
                }
                if (indexB != -1)
                {
                    if (indexB < rome[i].Length - 1)
                    {
                        rome[i][indexB] = '.';
                        rome[i][indexB + 1] = 'b';
                    }
                    if (indexB == rome[i].Length - 1)
                    {
                        rome[i][indexB] = 'd';
                    }
                }
            }
        }
    }
}
