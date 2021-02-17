using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Clases;
using Vehicles.Interfaces;

namespace Vehicles.Core
{
	public class Engine
	{
		public void Run()
		{
			string[] carInfo = Console.ReadLine().Split();
			string[] truckInfo = Console.ReadLine().Split();

			double carFuel = double.Parse(carInfo[1]);
			double carConsumption = double.Parse(carInfo[2]);

			ICar car = new Car(carFuel, carConsumption);

			double truckFuel = double.Parse(truckInfo[1]);
			double truckConsumption = double.Parse(truckInfo[2]);

			ITruck truck = new Truck(truckFuel, truckConsumption);

			int n = int.Parse(Console.ReadLine());
			for (int i = 0; i < n; i++)
			{
				string[] input = Console.ReadLine().Split();

				if (input[0] == "Drive")
				{
					if (input[1] == "Car")
					{
						car.Drive(double.Parse(input[2]));
					}
					else
					{
						truck.Drive(double.Parse(input[2]));
					}
				}
				else
				{
					if (input[1] == "Car")
					{
						car.Refueled(double.Parse(input[2]));
					}
					else
					{
						truck.Refueled(double.Parse(input[2]));
					}
				}
			}

			Console.WriteLine($"Car: {car.FuelQuantity:f2}");
			Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
		}
	}
}
