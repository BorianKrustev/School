using System;
using System.Linq;
using System.Collections.Generic;

namespace _8.RadioactiveBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] siz = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rowSize = siz[0];
            int colSize = siz[1];

            char[][] zone = new char[rowSize][];

            for (int i = 0; i < zone.Length; i++)
            {
                string input = Console.ReadLine();
                zone[i] = input.ToCharArray();
                if (input.Contains('P'))
                {

                }
            }

            string comands = Console.ReadLine();

            for (int i = 0; i < comands.Length; i++)
            {
                char curentComand = comands[i];

                for (int row = 0; row  < zone.Length; row ++)
                {
                    for (int col = 0; col < zone[row].Length; col++)
                    {
                        if (zone[row][col] == 'B')
                        {
                            zone[row + 1][col] = 'B';
                        }
                    }
                }
            }

            printZone(zone);
        }

        private static void printZone(char[][] zone)
        {
            foreach (var item in zone)
            {
                Console.WriteLine(string.Join("", item));
            }
        }
    }
}
