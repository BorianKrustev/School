using System;
using System.Collections.Generic;
using System.Text;

namespace _3.Mankind
{
	public class Student : Human
	{
		private string facultyNumber;

		public Student(string firsName, string lastName, string facultyNumber)
			: base(firsName, lastName)
		{
			this.FacultyNumber = facultyNumber;
		}

		public string FacultyNumber
		{
			get { return this.facultyNumber; }
			set
			{
				if (value.Length < 5 || value.Length > 10)
				{
					throw new ArgumentException("Invalid faculty number!");
				}
				this.facultyNumber = value;
			}
		}
	}
}
