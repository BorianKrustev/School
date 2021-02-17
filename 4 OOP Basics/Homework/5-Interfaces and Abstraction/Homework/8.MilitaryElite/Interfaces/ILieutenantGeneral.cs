using System;
using System.Collections.Generic;
using System.Text;

namespace _8.MilitaryElite.Interfaces
{
	public interface ILieutenantGeneral : IPrivate
	{
		List<IPrivate> Privets { get; set; }
	}
}
