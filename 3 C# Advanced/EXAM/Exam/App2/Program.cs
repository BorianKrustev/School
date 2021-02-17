using System;
using System.Linq;
using System.Collections.Generic;

namespace App1
{
	class Program
	{
		static void Main(string[] args)
		{
			Dictionary<string, Dictionary<string, int>> users = new Dictionary<string, Dictionary<string, int>>();

			while (true)
			{
				string input = Console.ReadLine();
				if (input == "end" || input == "End") break;

				string[] check = input.Split(" ").ToArray();

				if (check[0] == "ban")
				{
					string[] hold = input.Split(" ").ToArray();

					string name = hold[1];

					if (users.ContainsKey(name))
					{
						users.Remove(name);
					}
				}
				else
				{
					string[] hold = input.Split(" -> ").ToArray();

					string name = hold[0];
					string tag = hold[1];
					int licks = int.Parse(hold[2]);

					if (!users.ContainsKey(name))
					{
						users.Add(name, new Dictionary<string, int>());
					}

					if (!users[name].ContainsKey(tag))
					{
						users[name].Add(tag, licks);
					}
					else
					{
						users[name][tag] += licks;
					}
				}
			}

			var print = users.OrderByDescending(x => x.Value.Sum(f => f.Value)).ThenBy(x => x.Value.Count).ToList();

			foreach (var item in print)
			{
				Console.WriteLine($"{item.Key}");

				foreach (var tags in item.Value)
				{
					Console.WriteLine($"- {tags.Key}: {tags.Value}");
				}
			}
		}
	}
}