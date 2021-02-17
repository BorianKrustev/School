using System;
using System.Collections.Generic;

namespace _3.OldestFamilyMember
{
	class StarUp
	{
		static void Main(string[] args)
		{
			Family famaly = new Family();

			int n = int.Parse(Console.ReadLine());

			for (int i = 0; i < n; i++)
			{
				string[] input = Console.ReadLine().Split();

				string name = input[0];
				int age = int.Parse(input[1]);

				Person person = new Person(name, age);

				famaly.AddMember(person);
			}

			Person oldesMeber = famaly.GetOldestMember();

			Console.WriteLine($"{oldesMeber.Name} {oldesMeber.Age}");
		}
	}
}
