using System;
using System.Collections.Generic;
using System.Text;

namespace _1.Person
{
	public class Person
	{
		private string name;
		private int age;

		public Person(string name, int age)
		{
			this.Name = name;
			this.Age = age;
		}

		public virtual int Age
		{
			get { return age; }
			set
			{
				if (value < 0)
				{
					throw new ArgumentException("Age mus be positive!");
				}
				this.age = value;
			}
		}

		protected string Name
		{
			get { return name; }
			private set
			{
				if (value.Length < 3)
				{
					throw new ArgumentException("Name's length should not be less than 3 symbols!");
				}
				name = value;
			}
		}

		public override string ToString()
		{
			StringBuilder stringBilder = new StringBuilder();
			stringBilder.Append(String.Format("Name: {0}, Age: {1}", 
								this.Name, 
								this.Age));

			return stringBilder.ToString();
		}
	}
}
