using System;
using System.Linq;
using System.Collections.Generic;

namespace _2.BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] comands = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>(input);

            if (comands[1] >= stack.Count)
            {
                if (comands[2] == 0)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("0");
                }
            }
            else
            {
                for (int i = 0; i < comands[1]; i++)
                {
                    stack.Pop();
                }

                if (stack.Contains(comands[2]))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine($"{stack.Min()}");
                }
            }
        }
    }
}
