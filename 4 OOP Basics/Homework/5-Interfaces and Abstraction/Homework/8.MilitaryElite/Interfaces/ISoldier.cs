using System;
using System.Collections.Generic;
using System.Text;

namespace _8.MilitaryElite.Interfaces
{
	public interface ISoldier
	{
		int Id { get; }
		string FirstName { get; }
		string LastName { get; }
	}
}
