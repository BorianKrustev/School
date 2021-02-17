using _8.MilitaryElite.Enums;
using _8.MilitaryElite.Interfaces;
using _8.MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _8.MilitaryElite.Core
{
	public class Engine
	{
		private List<ISoldier> soldiers;
		private ISoldier soldier;

		public Engine()
		{
			soldiers = new List<ISoldier>();
		}

		public void Run()
		{
			string input = Console.ReadLine();

			while (input != "End")
			{
				string[] comands = input.Split();

				string type = comands[0];
				int id = int.Parse(comands[1]);
				string firstName = comands[2];
				string lastName = comands[3];

				if (type == "Private")
				{
					decimal salary = decimal.Parse(comands[4]);

					soldier = new Private(id, firstName, lastName, salary);
				}
				else if (type == "LieutenantGeneral")
				{
					decimal salary = decimal.Parse(comands[4]);

					soldier = GetLieutenantGeneral(id, firstName, lastName, salary, comands);
				}
				else if (type == "Engineer")
				{
					decimal salary = decimal.Parse(comands[4]);

					if (!Enum.TryParse(comands[5], out Corps corps))
					{
						continue;
					}

					soldier = GetEngineer(id, firstName, lastName, salary, corps, comands);
				}
				else if (type == "Commando")
				{
					decimal salary = decimal.Parse(comands[4]);

					if (!Enum.TryParse(comands[5], out Corps corps))
					{
						continue;
					}

					soldier = GetCommando(id, firstName, lastName, salary, corps, comands);
				}
				else if (type == "Spy")
				{
					int codeNumber = int.Parse(comands[4]);

					soldier = new Spy(id, firstName, lastName, codeNumber);
				}

				if (soldier != null)
				{
					this.soldiers.Add(soldier);
				}

				input = Console.ReadLine();
			}

			foreach (var item in soldiers)
			{
				Console.WriteLine(item);
			}
		}

		private ISoldier GetCommando(int id, string firstName, string lastName, decimal salary, Corps corps, string[] comands)
		{
			ICommando solder = new Commando(id, firstName, lastName, salary, corps);

			for (int i = 6; i < comands.Length; i+=2)
			{
				string codeName = comands[i];
				if (!Enum.TryParse(comands[i + 1], out State stat))
				{
					continue;
				}

				IMission mision = new Mission(codeName, stat);

				solder.Missions.Add(mision);
			}

			return solder;
		}

		private ISoldier GetEngineer(int id, string firstName, string lastName, decimal salary, Corps corps, string[] comands)
		{
			IEngineer solder = new Engineer(id, firstName, lastName, salary, corps);

			for (int i = 6; i < comands.Length; i+=2)
			{
				string part = comands[i];
				int hours = int.Parse(comands[i + 1]);

				IRepair repair = new Repair(part, hours);
				solder.Repairs.Add(repair);
			}

			return solder;
		}

		private ISoldier GetLieutenantGeneral(int id, string firstName, string lastName, decimal salary, string[] comands)
		{
			ILieutenantGeneral LGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

			for (int i = 5; i < comands.Length; i++)
			{
				int privetId = int.Parse(comands[i]);

				IPrivate curentPrivet = (IPrivate)soldiers.FirstOrDefault(x => x.Id == privetId);

				LGeneral.Privets.Add(curentPrivet);
			}

			return LGeneral;
		}
	}
}
