using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using WildFarm.Animals;
using WildFarm.Animals.Contracts;

namespace WildFarm.Core
{
	public class Engine
	{
		List<IAnimal> animals;

		public Engine()
		{
			animals = new List<IAnimal>();
		}

		public void Run()
		{
			string curentTypeAnimal = "";

			for (int i = 0; i > -1; i++)
			{
				string[] input = Console.ReadLine().Split();
				if (input[0] == "End") break;

				if (i % 2 == 0)
				{
					curentTypeAnimal = input[0];
					AddAnimal(input);
				}
				else
				{
					string foodType = input[0];
					int quantity = int.Parse(input[1]);

					bool gotIn = false;

					if (curentTypeAnimal == "Hen")
					{
						animals.Last().Weight += (quantity * 0.35);
						animals.Last().FoodEaten += quantity;
						gotIn = true;
					}
					else if (curentTypeAnimal == "Owl" && foodType == "Meat")
					{
						animals.Last().Weight += (quantity * 0.25);
						animals.Last().FoodEaten += quantity;
						gotIn = true;
					}
					else if (curentTypeAnimal == "Mouse" && foodType == "Vegetable" || foodType == "Fruit")
					{
						animals.Last().Weight += (quantity * 0.10);
						animals.Last().FoodEaten += quantity;
						gotIn = true;
					}
					else if (curentTypeAnimal == "Cat" && foodType == "Vegetable" || foodType == "Meat")
					{
						animals.Last().Weight += (quantity * 0.30);
						animals.Last().FoodEaten += quantity;
						gotIn = true;
					}
					else if (curentTypeAnimal == "Tiger" && foodType == "Meat")
					{
						animals.Last().Weight += (quantity * 1.00);
						animals.Last().FoodEaten += quantity;
						gotIn = true;
					}
					else if (curentTypeAnimal == "Dog" && foodType == "Meat")
					{
						animals.Last().Weight += (quantity * 0.40);
						animals.Last().FoodEaten += quantity;
						gotIn = true;
					}

					if (gotIn == false)
					{
						Console.WriteLine($"{curentTypeAnimal} does not eat {foodType}!");
					}
				}
			}

			foreach (var item in animals)
			{
				Console.WriteLine(item);
			}
		}

		private void AddAnimal(string[] input)
		{
			string type = input[0];
			string name = input[1];
			double weight = double.Parse(input[2]);

			IAnimal curentAnimal;

			if (type == "Cat")
			{
				string livingRegion = input[3];
				string breed = input[4];

				curentAnimal = new Cat(name, weight, 0, livingRegion, breed);
				animals.Add(curentAnimal);
			}
			else if (type == "Tiger")
			{
				string livingRegion = input[3];
				string breed = input[4];

				curentAnimal = new Tiger(name, weight, 0, livingRegion, breed);
				animals.Add(curentAnimal);
			}
			else if (type == "Owl")
			{
				double wingSize = double.Parse(input[3]);

				curentAnimal = new Owl(name, weight, 0, wingSize);
				animals.Add(curentAnimal);
			}
			else if (type == "Hen")
			{
				double wingSize = double.Parse(input[3]);

				curentAnimal = new Hen(name, weight, 0, wingSize);
				animals.Add(curentAnimal);
			}
			else if (type == "Dog")
			{
				string livingRegion = input[3];

				curentAnimal = new Dog(name, weight, 0, livingRegion);
				animals.Add(curentAnimal);
			}
			else
			{
				string livingRegion = input[3];

				curentAnimal = new Mouse(name, weight, 0, livingRegion);
				animals.Add(curentAnimal);
			}

			curentAnimal.Sound();
		}
	}
}
