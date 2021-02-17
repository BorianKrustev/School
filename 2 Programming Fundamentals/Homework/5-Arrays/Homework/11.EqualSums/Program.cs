using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.EqualSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();
            
            for (int i = 0; i < arr.Length; i++)
            {  
                if (arr.Take(i).Sum() == arr.Skip(i + 1).Sum())
                {
                    Console.WriteLine($"{i}");
                    return;
                }
            }
            
            Console.WriteLine($"no");

            //int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            //for (int i = 0; i < array.Length; i++)
            //{
            //    int leftSum = 0;
            //    int rightSum = 0;
            //    for (int j = 0; j < i; j++)
            //    {
            //        leftSum += array[j];
            //    }
            //
            //    for (int j = i + 1; j < array.Length; j++)
            //    {
            //        rightSum += array[j];
            //    }
            //
            //    if (leftSum == rightSum)
            //    {
            //        Console.WriteLine(i);
            //        return;
            //    }
            //}
            //
            //Console.WriteLine("no");
        }
    }
}
