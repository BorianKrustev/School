using System;
using System.Linq;
using System.Collections.Generic;

namespace _7.TheV_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, SortedSet<string>>> vloggers = new Dictionary<string, Dictionary<string, SortedSet<string>>>();

            string input = Console.ReadLine();
            while (input != "Statistics")
            {
                string[] elemsts = input.Split(" ");

                string user = elemsts[0];
                string comand = elemsts[1];
                string targetUser = elemsts[2];

                if (comand == "joined")
                {
                    if (!vloggers.ContainsKey(user))
                    {
                        vloggers.Add(user, new Dictionary<string, SortedSet<string>>());
                        vloggers[user].Add("following", new SortedSet<string>());
                        vloggers[user].Add("followers", new SortedSet<string>());
                    }
                }
                else if (comand == "followed")
                {
                    bool isSamePurson = user == targetUser;
                    if (vloggers.ContainsKey(user) && vloggers.ContainsKey(targetUser) && !isSamePurson)
                    {
                        vloggers[user]["following"].Add(targetUser);
                        vloggers[targetUser]["followers"].Add(user);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            var sortedVlogers = vloggers.OrderByDescending(x => x.Value["followers"].Count).ThenBy(x => x.Value["following"].Count);

            int counter = 1;
            foreach (var item in sortedVlogers)
            {
                Console.WriteLine($"{counter++}. {item.Key} : {item.Value["followers"].Count} followers, {item.Value["following"].Count} following");
                if (counter == 2)
                {
                    foreach (var followerName in item.Value["followers"])
                    {
                        Console.WriteLine($"*  {followerName}");
                    }
                }
            }
        }
    }
}
