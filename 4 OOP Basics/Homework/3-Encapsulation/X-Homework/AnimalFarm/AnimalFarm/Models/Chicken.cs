﻿using System;

namespace AnimalFarm.Models
{
    public class Chicken
    {
        private const int MinAge = 0;
        private const int MaxAge = 15;

        private string name;
        private int age;

        internal Chicken(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            private get
            {
                return this.name;
            }

            set
            {
				if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
				{
					NameException();
				}
                this.name = value;
            }
        }

		public int Age
        {
            private get
            {
                return this.age;
            }

            set
            {
				if (value < MinAge || value > MaxAge)
				{
					AgeException();
				}
                this.age = value;
            }
        }

		private void AgeException()
		{
			throw new ArgumentException("Age should be between 0 and 15.");
		}

		private void NameException()
		{
			throw new ArgumentException("Name cannot be empty.");
		}

		private double ProductPerDay()
        {			
			return this.CalculateProductPerDay();
        }

        private double CalculateProductPerDay()
        {
            switch (this.Age)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    return 1.5;
                case 4:
                case 5:
                case 6:
                case 7:
                    return 2;
                case 8:
                case 9:
                case 10:
                case 11:
                    return 1;
                default:
                    return 0.75;
            }
        }

		public override string ToString()
		{
			return $"Chicken {this.Name} (age {this.Age}) can produce {this.ProductPerDay()} eggs per day.";
		}
	}
}