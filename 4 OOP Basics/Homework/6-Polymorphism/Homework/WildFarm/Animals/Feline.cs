using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals
{
	public abstract class Feline : Mammal
	{
		private string breed;

		public Feline(string name, double weight, int foodEaten, string livingRegion, string breed) 
			: base(name, weight, foodEaten, livingRegion)
		{
			this.Breed = breed;
		}

		public string Breed
		{
			get => breed;
			set => breed = value;
		}

		public override string ToString()
		{
			return base.ToString() + $"{this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
		}
	}
}
