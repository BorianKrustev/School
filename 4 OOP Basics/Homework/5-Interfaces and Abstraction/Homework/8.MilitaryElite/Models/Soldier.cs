﻿using _8.MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _8.MilitaryElite.Models
{
	public abstract class Soldier : ISoldier
	{
		private int id;
		private string firstName;
		private string lastName;

		public Soldier(int id, string firstName, string lastName)
		{
			this.Id = id;
			this.FirstName = firstName;
			this.LastName = lastName;
		}

		public int Id
		{
			get => this.id;
			private set => this.id = value;
		}

		public string FirstName
		{
			get => this.firstName;
			private set => this.firstName = value;
		}

		public string LastName
		{
			get => this.lastName;
			private set => this.lastName = value;
		}

		public override string ToString()
		{
			return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} ";
		}
	}
}
