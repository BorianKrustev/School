using System;
using System.Collections.Generic;
using System.Text;

namespace _8.MilitaryElite.Interfaces
{
	public interface IPrivate : ISoldier
	{
		decimal Salary { get; }
	}
}
