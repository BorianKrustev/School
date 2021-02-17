using AnimalCentre.Animals;
using AnimalCentre.Hotels;
using AnimalCentre.Models.Constructors;
using AnimalCentre.Models.Contracts;
using AnimalCentre.Procedures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Core
{
	public class AnimalCentre
	{
		AnimalConstructor animalConstructor;
		Hotel hotel;
		public Dictionary<string, List<IAnimal>> adoptedStuff;

		Procedure procedureChip;
		Procedure procedureVaccinate;
		Procedure procedureFitness;
		Procedure procedurePlay;
		Procedure procedureDentalCare;
		Procedure procedureNailTrim;

		public AnimalCentre()
		{
			animalConstructor = new AnimalConstructor();
			hotel = new Hotel();

			procedureChip = new Chip();
			procedureVaccinate = new Vaccinate();
			procedureFitness = new Fitness();
			procedurePlay = new Play();
			procedureDentalCare = new DentalCare();
			procedureNailTrim = new NailTrim();

			adoptedStuff = new Dictionary<string, List<IAnimal>>();
		}

		public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
		{
			Animal animal = animalConstructor.CreateAnimal(type, name, energy, happiness, procedureTime);

			hotel.Accommodate(animal);

			string result = $"Animal {animal.Name} registered successfully";
			return result;
		}

		public string Chip(string name, int procedureTime)
		{
			if (!hotel.Animals.ContainsKey(name))
			{
				throw new ArgumentException($"Animal {name} does not exist");
			}

			procedureChip.DoService(hotel.Animals[name], procedureTime);

			string result = $"{name} had chip procedure";
			return result;
		}

		public string Vaccinate(string name, int procedureTime)
		{
			if (!hotel.Animals.ContainsKey(name))
			{
				throw new ArgumentException($"Animal {name} does not exist");
			}

			procedureVaccinate.DoService(hotel.Animals[name], procedureTime);

			string result = $"{name} had vaccination procedure";
			return result;
		}

		public string Fitness(string name, int procedureTime)
		{
			if (!hotel.Animals.ContainsKey(name))
			{
				throw new ArgumentException($"Animal {name} does not exist");
			}

			procedureFitness.DoService(hotel.Animals[name], procedureTime);

			string result = $"{name} had fitness procedure";
			return result;
		}

		public string Play(string name, int procedureTime)
		{
			if (!hotel.Animals.ContainsKey(name))
			{
				throw new ArgumentException($"Animal {name} does not exist");
			}

			procedurePlay.DoService(hotel.Animals[name], procedureTime);

			string result = $"{name} was playing for {procedureTime} hours";
			return result;
		}

		public string DentalCare(string name, int procedureTime)
		{
			if (!hotel.Animals.ContainsKey(name))
			{
				throw new ArgumentException($"Animal {name} does not exist");
			}

			procedureDentalCare.DoService(hotel.Animals[name], procedureTime);

			string result = $"{name} had dental care procedure";
			return result;
		}

		public string NailTrim(string name, int procedureTime)
		{
			if (!hotel.Animals.ContainsKey(name))
			{
				throw new ArgumentException($"Animal {name} does not exist");
			}

			procedureNailTrim.DoService(hotel.Animals[name], procedureTime);

			string result = $"{name} had nail trim procedure";
			return result;
		}

		public string Adopt(string animalName, string owner)
		{
			if (!hotel.Animals.ContainsKey(animalName))
			{
				throw new ArgumentException($"Animal {animalName} does not exist");
			}

			IAnimal animal = hotel.Animals[animalName];

			hotel.Adopt(animalName, owner);

			string result = "";

			if (animal.IsChipped)
			{
				result = $"{owner} adopted animal with chip";
			}
			else
			{
				result = $"{owner} adopted animal without chip";
			}

			if (!adoptedStuff.ContainsKey(owner))
			{
				adoptedStuff.Add(owner, new List<IAnimal>());
			}

			adoptedStuff[owner].Add(animal);

			return result;
		}

		public string History(string type)
		{
			List<string> holdRawData = new List<string>();
			string result = "";
			List<string> holdResult = new List<string>();

			if (type == "Chip")
			{
				holdRawData = procedureChip.History().Split(":", StringSplitOptions.RemoveEmptyEntries).ToList();

				for (int i = 0; i < holdRawData.Count; i++)
				{
					if (holdRawData[i].StartsWith("Chip"))
					{
						string[] holdData = holdRawData[i].Split();

						holdResult.Add($"    Animal type: {holdData[4]} - {holdData[1]} - Happiness: {holdData[2]} - Energy: {holdData[3]}");
					}
				}
			}
			else if (type == "DentalCare")
			{
				holdRawData = procedureDentalCare.History().Split(":", StringSplitOptions.RemoveEmptyEntries).ToList();

				for (int i = 0; i < holdRawData.Count; i++)
				{
					if (holdRawData[i].StartsWith("DentalCare"))
					{
						string[] holdData = holdRawData[i].Split();

						holdResult.Add($"    Animal type: {holdData[4]} - {holdData[1]} - Happiness: {holdData[2]} - Energy: {holdData[3]}");
					}
				}
			}
			else if (type == "Fitness")
			{
				holdRawData = procedureFitness.History().Split(":").ToList();

				for (int i = 0; i < holdRawData.Count; i++)
				{
					if (holdRawData[i].StartsWith("Fitness"))
					{
						string[] holdData = holdRawData[i].Split();

						holdResult.Add($"    Animal type: {holdData[4]} - {holdData[1]} - Happiness: {holdData[2]} - Energy: {holdData[3]}");
					}
				}
			}
			else if (type == "NailTrim")
			{
				holdRawData = procedureNailTrim.History().Split(":").ToList();

				for (int i = 0; i < holdRawData.Count; i++)
				{
					if (holdRawData[i].StartsWith("NailTrim"))
					{
						string[] holdData = holdRawData[i].Split();

						holdResult.Add($"    Animal type: {holdData[4]} - {holdData[1]} - Happiness: {holdData[2]} - Energy: {holdData[3]}");
					}
				}
			}
			else if (type == "Play")
			{
				holdRawData = procedurePlay.History().Split(":").ToList();

				for (int i = 0; i < holdRawData.Count; i++)
				{
					if (holdRawData[i].StartsWith("Play"))
					{
						string[] holdData = holdRawData[i].Split();

						holdResult.Add($"    Animal type: {holdData[4]} - {holdData[1]} - Happiness: {holdData[2]} - Energy: {holdData[3]}");
					}
				}
			}
			else if (type == "Vaccinate")
			{
				holdRawData = procedureVaccinate.History().Split(":").ToList();

				for (int i = 0; i < holdRawData.Count; i++)
				{
					if (holdRawData[i].StartsWith("Vaccinate"))
					{
						string[] holdData = holdRawData[i].Split();

						holdResult.Add($"    Animal type: {holdData[4]} - {holdData[1]} - Happiness: {holdData[2]} - Energy: {holdData[3]}");
					}
				}
			}
			else
			{
				return "SomtingWent Rong";
			}

			for (int i = 0; i < holdResult.Count; i++)
			{
				if (i == holdResult.Count - 1)
				{
					result += $"{holdResult[i]}";
				}
				else
				{
					result += $"{holdResult[i]}\n";
				}
			}

			return result;
		}
	}
}
