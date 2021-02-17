﻿using StorageMaster.Products;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Vehicles
{
	public abstract class Vehicle
	{
		private int capacity;
		private List<Product> trunk;

		public Vehicle(int capacity)
		{
			this.Capacity = capacity;

			this.trunk = new List<Product>();
		}

		public int Capacity
		{
			get { return this.capacity; }
			private set { this.capacity = value; }
		}

		public IReadOnlyCollection<Product> Trunk => trunk.AsReadOnly();

		public bool IsFull => this.Trunk.Sum(x => x.Weight) >= this.Capacity;

		public bool IsEmpty => this.Trunk.Count == 0;

		public void LoadProduct(Product product)
		{
			if (this.IsFull)
			{
				throw new InvalidOperationException("Vehicle is full!");
			}

			this.trunk.Add(product);
		}

		public Product Unload()
		{
			if (this.IsEmpty)
			{
				throw new InvalidOperationException("No products left in vehicle!");
			}

			Product product = this.trunk[this.trunk.Count - 1];
			this.trunk.RemoveAt(this.trunk.Count - 1);

			return product;
		}
	}
}
