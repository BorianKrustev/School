using System;
using System.Collections.Generic;
using System.Text;

namespace _8.RawData
{
	public class Tire
	{
		private double pressure;
		private double age;

		public Tire(double pressure, double age)
		{
			this.pressure = pressure;
			this.age = age;
		}

		public double Age
		{
			get => this.age;
			set => this.age = value;
		}

		public double Pressure
		{
			get => this.pressure;
			set => this.pressure = value;
		}
	}
}
