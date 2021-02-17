using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals
{
	public abstract class Bird : Animal
	{
		private double wingSize;

		public Bird(string name, double weight, int foodEaten, double wingSize) 
			: base(name, weight, foodEaten)
		{
			this.WingSize = wingSize;
		}

		public double WingSize
		{
			get => this.wingSize;
			set => this.wingSize = value;
		}

		public override string ToString()
		{
			return base.ToString() + $"{this.wingSize}, {this.Weight}, {this.FoodEaten}]";
		}
	}
}
