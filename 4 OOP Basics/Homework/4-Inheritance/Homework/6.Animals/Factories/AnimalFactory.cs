using _6.Animals.Animals;
using System;
using System.Collections.Generic;
using System.Text;

namespace _6.Animals.Factories
{
	public class AnimalFactory
	{
		public Animal CreatAnimal(string type, string name, int age, string gender)
		{
			switch (type)
			{
				case "Cat":
					return new Cat(name, age, gender);
				case "Dog":
					return new Dog(name, age, gender);
				case "Frog":
					return new Frog(name, age, gender);
				case "Kitten":
					return new Kitten(name, age);
				case "Tomcat":
					return new Tomcat(name, age);
				default:
					throw new Exception("Invalid input!");
			}
		}
	}
}
