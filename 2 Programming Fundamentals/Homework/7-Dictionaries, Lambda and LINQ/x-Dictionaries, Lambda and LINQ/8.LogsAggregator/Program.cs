using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_Logs_Aggregator
{
    class Program
    {
        static void Main(string[] args)
        {
            ushort lines = ushort.Parse(Console.ReadLine());
            SortedDictionary<string, SortedDictionary<string, int>> agregator =
                new SortedDictionary<string, SortedDictionary<string, int>>();
            for (ushort i = 1; i <= lines; i++)
            {
                string[] currentLine = Console.ReadLine().Split();
                string user = currentLine[1];
                string ip = currentLine[0];
                ushort duration = ushort.Parse(currentLine[2]);

                if (!agregator.ContainsKey(user))
                {
                    agregator.Add(user, new SortedDictionary<string, int>());
                }
                if (!agregator[user].ContainsKey(ip))
                {
                    agregator[user].Add(ip, duration);
                }
                else
                {
                    agregator[user][ip] += duration;
                }
            }
            foreach (var user in agregator)
            {
                Console.WriteLine($"{user.Key}: {user.Value.Sum(x => x.Value)} [{string.Join(", ", user.Value.Keys.OrderBy(x => x))}]");
            }
        }
    }
}