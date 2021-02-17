using _8.MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _8.MilitaryElite.Models
{
	public class LieutenantGeneral : Private, ILieutenantGeneral
	{
		public LieutenantGeneral(int id, string firstName, string lastName, decimal salary) 
			: base(id, firstName, lastName, salary)
		{
			this.Privets = new List<IPrivate>();
		}

		public List<IPrivate> Privets { get; set; }

		public override string ToString()
		{
			return base.ToString() + $"\nPrivates:{(this.Privets.Count == 0 ? "" : "\n  ")}{string.Join("\n  ", this.Privets)}";
		}
	}
}
