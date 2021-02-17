using AnimalCentre.Animals;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Procedures
{
	public abstract class Procedure : IProcedure
	{
		Dictionary<string, List<IAnimal>> procedureHistory;

		public Procedure()
		{
			this.procedureHistory = new Dictionary<string, List<IAnimal>>();
		}

		protected Dictionary<string, List<IAnimal>> ProcedureHistory
		{
			get { return this.procedureHistory; }
			set { this.procedureHistory = value; }
		}
		//TODO neznam Dali raboti
		public string History()
		{
			string result = "";

			foreach (var item in procedureHistory)
			{
				string hold = "";

				foreach (var valu in item.Value)
				{
					hold = $"{item.Key} {valu.Name} {valu.Happiness} {valu.Energy} {valu.GetType().Name}:";

					result += $"{hold}";
				}
			}

			return result;
		}
		
		public abstract void DoService(IAnimal animal, int procedureTime);
	}
}
