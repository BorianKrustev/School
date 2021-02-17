using System;
using System.Collections.Generic;
using System.Text;
using TestFactory.Animals.Contracts;

namespace TestFactory.Animals
{
	public abstract class Animal : IAnimal
	{
		private string name;
		private double weight;
		private int foodEaten;

		public Animal(string name, double weight)
		{
			this.Name = name;
			this.Weight = weight;
		}

		public int FoodEaten
		{
			get { return foodEaten; }
			set { foodEaten = value; }
		}

		public double Weight
		{
			get { return weight; }
			set { weight = value; }
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public abstract void ProdusSound();

		public abstract void EatFood();
	}
}
