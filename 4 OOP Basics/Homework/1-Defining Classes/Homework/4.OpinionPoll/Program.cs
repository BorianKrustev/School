using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.OpinionPoll
{
	class Program
	{
		static void Main(string[] args)
		{
			List<Person> pepol = new List<Person>();

			int n = int.Parse(Console.ReadLine());

			for (int i = 0; i < n; i++)
			{
				string[] input = Console.ReadLine().Split();

				string name = input[0];
				int age = int.Parse(input[1]);

				Person person = new Person(name, age);

				if (age > 30)
				{
					pepol.Add(person);
				}
			}

			pepol = pepol.OrderBy(x => x.Name).ToList();

			foreach (var item in pepol)
			{
				Console.WriteLine($"{item.Name} {item.Age}");
			}
		}
	}
}
