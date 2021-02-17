using StorageMaster.Products;
using StorageMaster.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Storages
{
	public abstract class Storage
	{
		private string name;
		private int capacity;
		private int garageSlots;
		private List<Product> products;
		private Vehicle[] garage;

		public Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicle)
		{
			this.Name = name;
			this.Capacity = capacity;
			this.GarageSlots = garageSlots;

			this.products = new List<Product>();
			this.garage = new Vehicle[this.GarageSlots];

			int index = 0;
			foreach (var item in vehicle)
			{
				this.garage[index] = item;
				index += 1;
			}
		}

		public int GarageSlots
		{
			get { return this.garageSlots; }
			private set { this.garageSlots = value; }
		}

		public int Capacity
		{
			get { return this.capacity; }
			private set { this.capacity = value; }
		}

		public string Name
		{
			get { return this.name; }
			private set { this.name = value; }
		}

		public IReadOnlyCollection<Product> Products => this.products.AsReadOnly();

		public bool IsFull => this.Products.Sum(x => x.Weight) >= this.Capacity;

		public IReadOnlyCollection<Vehicle> Garage => Array.AsReadOnly(garage);

		public Vehicle GetVehicle(int garageSlot)
		{
			if (garageSlot >= this.GarageSlots)
			{
				throw new InvalidOperationException("Invalid garage slot!");
			}

			Vehicle vehicle = this.garage[garageSlot];

			if (vehicle == null)
			{
				throw new InvalidOperationException("No vehicle in this garage slot!");
			}

			return vehicle;
		}

		public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
		{
			Vehicle vehicle = this.GetVehicle(garageSlot);

			int foundGaragSlotIndex = deliveryLocation.AddVehicleToGaradge(vehicle);
			this.garage[garageSlot] = null;

			return foundGaragSlotIndex;
		}

		public int UnloadVehicle(int garageSlot)
		{
			if (this.IsFull)
			{
				throw new InvalidOperationException("Storage is full!");
			}

			Vehicle vehicle = GetVehicle(garageSlot);

			int producktsUlodet = 0;
			while (!IsFull && !vehicle.IsEmpty)
			{
				Product product = vehicle.Unload();
				this.products.Add(product);

				producktsUlodet += 1;
			}

			return producktsUlodet;
		}

		private int AddVehicleToGaradge(Vehicle vehicle)
		{
			int indexOfFreeGarageSlot = Array.IndexOf(this.garage, null);

			if (indexOfFreeGarageSlot == -1)
			{
				throw new InvalidOperationException("No room in garage!");
			}

			this.garage[indexOfFreeGarageSlot] = vehicle;

			return indexOfFreeGarageSlot;
		}
	}
}
