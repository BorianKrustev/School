using System;
using System.Linq;
using System.Collections.Generic;

namespace _2.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] siz = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            HashSet<int> setOne = new HashSet<int>();
            HashSet<int> setTwo = new HashSet<int>();

            for (int i = 0; i < siz[0]; i++)
            {
                int n = int.Parse(Console.ReadLine());

                setOne.Add(n);
            }

            for (int i = 0; i < siz[1]; i++)
            {
                int n = int.Parse(Console.ReadLine());

                setTwo.Add(n);
            }

            HashSet<int> final = new HashSet<int>();

            foreach (var n in setOne)
            {
                if (setTwo.Contains(n))
                {
                    final.Add(n);
                }
            }

            Console.WriteLine($"{string.Join(" ", final)}");
        }
    }
}