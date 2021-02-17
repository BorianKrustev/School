using System;
using System.Linq;
using System.Collections.Generic;

namespace _3.MaximumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            int comands = int.Parse(Console.ReadLine());

            for (int i = 0; i < comands; i++)
            {
                int[] number = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                if (number[0] == 1)
                {
                    stack.Push(number[1]);
                }
                else if (number[0] == 2)
                {
                    stack.Pop();
                }
                else if (number[0] == 3)
                {
                    Console.WriteLine($"{stack.Max()}");
                }
            }
        }
    }
}
