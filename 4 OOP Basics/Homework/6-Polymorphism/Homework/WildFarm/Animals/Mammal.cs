using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals
{
	public abstract class Mammal : Animal
	{
		private string livingRegion;

		public Mammal(string name, double weight, int foodEaten, string livingRegion) 
			: base(name, weight, foodEaten)
		{
			this.LivingRegion = livingRegion;
		}

		public string LivingRegion
		{
			get => livingRegion;
			set => livingRegion = value;
		}
	}
}
