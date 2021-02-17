using System;
using System.Linq;
using System.Collections.Generic;

namespace _4.OpinionPoll
{
	class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());

			List<Person> list = new List<Person>();

			for (int i = 0; i < n; i++)
			{
				string[] input = Console.ReadLine().Split();
				string name = input[0];
				int age = int.Parse(input[1]);

				Person person = new Person(name, age);

				if (age > 30)
				{
					list.Add(person);
				}
			}

			list = list.OrderBy(x => x.Name).ToList();

			foreach (var item in list)
			{
				Console.WriteLine($"{item.Name} - {item.Age}");
			}
		}
	}
}
