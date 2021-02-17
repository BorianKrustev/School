using System;
using System.Linq;
using System.Collections.Generic;

namespace _4.EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<int, int> dic = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (!dic.ContainsKey(number))
                {
                    dic.Add(number, 1);
                }
                else
                {
                    dic[number] += 1;
                }
            }

            foreach (var item in dic)
            {
                if (item.Value % 2 == 0)
                {
                    Console.WriteLine($"{item.Key}");
                }
            }
        }
    }
}