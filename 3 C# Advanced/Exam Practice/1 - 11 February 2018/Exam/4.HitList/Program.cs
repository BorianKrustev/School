using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace _4.HitList
{
    class Program
    {
        static void Main(string[] args)
        {
            int targetIndex = int.Parse(Console.ReadLine());

            Dictionary<string, SortedDictionary<string, string>> people = new Dictionary<string, SortedDictionary<string, string>>();

            string input = Console.ReadLine();

            while (input != "end transmissions")
            {
                string[] nameAndStuf = input.Split("=");
                string name = nameAndStuf[0];
                string[] Stuf = nameAndStuf[1].Split(";");

                if (!people.ContainsKey(name))
                {
                    people.Add(name, new SortedDictionary<string, string>());
                }

                for (int i = 0; i < Stuf.Length; i++)
                {
                    string[] hold = Stuf[i].Split(":");

                    if (!people[name].ContainsKey(hold[0]))
                    {
                        people[name].Add(hold[0], hold[1]);
                    }
                    else
                    {
                        people[name][hold[0]] = hold[1];
                    }
                }

                input = Console.ReadLine();
            }

            string[] holdKill = Console.ReadLine().Split();
            string kill = holdKill[1];

            int count = 0;

            Console.WriteLine($"Info on {kill}:");
            foreach (var item in people[kill])
            {
                Console.WriteLine($"---{item.Key}: {item.Value}");
                count += item.Key.Count();
                count += item.Value.Count();
            }

            Console.WriteLine($"Info index: {count}");

            if (count >= targetIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {targetIndex - count} more info.");
            }
        }
    }
}
