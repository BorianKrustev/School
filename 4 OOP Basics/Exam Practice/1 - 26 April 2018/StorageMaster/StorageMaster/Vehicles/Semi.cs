using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Vehicles
{
	public class Semi : Vehicle
	{
		private static int SemiCapacity = 10;

		public Semi() 
			: base(SemiCapacity)
		{
		}
	}
}
