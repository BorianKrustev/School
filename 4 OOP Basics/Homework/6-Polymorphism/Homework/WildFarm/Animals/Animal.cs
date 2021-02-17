using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Animals.Contracts;

namespace WildFarm.Animals
{
	public abstract class Animal : IAnimal
	{
		private string name;
		private double weight;
		private int foodEaten;

		public Animal(string name, double weight, int foodEaten)
		{
			this.Name = name;
			this.Weight = weight;
			this.FoodEaten = foodEaten;
		}

		public int FoodEaten
		{
			get { return this.foodEaten; }
			set { this.foodEaten = value; }
		}

		public double Weight
		{
			get { return this.weight; }
			set { this.weight = value; }
		}

		public string Name
		{
			get { return this.name; }
			set { this.name = value; }
		}

		public abstract void Sound();

		public override string ToString()
		{
			return $"{this.GetType().Name} [{this.Name}, ";
		}
	}
}
