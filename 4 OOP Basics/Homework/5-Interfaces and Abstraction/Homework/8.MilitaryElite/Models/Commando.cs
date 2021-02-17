using System;
using System.Collections.Generic;
using System.Text;
using _8.MilitaryElite.Enums;
using _8.MilitaryElite.Interfaces;

namespace _8.MilitaryElite.Models
{
	public class Commando : SpecialisedSoldier, ICommando
	{
		public Commando(int id, string firstName, string lastName, decimal salary, Corps corps) 
			: base(id, firstName, lastName, salary, corps)
		{
			this.Missions = new List<IMission>();
		}

		public List<IMission> Missions { get; set; }

		public override string ToString()
		{
			return base.ToString() + $"\nCorps: {this.Corps}\nMissions:{(this.Missions.Count == 0 ? "" : "\n  ")}{string.Join("\n  ", this.Missions)}";
		}
	}
}
