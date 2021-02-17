using AnimalCentre.Animals;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Constructors
{
	public class AnimalConstructor
	{
		public Animal CreateAnimal(string type, string name, int energy, int happiness, int procedureTime)
		{
			Animal animal = null;

			switch (type)
			{
				case "Cat":
					animal = new Cat(name, energy, happiness, procedureTime);
					break;
				case "Dog":
					animal = new Dog(name, energy, happiness, procedureTime);
					break;
				case "Lion":
					animal = new Lion(name, energy, happiness, procedureTime);
					break;
				case "Pig":
					animal = new Pig(name, energy, happiness, procedureTime);
					break;
				default:
					throw new ArgumentException("type of animal is rong");
			}

			return animal;
		}
	}
}
