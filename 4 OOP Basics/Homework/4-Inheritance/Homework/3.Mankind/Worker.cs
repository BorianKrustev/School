using System;
using System.Collections.Generic;
using System.Text;

namespace _3.Mankind
{
	public class Worker : Human
	{
		private decimal weekSalary;
		private decimal workHours;

		public Worker(string firsName, string lasName, decimal weekSalary, decimal workHours)
			: base(firsName, lasName)
		{
			this.WeekSalary = weekSalary;
			this.WorkHours = workHours;
		}

		public decimal WorkHours
		{
			get { return this.workHours; }
			set
			{
				if (value < 1 || value > 12)
				{
					throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
				}
				this.workHours = value;
			}
		}

		public decimal WeekSalary
		{
			get { return this.weekSalary; }
			set
			{
				if (value <= 10)
				{
					throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
				}
				this.weekSalary = value;
			}
		}

		public decimal MoneyEarnt()
		{
			return this.WeekSalary / (this.WorkHours * 5.0m);
		}
	}
}
