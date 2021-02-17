using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.Pizza_Calories
{
	public class Dough
	{
		private string flour;
		private string bakingTechnique;
		private int wegiht;

		public Dough(string flour, string bakingTechnique)
		{
			this.Flour = flour;
			this.BakingTechnique = bakingTechnique;
		}

		public string Flour
		{
			get => flour;
			set
			{
				if (value.ToLower() != "white" || value.ToLower() != "wholegrain")
				{
					Exception ex = new ArgumentException("Invalid type of dough.");
					Console.WriteLine(ex.Message);
					Environment.Exit(0);
				}
				flour = value.ToLower();
			}
		}

		public string BakingTechnique
		{
			get => bakingTechnique;
			set
			{
				if (value.ToLower() != "crispy" || value.ToLower() != "chewy" || value.ToLower() != "homemade")
				{
					Exception ex = new ArgumentException("Invalid type of dough.");
					Console.WriteLine(ex.Message);
					Environment.Exit(0);
				}
				bakingTechnique = value.ToLower();
			}
		}

		public int Wegiht
		{
			get => wegiht;
			set
			{
				if (value < 1 || value > 200)
				{
					Exception ex = new ArgumentException("Dough weight should be in the range [1..200].");
					Console.WriteLine(ex.Message);
					Environment.Exit(0);
				}
				wegiht = value;
			}
		}

		public double DoughCalories { get => this.CalculateDougeCalories(); }

		private double CalculateDougeCalories()
		{
			double flourModifier = this.Flour == "white" ? 1.5 : 1.0;
			double bakingModifier = this.BakingTechnique == "crispy" ? 0.9 : this.BakingTechnique == "chewy" ? 1.1 : 1.0;

			return this.Wegiht * 2 * flourModifier * bakingModifier;
		}
	}
}