using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Interfaces;

namespace Vehicles.Clases
{
	public class Truck : Vehicle, ITruck
	{
		private const double truckConsModifier = 1.6;

		public Truck(double fuelQuantity, double fuelConsumption) 
			: base(fuelQuantity, fuelConsumption)
		{
			this.FuelConsumption += truckConsModifier;
		}
	}
}
