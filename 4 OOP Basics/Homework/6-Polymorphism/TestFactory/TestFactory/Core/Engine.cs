using System;
using System.Collections.Generic;
using System.Text;
using TestFactory.Animals;
using TestFactory.Animals.Birds.Factory;

namespace TestFactory.Core
{
	public class Engine
	{
		private BirdFactory birdFactory;
		private List<Animal> animals;
		private Animal animal;

		public Engine()
		{
			birdFactory = new BirdFactory();
			animals = new List<Animal>();
		}

		public void Run()
		{
			//Owl Bob 25.5 15.5
			string[] input = Console.ReadLine().Split();

			string type = input[0];
			string name = input[1];
			double weight = double.Parse(input[2]);

			if (type == "Owl" || type == "Hen")
			{
				double wingSpan = double.Parse(input[3]);

				animal = this.birdFactory.CreatBird(type, name, weight, wingSpan);
			}

			animals.Add(animal);
		}
	}
}
