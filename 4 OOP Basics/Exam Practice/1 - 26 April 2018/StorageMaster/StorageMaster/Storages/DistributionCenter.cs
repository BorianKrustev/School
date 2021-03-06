﻿using System;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Vehicles;

namespace StorageMaster.Storages
{
	public class DistributionCenter : Storage
	{
		private const int DistributionCenterCapacity = 2;
		private const int DistributionCenterSlots = 5;
		private static Vehicle[] DefaultVehicle = new Vehicle[]
		{
			new Van(),
			new Van(),
			new Van()
		};

		public DistributionCenter(string name) 
			: base(name, DistributionCenterCapacity, DistributionCenterSlots, DefaultVehicle)
		{
		}
	}
}
