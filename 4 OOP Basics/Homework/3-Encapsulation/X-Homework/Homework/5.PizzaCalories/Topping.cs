using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Pizza_Calories
{
	public class Topping
	{
		private string type;
		private int weight;

		public Topping(string type, int weight)
		{
			this.Type = type;
			this.Weight = weight;
		}

		public string Type
		{
			get => type;
			set
			{
				if (value.ToLower() != "meat" || value.ToLower() != "veggies" || value.ToLower() != "cheese" || value.ToLower() != "sauce")
				{
					Exception ex = new ArgumentException($"Cannot place {value} on top of your pizza.");
					Console.WriteLine(ex.Message);
					Environment.Exit(0);
				}
				type = value;
			}
		}

		public int Weight
		{
			get => weight;
			set
			{
				if (value < 1 || value > 50)
				{
					string tipe = char.ToUpper(this.Type[0]) + this.Type.Substring(1);

					Exception ex = new ArgumentException($"{tipe} weight should be in the range [1..50].");
					Console.WriteLine(ex.Message);
					Environment.Exit(0);
				}
				weight = value;
			}
		}

		public double ToppingCaloris
		{
			get => this.CalculateTopingCaloris();
		}

		private double CalculateTopingCaloris()
		{
			double modifier = this.Type == "meat" ? 1.2 : this.Type == "veggies" ? 0.8 : this.Type == "cheese" ? 1.1 : 0.9;

			return this.Weight * 2 * modifier;
		}
	}
}