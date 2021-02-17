using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Interfaces;

namespace Vehicles.Clases
{
	public class Car : Vehicle, ICar
	{
		private const double carConsModifier = 0.9;

		public Car(double fuelQuantity, double fuelConsumption) 
			: base(fuelQuantity, fuelConsumption)
		{
			this.FuelConsumption += carConsModifier;
		}
	}
}
