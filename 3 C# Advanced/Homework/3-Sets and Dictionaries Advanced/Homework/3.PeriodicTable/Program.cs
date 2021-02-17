using System;
using System.Linq;
using System.Collections.Generic;

namespace _3.PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            SortedSet<string> set = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] elements = Console.ReadLine().Split().ToArray();

                for (int f = 0; f < elements.Length; f++)
                {
                    set.Add(elements[f]);
                }
            }

            Console.WriteLine($"{string.Join(" ", set)}");
        }
    }
}