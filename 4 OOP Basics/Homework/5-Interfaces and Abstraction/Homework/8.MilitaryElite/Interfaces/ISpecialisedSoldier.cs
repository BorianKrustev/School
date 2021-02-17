using _8.MilitaryElite.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace _8.MilitaryElite.Interfaces
{
	public interface ISpecialisedSoldier : IPrivate
	{
		Corps Corps { get; }
	}
}
