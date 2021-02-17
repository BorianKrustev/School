using System;
using System.Collections.Generic;
using System.Text;

namespace _8.MilitaryElite.Interfaces
{
	public interface IEngineer : ISpecialisedSoldier
	{
		List<IRepair> Repairs { get; set; }
	}
}
