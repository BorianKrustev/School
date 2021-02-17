using AnimalCentre.Animals;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Hotels
{
	public class Hotel : IHotel
	{
		private int capacity;
		private Dictionary<string, IAnimal> animals;

		public Hotel()
		{
			this.Capacity = 10;

			this.animals = new Dictionary<string, IAnimal>();
		}

		public IReadOnlyDictionary<string, IAnimal> Animals => animals;

		public int Capacity
		{
			get { return capacity; }
			set { capacity = 10; }
		}

		public void Accommodate(IAnimal animal)
		{
			if (animals.Count >= 10)
			{
				throw new InvalidOperationException("Not enough capacity");
			}

			if (this.Animals.ContainsKey(animal.Name))
			{
				throw new ArgumentException($"Animal {animal.Name} already exist");
			}

			this.animals.Add(animal.Name, animal);
		}

		public void Adopt(string animalName, string owner)
		{
			if (!this.Animals.ContainsKey(animalName))
			{
				throw new ArgumentException("Animal {animal name} does not exist");
			}

			this.Animals[animalName].Owner = owner;
			this.Animals[animalName].IsAdopt = true;
			this.animals.Remove(animalName);
		}
	}
}
