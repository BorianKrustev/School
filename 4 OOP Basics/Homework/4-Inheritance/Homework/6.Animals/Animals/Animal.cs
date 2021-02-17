using System;
using System.Collections.Generic;
using System.Text;

namespace _6.Animals.Animals
{
	public abstract class Animal
	{
		private string name;
		private int age;
		private string gender;

		public Animal(string name, int age, string gender)
		{
			this.Name = name;
			this.Age = age;
			this.Gender = gender;
		}

		public string Gender
		{
			get { return gender; }
			private set
			{
				if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException("Invalid input!");
				}
				gender = value;
			}
		}

		public int Age
		{
			get { return age; }
			private set
			{
				if (value < 1)
				{
					throw new ArgumentException("Invalid input!");
				}
				age = value;
			}
		}

		public string Name
		{
			get { return name; }
			private set
			{
				if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException("Invalid input!");
				}
				name = value;
			}
		}

		public virtual void ProduceSound()
		{
			Console.WriteLine("Screeem!");
		}

		public override string ToString()
		{
			return $"{this.Name} {this.Age} {this.Gender}";
		}
	}
}
