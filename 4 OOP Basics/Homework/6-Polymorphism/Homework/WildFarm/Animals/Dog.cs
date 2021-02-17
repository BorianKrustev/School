using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals
{
	public class Dog : Mammal
	{
		public Dog(string name, double weight, int foodEaten, string livingRegion) 
			: base(name, weight, foodEaten, livingRegion)
		{
		}

		override public void Sound()
		{
			Console.WriteLine("Woof!");
		}

		public override string ToString()
		{
			return base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
		}
	}
}
