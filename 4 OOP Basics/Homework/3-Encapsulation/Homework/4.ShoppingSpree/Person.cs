using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _4.ShoppingSpree
{
	public class Person
	{
		private string name;
		private decimal money;
		private List<Product> products;

		public Person(string name, decimal money)
		{
			this.Name = name;
			this.Money = money;
			this.Products = new List<Product>();
		}

		public string Name
		{
			get => this.name;
			set
			{
				if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException("Name cannot be empty");
				}
				this.name = value;
			}
		}

		public decimal Money
		{
			get => this.money;
			set
			{
				if (value < 0)
				{
					throw new ArgumentException("Money cannot be negative");
				}
				this.money = value;
			}
		}

		public List<Product> Products
		{
			get => this.products;
			set => this.products = value;
		}


		public void Add(Product produckt)
		{
			decimal cost = produckt.Cost;

			if (this.money < cost)
			{
				Console.WriteLine($"{this.Name} can't afford {produckt.Name}");
			}
			else
			{
				this.Products.Add(produckt);
				this.Money -= cost;
				Console.WriteLine($"{this.Name} bought {produckt.Name}");
			}
		}

		public override string ToString()
		{
			if (this.Products.Count <= 0)
			{
				return $"{this.name} - Nothing bought";
			}
			else
			{
				return $"{this.Name} - {string.Join(", ", this.Products.Select(x => x.ToString()))}";
			}
		}
	}
}
