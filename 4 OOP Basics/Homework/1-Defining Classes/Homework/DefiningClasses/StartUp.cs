using System;

namespace DefiningClasses
{
	class StartUp
	{
		static void Main(string[] args)
		{
			Person Bob = new Person();
			Person Deiv = new Person(5);
			Person Garbo = new Person("Gar", 3);

			Console.WriteLine($"{Bob.Name} {Bob.Age}");
			Console.WriteLine($"{Deiv.Name} {Deiv.Age}");
			Console.WriteLine($"{Garbo.Name} {Garbo.Age}");
		}
	}
}
