using System;
using System.Collections.Generic;
using System.Text;

namespace _3.Mankind
{
	public class Human
	{
		private string firsName;
		private string lastName;

		public Human(string firsName, string lastName)
		{
			this.FirsName = firsName;
			this.LastName = lastName;
		}

		public string LastName
		{
			get { return this.lastName; }
			set
			{
				if (!char.IsUpper(value[0]))
				{
					throw new ArgumentException("Expected upper case letter! Argument: lastName");
				}
				else if (value.Length <= 2)
				{
					throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName ");
				}
				this.lastName = value;
			}
		}

		public string FirsName
		{
			get { return this.firsName; }
			set
			{
				if (!char.IsUpper(value[0]))
				{
					throw new ArgumentException("Expected upper case letter! Argument: firstName");
				}
				else if (value.Length <= 3)
				{
					throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
				}
				this.firsName = value;
			}
		}

	}
}
