using System;
using System.Linq;
using System.Collections.Generic;

namespace _6.CompanyRoster
{
	public class StartUp
	{
		public static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());

			List<Employee> employes = new List<Employee>();

			for (int i = 0; i < n; i++)
			{
				string[] input = Console.ReadLine().Split();

				string name = input[0];
				decimal salary = decimal.Parse(input[1]);
				string position = input[2];
				string departmant = input[3];

				Employee employee = new Employee(name, salary, position, departmant);

				if (input.Length == 5)
				{
					if (input[4].Contains('@'))
					{
						employee.Email = input[4];
					}
					else
					{
						employee.Age = int.Parse(input[4]);
					}
				}
				else if (input.Length == 6)
				{
					employee.Email = input[4];
					employee.Age = int.Parse(input[5]);
				}

				employes.Add(employee);
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
