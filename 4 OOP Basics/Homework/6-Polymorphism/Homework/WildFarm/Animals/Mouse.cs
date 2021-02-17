using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals
{
	public class Mouse : Mammal
	{
		public Mouse(string name, double weight, int foodEaten, string livingRegion) 
			: base(name, weight, foodEaten, livingRegion)
		{
		}

		override public void Sound()
		{
			Console.WriteLine("Squeak");
		}

		public override string ToString()
		{
			return base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
		}
	}
}
