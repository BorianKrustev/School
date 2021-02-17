using System;
using System.Collections.Generic;
using System.Text;

namespace _8.RawData
{
	public class Car
	{
		private string model;
		private Engine engine;
		private Cargo cargo;
		private Tire[] tires;

		public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
		{
			if (tires.Length != 4)
			{
				throw new InvalidOperationException("Tires can not be no more neither less than 4!!!");
			}

			this.model = model;
			this.engine = engine;
			this.cargo = cargo;
			this.tires = tires;
		}

		public string Model
		{
			get => this.model;
			set => this.model = value;
		}

		public Engine Engine
		{
			get => this.engine;
			set => this.engine = value;
		}

		public Cargo Cargo
		{
			get => this.cargo;
			set => this.cargo = value;
		}

		public Tire[] Tires
		{
			get => this.tires;
			set => this.tires = value;
		}
	}
}
