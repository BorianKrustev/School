using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.PairsByDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int diff = int.Parse(Console.ReadLine());

            int count = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                for (int f = i + 1; f < arr.Length; f++)
                {
                    if (Math.Abs(arr[i] - arr[f]) == diff)
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine($"{count}");
        }
    }
}
