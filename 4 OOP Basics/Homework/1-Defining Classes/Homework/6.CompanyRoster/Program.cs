using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.CompanyRoster
{
	class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());

			List<Employee> employes = new List<Employee>();

			for (int i = 0; i < n; i++)
			{
				string[] input = Console.ReadLine().Split();

				string name = input[0];
				decimal salary = decimal.Parse(input[1]);
				string position = input[2];
				string department = input[3];

				Employee newEmp = new Employee(name, salary, position, department);

				if (input.Length == 5)
				{
					if (input[4].Contains('@'))
					{
						newEmp.Email = input[4];
					}
					else
					{
						newEmp.Age = int.Parse(input[4]);
					}
				}
				else if (input.Length == 6)
				{
					newEmp.Email = input[4];
					newEmp.Age = int.Parse(input[5]);
				}

				employes.Add(newEmp);
			}

			var topDepartmant = employes.GroupBy(x => x.Department)
										.ToDictionary(x => x.Key, y => y.Select(s => s))
										.OrderByDescending(x => x.Value.Average(s => s.Salary))
										.FirstOrDefault();

			Console.WriteLine($"Highest Average Salary: {topDepartmant.Key}");

			foreach (Employee item in topDepartmant.Value.OrderByDescending(x => x.Salary))
			{
				Console.WriteLine($"{item.Name} {item.Salary:F2} {item.Email} {item.Age}");
			}
		}
	}
}
