using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Vehicles
{
	public class Van : Vehicle
	{
		private static int VanCapacity = 2;

		public Van() 
			: base(VanCapacity)
		{
		}
	}
}
