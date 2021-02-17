using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _5.PizzaCalories
{
	public class Pizza
	{
		private string name;
		private Dough dough;
		private List<Topping> toppings;

		public Pizza(string name)
		{
			this.Name = name;
			this.Toppings = new List<Topping>();
		}

		public Dough Dough
		{
			get { return dough; }
			set { dough = value; }
		}

		public List<Topping> Toppings
		{
			get { return toppings; }
			set { toppings = value; }
		}

		public string Name
		{
			get { return name; }
			set
			{
				if (string.IsNullOrEmpty(value) || value.Length > 15)
				{
					Exception ex = new ArgumentException($"Pizza name should be between 1 and 15 symbols.");
					Console.WriteLine(ex.Message);
					Environment.Exit(0);

				}
				name = value;
			}
		}

		public void Add(Topping toping)
		{
			this.Toppings.Add(toping);
		}

		public double GetCaloris()
		{
			double doughCaloris = this.Dough.CalculateDoughCalories();
			double toppingsCaloris = this.Toppings.Sum(x => x.CalculateToppingsCalories());

			return doughCaloris + toppingsCaloris;
		}
	}
}
