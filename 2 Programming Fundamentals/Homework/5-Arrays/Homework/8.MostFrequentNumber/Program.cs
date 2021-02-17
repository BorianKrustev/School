using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.MostFrequentNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int count = 0;
            int number = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                int newCount = 0;
                for (int f = i; f < arr.Length; f++)
                {
                    if (arr[f] == arr[i])
                    {
                        newCount += 1;
                    }
                }

                if (count < newCount)
                {
                    count = newCount;
                    number = arr[i];
                }
            }

            Console.WriteLine($"{number}");
        }
    }
}
