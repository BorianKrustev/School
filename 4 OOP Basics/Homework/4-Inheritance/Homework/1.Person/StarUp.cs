using System;

namespace _1.Person
{
	public class StarUp
	{
		static void Main(string[] args)
		{
			string name = Console.ReadLine();
			int age = int.Parse(Console.ReadLine());

			try
			{
				Child child = new Child(name, age);
				Console.WriteLine(child);
			}
			catch (ArgumentException ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}
