using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Procedures
{
	public class Chip : Procedure
	{
		public override void DoService(IAnimal animal, int procedureTime)
		{
			if (animal.IsChipped)
			{
				throw new ArgumentException($"{animal.Name} is already chipped");
			}

			if (procedureTime >= animal.ProcedureTime)
			{
				throw new ArgumentException("Animal doesn't have enough procedure time");
			}
			
			animal.ProcedureTime -= procedureTime;

			animal.Happiness -= 5;

			animal.IsChipped = true;

			if (!this.ProcedureHistory.ContainsKey(this.GetType().Name))
			{
				this.ProcedureHistory.Add(this.GetType().Name, new List<IAnimal>());
			}

			this.ProcedureHistory[this.GetType().Name].Add(animal);
		}
	}
}
