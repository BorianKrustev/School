using _8.MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _8.MilitaryElite.Models
{
	public class Private : Soldier, IPrivate
	{
		private decimal salary;

		public Private(int id, string firstName, string lastName, decimal salary)
			: base(id, firstName, lastName)
		{
			this.Salary = salary;
		}

		public decimal Salary
		{
			get => this.salary;
			private set => this.salary = value;
		}

		public override string ToString()
		{
			return base.ToString() + $"Salary: {this.Salary:f2}";
		}
	}
}
