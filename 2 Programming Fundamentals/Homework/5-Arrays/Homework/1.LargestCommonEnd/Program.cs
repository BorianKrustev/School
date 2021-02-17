using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.LargestCommonEnd
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr1 = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string[] arr2 = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int front = 0;
            int back = 0;

            for (int i = 0; i < Math.Min(arr1.Length, arr2.Length); i++)
            {
                if (arr1[i] == arr2[i])
                {
                    front += 1;
                }
                else
                {
                    break;
                }
            }

            int revers = 1;
            for (int i = 0; i < Math.Min(arr1.Length, arr2.Length); i++)
            {
                if (arr1[arr1.Length - revers] == arr2[arr2.Length - revers])
                {
                    back += 1;
                    revers += 1;
                }
                else
                {
                    break;
                }
            }

            if (front >= back && front > 0)
            {
                Console.WriteLine($"{front}");
            }
            else if (back > front && back > 0)
            {
                Console.WriteLine($"{back}");
            }
            else
            {
                Console.WriteLine($"0");
            }
        }
    }
}
