using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Core
{
	public class Engine
	{
		AnimalCentre animalCentre;

		public Engine()
		{
			animalCentre = new AnimalCentre();
		}

		public void Run()
		{
			string hold = Console.ReadLine();

			while (hold != "End")
			{
				string[] comands = hold.Split();
				string type = comands[0];

				try
				{
					if (type == "RegisterAnimal")
					{
						Console.WriteLine(animalCentre.RegisterAnimal(comands[1], comands[2], int.Parse(comands[3]), int.Parse(comands[4]), int.Parse(comands[5])));
					}
					else if (type == "Chip")
					{
						Console.WriteLine(animalCentre.Chip(comands[1], int.Parse(comands[2])));
					}
					else if (type == "Vaccinate")
					{
						Console.WriteLine(animalCentre.Vaccinate(comands[1], int.Parse(comands[2])));
					}
					else if (type == "Fitness")
					{
						Console.WriteLine(animalCentre.Fitness(comands[1], int.Parse(comands[2])));
					}
					else if (type == "Play")
					{
						Console.WriteLine(animalCentre.Play(comands[1], int.Parse(comands[2])));
					}
					else if (type == "DentalCare")
					{
						Console.WriteLine(animalCentre.DentalCare(comands[1], int.Parse(comands[2])));
					}
					else if (type == "NailTrim")
					{
						Console.WriteLine(animalCentre.NailTrim(comands[1], int.Parse(comands[2])));
					}
					else if (type == "Adopt")
					{
						Console.WriteLine(animalCentre.Adopt(comands[1], comands[2]));
					}
					else if (type == "History")
					{
						Console.WriteLine(comands[1]);
						string result = animalCentre.History(comands[1]);
						Console.WriteLine(result);
					}
				}
				catch (InvalidOperationException ex)
				{
					Console.WriteLine($"InvalidOperationException: {ex.Message}");
				}
				catch (ArgumentException ex)
				{
					Console.WriteLine($"ArgumentException: {ex.Message}");
				}

				hold = Console.ReadLine();
			}

			Dictionary<string, List<IAnimal>> adopted = new Dictionary<string, List<IAnimal>>(animalCentre.adoptedStuff);

			foreach (var item in adopted.OrderBy(x => x.Key))
			{
				Console.WriteLine($"--Owner: {item.Key}");
				Console.Write("    - Adopted animals: ");
				foreach (var curentAnimal in item.Value)
				{
					Console.Write($"{curentAnimal.Name} ");
				}

				Console.WriteLine();
			}
		}
	}
}
