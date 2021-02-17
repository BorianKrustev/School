using System;
using System.Collections.Generic;
using System.Text;

namespace _5.PizzaCalories
{
	public class Dough
	{
		private string flourType;
		private string bakingTechnique;
		private double weight;

		public Dough(string flourType, string bakingTechnique, double weight)
		{
			this.FlourType = flourType;
			this.BakingTechnique = bakingTechnique;
			this.Weight = weight;
		}

		public double Weight
		{
			get { return weight; }
			set
			{
				if (value < 1 || value > 200)
				{
					Exception ex = new ArgumentException("Dough weight should be in the range [1..200].");
					Console.WriteLine(ex.Message);
					Environment.Exit(0);
				}
				weight = value;
			}
		}

		public string BakingTechnique
		{
			get { return this.bakingTechnique; }
			set
			{
				if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
				{
					Exception ex = new ArgumentException("Invalid type of dough.");
					Console.WriteLine(ex.Message);
					Environment.Exit(0);
				}
				this.bakingTechnique = value;
			}
		}

		public string FlourType
		{
			get { return this.flourType; }
			set
			{
				if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
				{
					Exception ex = new ArgumentException("Invalid type of dough.");
					Console.WriteLine(ex.Message);
					Environment.Exit(0);
				}
				this.flourType = value;
			}
		}

		public double CalculateDoughCalories()
		{
			double flourGr = GetFlourType();
			double bakingGr = GetBakingTechnique();

			return 2 * this.Weight * flourGr * bakingGr;
		}

		private double GetFlourType()
		{
			switch (this.FlourType.ToLower())
			{
				case "white":
					return 1.5;
				case "wholegrain":
					return 1.0;
				default:
					return 0.0;
			}
		}

		private double GetBakingTechnique()
		{
			switch (this.BakingTechnique.ToLower())
			{
				case "crispy":
					return 0.9;
				case "chewy":
					return 1.1;
				case "homemade":
					return 1.0;
				default:
					return 0.0;
			}
		}
	}
}
