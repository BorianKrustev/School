using _8.MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _8.MilitaryElite.Models
{
	public class Spy : Soldier, ISpy
	{
		private int codeNumber;

		public Spy(int id, string firstName, string lastName, int codeNumber) 
			: base(id, firstName, lastName)
		{
			this.CodeNumber = codeNumber;
		}

		public int CodeNumber
		{
			get => this.codeNumber;
			private set => this.codeNumber = value;
		}

		public override string ToString()
		{
			return base.ToString() + $"\nCode Number: {this.CodeNumber}";
		}
	}
}
