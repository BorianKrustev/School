using System;
using System.Collections.Generic;
using System.Text;

namespace _7.SpeedRacing
{
	public class Car
	{
		private string model;
		private double fuelAmount;
		private double fuelConsumption;
		private double traveledDistance;

		public Car(string model, double fuelAmount, double fuelConsumption)
		{
			this.Model = model;
			this.FuelAmount = fuelAmount;
			this.FuelConsumption = fuelConsumption;
			this.TraveledDistance = 0.0;
		}

		public string Model
		{
			get => this.model;
			set => this.model = value;
		}
		public double FuelAmount
		{
			get => this.fuelAmount;
			set => this.fuelAmount = value;
		}
		public double FuelConsumption
		{
			get => this.fuelConsumption;
			set => this.fuelConsumption = value;
		}
		public double TraveledDistance
		{
			get => this.traveledDistance;
			set => this.traveledDistance = value;
		}

		public void MoveCar(double amountOfKm)
		{
			if (amountOfKm * this.fuelConsumption > this.fuelAmount)
			{
				Console.WriteLine("Insufficient fuel for the drive");
				return;
			}

			this.traveledDistance += amountOfKm;
			this.fuelAmount -= amountOfKm * this.fuelConsumption;
		}
	}
}
