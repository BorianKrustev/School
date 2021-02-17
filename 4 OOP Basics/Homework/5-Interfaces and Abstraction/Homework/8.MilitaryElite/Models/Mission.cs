using _8.MilitaryElite.Enums;
using _8.MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _8.MilitaryElite.Models
{
	public class Mission : IMission
	{
		private string codeName;
		private State state;

		public Mission(string codeName, State state)
		{
			this.CodeName = codeName;
			this.State = state;
		}

		public string CodeName
		{
			get => this.codeName;
			private set => this.codeName = value;
		}

		public State State
		{
			get => this.state;
			private set => this.state = value;
		}

		public override string ToString()
		{
			return $"Code Name: {this.CodeName} State: {this.State}";
		}
	}
}
