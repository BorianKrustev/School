using System;
using System.Linq;
using System.Collections.Generic;

namespace _8.RawData
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
				int engineSpeed = int.Parse(input[1]);
				int enginePower = int.Parse(input[2]);
				int cargoWeight = int.Parse(input[3]);
				string cargoType = input[4];

				double[] tire1 = new double[2];
				tire1[0] = double.Parse(input[5]);
				tire1[1] = double.Parse(input[6]);

				double[] tire2 = new double[2];
				tire2[0] = double.Parse(input[7]);
				tire2[1] = double.Parse(input[8]);

				double[] tire3 = new double[2];
				tire3[0] = double.Parse(input[9]);
				tire3[1] = double.Parse(input[10]);

				double[] tire4 = new double[2];
				tire4[0] = double.Parse(input[11]);
				tire4[1] = double.Parse(input[12]);

				Engine curentEngin = new Engine(engineSpeed, enginePower);
				Cargo curentCargo = new Cargo(cargoWeight, cargoType);
				Tire[] curentTires = new Tire[]
				{
					new Tire(tire1[0], tire1[1]),
					new Tire(tire2[0], tire2[1]),
					new Tire(tire3[0], tire3[1]),
					new Tire(tire4[0], tire4[1])
				};

				Car curentCar = new Car(model, curentEngin, curentCargo, curentTires);

				cars.Add(curentCar);
			}

			string comand = Console.ReadLine();

			if (comand == "fragile")
			{
				var print = cars.Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(s => s.Pressure < 1)).ToList();

				foreach (var item in print)
				{
					Console.WriteLine($"{item.Model}");
				}
			}
			else
			{
				var print = cars.Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250).ToList();

				foreach (var item in print)
				{
					Console.WriteLine($"{item.Model}");
				}
			}
		}
	}
}
