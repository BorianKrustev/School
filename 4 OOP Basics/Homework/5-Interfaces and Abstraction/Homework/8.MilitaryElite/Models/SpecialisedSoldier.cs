using _8.MilitaryElite.Enums;
using _8.MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _8.MilitaryElite.Models
{
	public class SpecialisedSoldier : Private, ISpecialisedSoldier
	{
		private Corps corps;

		public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, Corps corps) 
			: base(id, firstName, lastName, salary)
		{
			this.Corps = corps;
		}

		public Corps Corps
		{
			get => this.corps;
			private set => this.corps = value;
		}
	}
}
