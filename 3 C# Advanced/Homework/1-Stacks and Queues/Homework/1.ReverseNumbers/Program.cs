using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.ReverseNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                stack.Push(numbers[i]);
            }

            foreach (var item in stack)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
