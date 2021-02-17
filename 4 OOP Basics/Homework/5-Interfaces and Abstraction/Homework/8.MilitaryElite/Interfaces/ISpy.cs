using System;
using System.Collections.Generic;
using System.Text;

namespace _8.MilitaryElite.Interfaces
{
	interface ISpy : ISoldier
	{
		int CodeNumber { get; }
	}
}
