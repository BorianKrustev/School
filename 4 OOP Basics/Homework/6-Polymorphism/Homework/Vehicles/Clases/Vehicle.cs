using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Interfaces;

namespace Vehicles.Clases
{
	public abstract class Vehicle : IVehicle
	{
		private double fuelQuantity;
		private double fuelConsumption;

		public Vehicle(double fuelQuantity, double fuelConsumption)
		{
			this.FuelQuantity = fuelQuantity;
			this.FuelConsumption = fuelConsumption;
		}

		public double FuelQuantity
		{
			get => this.fuelQuantity;
			set => this.fuelQuantity = value;
		}

		public double FuelConsumption
		{
			get => this.fuelConsumption;
			set => this.fuelConsumption = value;
		}

		public void Drive(double km)
		{
			double needeFuel = km * this.FuelConsumption;

			if (needeFuel > this.FuelQuantity)
			{
				Console.WriteLine($"{this.GetType().Name} needs refueling");
			}
			else
			{
				this.FuelQuantity -= needeFuel;

				Console.WriteLine($"{this.GetType().Name} travelled {km} km");
			}
		}

		public void Refueled(double fuel)
		{
			if (this is Truck)
			{
				fuel *= 0.95;
			}

			this.FuelQuantity += fuel;
		}
	}
}
