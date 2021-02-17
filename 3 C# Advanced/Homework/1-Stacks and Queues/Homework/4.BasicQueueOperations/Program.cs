using System;
using System.Linq;
using System.Collections.Generic;

namespace _4.BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] comands = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Queue<int> que = new Queue<int>(numbers);

            if (comands[0] <= comands[1])
            {
                Console.WriteLine("0");
            }
            else
            {
                for (int i = 0; i < comands[1]; i++)
                {
                    que.Dequeue();
                }

                if (que.Contains(comands[2]))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine($"{que.Min()}");
                }
            }
        }
    }
}
