using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Vehicles
{
	public class Truck : Vehicle
	{
		private static int TruckCapacity = 5;

		public Truck() 
			: base(TruckCapacity)
		{
		}
	}
}
