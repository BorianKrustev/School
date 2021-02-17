using System;
using System.Collections.Generic;
using System.Text;

namespace _5.PizzaCalories
{
	public class Topping
	{
		private string type;
		private double weight;

		public Topping(string type, double weight)
		{
			this.Type = type;
			this.Weight = weight;
		}

		public string Type
		{
			get => this.type;
			set
			{
				if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
				{
					Exception ex = new ArgumentException($"Cannot place {value} on top of your pizza.");
					Console.WriteLine(ex.Message);
					Environment.Exit(0);
				}
				this.type = value;
			}
		}

		public double Weight
		{
			get => this.weight;
			set
			{
				if (value < 1 || value > 50)
				{
					Exception ex = new ArgumentException($"{this.Type} weight should be in the range [1..50].");
					Console.WriteLine(ex.Message);
					Environment.Exit(0);
				}
				this.weight = value;
			}
		}

		public double CalculateToppingsCalories()
		{
			double typeGr = GetType();

			return 2 * this.Weight * typeGr;
		}

		private double GetType()
		{
			switch (this.Type.ToLower())
			{
				case "meat":
					return 1.2;
				case "veggies":
					return 0.8;
				case "cheese":
					return 1.1;
				case "sauce":
					return 0.9;
				default:
					return 0.0;
			}
		}
	}
}
