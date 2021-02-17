using System;
using System.Collections.Generic;
using System.Text;

namespace TestFactory.Animals.Birds
{
	public abstract class Bird : Animal
	{
		private double wingSize;

		public Bird(string name, double weight, double wingSize) 
			: base(name, weight)
		{
			this.WingSize = wingSize;
		}

		public double WingSize
		{
			get => this.wingSize;
			set => this.wingSize = value;
		}
	}
}
