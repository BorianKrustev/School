using System;
using System.Linq;
using System.Collections.Generic;

namespace _7.SpeedRacing
{
	class Program
	{
		static void Main(string[] args)
		{
			List<Car> cars = new List<Car>();

			int n = int.Parse(Console.ReadLine());

			for (int i = 0; i < n; i++)
			{
				string[] input = Console.ReadLine().Split();

				string model = input[0];
				double fuelAmount = double.Parse(input[1]);
				double fuelConsumptionFor1km = double.Parse(input[2]);

				Car car = new Car(model, fuelAmount, fuelConsumptionFor1km);

				cars.Add(car);
			}

			while (true)
			{
				string input = Console.ReadLine();

				if (input == "End") break;

				string[] hold = input.Split();

				string carModel = hold[1];
				double amountOfKm = double.Parse(hold[2]);

				Car curentCar = cars.Where(x => x.Model == carModel).FirstOrDefault();

				curentCar.MoveCar(amountOfKm);
			}

			foreach (var item in cars)
			{
				Console.WriteLine($"{item.Model} {item.FuelAmount:f2} {item.TraveledDistance}");
			}
		}
	}
}
