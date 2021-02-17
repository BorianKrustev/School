using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Core
{
	public class Engine
	{
		private StorageMaster storageMaster;

		public Engine()
		{
			storageMaster = new StorageMaster();
		}

		public void Run()
		{
			string input = Console.ReadLine();

			while (input != "END")
			{
				try
				{
					string[] comands = input.Split();

					string call = comands[0];

					string output = "";
					if (call == "AddProduct")
					{
						string type = comands[1];
						double price = double.Parse(comands[2]);

						output = storageMaster.AddProduct(type, price);
					}
					else if (call == "RegisterStorage")
					{
						string type = comands[1];
						string name = comands[2];

						output = storageMaster.RegisterStorage(type, name);
					}
					else if (call == "SelectVehicle")
					{
						string storigName = comands[1];
						int garageSlot = int.Parse(comands[2]);

						output = storageMaster.SelectVehicle(storigName, garageSlot);
					}
					else if (call == "LoadVehicle")
					{
						string[] hold = comands.Skip(1).ToArray();

						output = storageMaster.LoadVehicle(hold);
					}
					else if (call == "SendVehicleTo")
					{
						string sourceName = comands[1];
						int sourceGarageSlot = int.Parse(comands[2]);
						string destinationName = comands[3];

						output = storageMaster.SendVehicleTo(sourceName, sourceGarageSlot, destinationName);
					}
					else if (call == "UnloadVehicle")
					{
						string storageName = comands[1];
						int garageSlot = int.Parse(comands[2]);

						output = storageMaster.UnloadVehicle(storageName, garageSlot);
					}
					else if (call == "GetStorageStatus")
					{
						string storageName = comands[1];

						output = storageMaster.GetStorageStatus(storageName);
					}

					Console.WriteLine(output);
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Error: {ex.Message}");
				}

				input = Console.ReadLine();
			}

			Console.WriteLine(storageMaster.GetSummary()); 
		}
	}
}
