using System;
using System.Linq;
using System.Collections.Generic;

namespace _8.StackFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int rotations = int.Parse(Console.ReadLine());

            Stack<long> stack = new Stack<long>();

            stack.Push(0);
            stack.Push(1);

            for (long i = 0; i <= rotations - 2; i++)
            {
                long a = stack.Peek();
                long hold = stack.Pop();
                long b = stack.Peek();
                stack.Push(hold);
                stack.Push(a + b);
            }

            Console.WriteLine($"{stack.Peek()}");
        }
    }
}
