using _6.Animals.Animals;
using _6.Animals.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _6.Animals.Core
{
	public class Engine
	{
		private List<Animal> animals;
		private AnimalFactory animalFactory;

		public Engine()
		{
			this.animalFactory = new AnimalFactory();
			this.animals = new List<Animal>();
		}

		public void Run()
		{
			while (true)
			{
				string input = Console.ReadLine();
				if (input == "Beast!") break;

				try
				{
					string[] data = Console.ReadLine().Split();

					string name = data[0];
					int age = int.Parse(data[1]);
					string gender = data[2];

					Animal animal = animalFactory.CreatAnimal(input, name, age, gender);
					animals.Add(animal);
				}
				catch (ArgumentException ex)
				{
					Console.WriteLine(ex.Message);
				}
			}

			Print();
		}

		private void Print()
		{
			foreach (var item in animals)
			{
				Console.WriteLine(item.GetType().Name);
				Console.WriteLine(item.ToString());
				item.ProduceSound();
			}
		}
	}
}
