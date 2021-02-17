using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.MaxSequenceOfIncreasingElements
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] items = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            long length = 1;
            long start = 0;
            long bestStart = 0;
            long bestLength = 1;
            long helper = 1;

            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] >= items[helper])
                {
                    length++;
                    helper++;

                    if (length > bestLength)
                    {
                        bestLength = length;
                        bestStart = start;
                    }
                }
                else
                {
                    length = 1;
                    start = i;
                    helper = i;
                }
            }
            for (long j = bestStart; j < bestStart + bestLength; j++)
            {
                Console.Write(items[j]);
                Console.Write(" ");
            }

            //int[] arr = Console.ReadLine()
            //    .Split(' ')
            //    .Select(int.Parse)
            //    .ToArray();
            //
            //int lengt = 1;
            //int maxLengt = 0;
            //int element = 0;
            //
            //for (int i = 0; i < arr.Length - 1; i++)
            //{
            //    int check = arr[i] + 1;
            //
            //    if (arr[i + 1] == check)
            //    {
            //        lengt += 1;
            //    }
            //    else
            //    {
            //        lengt = 1;
            //    }
            //
            //    if (maxLengt < lengt)
            //    {
            //        maxLengt = lengt;
            //        element = arr[i + 1];
            //    }
            //}
            //
            //for (int i = 0; i < maxLengt - 1; i++)
            //{
            //    element -= 1;
            //}
            //for (int i = 0; i < maxLengt; i++)
            //{
            //    Console.Write($"{element} ");
            //    element += 1;
            //}
        }
    }
}
