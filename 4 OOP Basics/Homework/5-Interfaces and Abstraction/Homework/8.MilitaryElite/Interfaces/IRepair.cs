using System;
using System.Collections.Generic;
using System.Text;

namespace _8.MilitaryElite.Interfaces
{
	public interface IRepair
	{
		string PartName { get; }
		int HoursWorked { get; }
	}
}
