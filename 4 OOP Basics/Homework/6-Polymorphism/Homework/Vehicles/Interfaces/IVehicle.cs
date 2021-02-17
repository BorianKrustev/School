using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Interfaces
{
	public interface IVehicle
	{
		double FuelQuantity { get; }
		double FuelConsumption { get; }

		void Drive(double km);
		void Refueled(double fuel);
	}
}
