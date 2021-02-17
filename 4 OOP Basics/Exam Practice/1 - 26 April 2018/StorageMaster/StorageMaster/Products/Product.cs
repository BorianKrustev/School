using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Products
{
	public abstract class Product
	{
		private double price;
		private double weight;

		public Product(double price, double weight)
		{
			this.Price = price;
			this.Weight = weight;
		}

		public double Weight
		{
			get { return this.weight; }
			private set { this.weight = value; }
		}

		public double Price
		{
			get { return this.price; }
			private set
			{
				if (value < 0)
				{
					throw new InvalidOperationException("Price cannot be negative!");
				}
				this.price = value;
			}
		}
	}
}
