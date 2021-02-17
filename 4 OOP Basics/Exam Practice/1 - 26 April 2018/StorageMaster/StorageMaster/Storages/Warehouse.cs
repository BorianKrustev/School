using System;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Vehicles;

namespace StorageMaster.Storages
{
	public class Warehouse : Storage
	{
		private const int WarehouseCapacity = 10;
		private const int WarehouseGarageSlots = 10;
		private static Vehicle[] WarehouseDefaultVehicle = new Vehicle[]
		{
			new Semi(),
			new Semi(),
			new Semi()
		};

		public Warehouse(string name) 
			: base(name, WarehouseCapacity, WarehouseGarageSlots, WarehouseDefaultVehicle)
		{
		}
	}
}
