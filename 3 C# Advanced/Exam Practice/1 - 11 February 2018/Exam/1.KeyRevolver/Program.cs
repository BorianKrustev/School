using System;
using System.Linq;
using System.Collections.Generic;

namespace _1.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal priseOfBulet = decimal.Parse(Console.ReadLine());
            int gunBarol = int.Parse(Console.ReadLine());
            int[] holdBulets = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] holdLoks = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            decimal valuOfINtelegens = decimal.Parse(Console.ReadLine());

            Stack<int> bulets = new Stack<int>();
            for (int i = 0; i < holdBulets.Length; i++)
            {
                bulets.Push(holdBulets[i]);
            }

            Queue<int> locks = new Queue<int>();
            for (int i = 0; i < holdLoks.Length; i++)
            {
                locks.Enqueue(holdLoks[i]);
            }

            int count = 1;
            while (bulets.Count > 0 && locks.Count > 0)
            {
                if (bulets.Pop() > locks.Peek())
                {
                    Console.WriteLine("Ping!");
                }
                else
                {
                    locks.Dequeue();
                    Console.WriteLine("Bang!");
                }
                if (count % gunBarol == 0 && bulets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                }
                count += 1;
            }

            decimal cost = (decimal)(holdBulets.Length - bulets.Count) * priseOfBulet;

            if (locks.Count == 0)
            {
                Console.WriteLine($"{bulets.Count} bullets left. Earned ${valuOfINtelegens - cost}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }
    }
}
