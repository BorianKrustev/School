﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _6.CompanyRoster
{
	public class Employee
	{
		private string name;
		private decimal salary;
		private string position;
		private string department;
		private string email;
		private int age;

		public Employee(string name, decimal salary, string position, string department)
		{
			this.Name = name;
			this.Salary = salary;
			this.Position = position;
			this.Department = department;
			this.email = "n/a";
			this.age = -1;
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public decimal Salary
		{
			get { return salary; }
			set { salary = value; }
		}

		public string Position
		{
			get { return position; }
			set { position = value; }
		}

		public string Department
		{
			get { return department; }
			set { department = value; }
		}

		public string Email
		{
			get { return email; }
			set { email = value; }
		}

		public int Age
		{
			get { return age; }
			set { age = value; }
		}
	}
}
