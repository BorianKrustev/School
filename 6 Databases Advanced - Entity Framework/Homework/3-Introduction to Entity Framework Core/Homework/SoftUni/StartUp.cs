using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
	public class StartUp
	{
		public static void Main(string[] args)
		{
			using (SoftUniContext context = new SoftUniContext())
			{
				var result = RemoveTown(context);

				Console.WriteLine(result);
			}
		}

		public static string GetEmployeesFullInformation(SoftUniContext context)
		{
			var employees = context.Employees
				.Select(x => new {
									x.FirstName,
									x.LastName,
									x.MiddleName,
									x.JobTitle,
									x.Salary,
									x.EmployeeId
								 })
				.OrderBy(x => x.EmployeeId)
				.ToList();

			StringBuilder sb = new StringBuilder();
			foreach (var em in employees)
			{
				sb.AppendLine($"{em.FirstName} {em.LastName} {em.MiddleName} {em.JobTitle} {em.Salary:F2}");
			}

			return sb.ToString().TrimEnd();
		}

		public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
		{
			var employees = context.Employees
				.Where(s => s.Salary > 50000)
				.Select(x => new { x.FirstName, x.Salary})
				.OrderBy(f => f.FirstName)
				.ToList();

			StringBuilder sb = new StringBuilder();
			foreach (var em in employees)
			{
				sb.AppendLine($"{em.FirstName} - {em.Salary:F2}");
			}

			return sb.ToString().TrimEnd();
		}

		public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
		{
			var employees = context.Employees
				.Where(x => x.Department.Name == "Research and Development")
				.Select(x => new
				{
					x.FirstName,
					x.LastName,
					DepartmentName = x.Department.Name,
					x.Salary
				})
				.OrderBy(x => x.Salary)
				.ThenByDescending(x => x.FirstName)
				.ToList();

			StringBuilder sb = new StringBuilder();
			foreach (var em in employees)
			{
				sb.AppendLine($"{em.FirstName} {em.LastName} from {em.DepartmentName} - ${em.Salary:F2}");
			}

			return sb.ToString().TrimEnd();
		}

		public static string AddNewAddressToEmployee(SoftUniContext context)
		{
			var address = new Address
			{
				AddressText = "Vitoshka 15",
				TownId = 4
			};

			//context.Addresses.Add(address);

			var nakov = context.Employees.FirstOrDefault(x => x.LastName == "Nakov");
			nakov.Address = address;

			context.SaveChanges();

			var employeesAddress = context.Employees
				.OrderByDescending(x => x.AddressId)
				.Select(x => x.Address.AddressText)
				.Take(10)
				.ToList();

			StringBuilder sb = new StringBuilder();
			foreach (var ea in employeesAddress)
			{
				sb.AppendLine($"{ea}");
			}

			return sb.ToString().TrimEnd();
		}

		public static string GetEmployeesInPeriod(SoftUniContext context)
		{
			var employees = context.Employees
				.Where(x => x.EmployeesProjects.Any(s => s.Project.StartDate.Year >= 2001 && s.Project.StartDate.Year <= 2003))
				.Select(x => new
				{
					EmpFullName = x.FirstName + " " + x.LastName,
					MangFullName = x.Manager.FirstName + " " + x.Manager.LastName,
					Projects = x.EmployeesProjects.Select(p => new
					{
						ProName = p.Project.Name,
						ProStartDate = p.Project.StartDate,
						ProEndDate = p.Project.EndDate
					}).ToList()
				})
				.Take(10)
				.ToList();

			StringBuilder sb = new StringBuilder();
			foreach (var em in employees)
			{
				sb.AppendLine($"{em.EmpFullName} - Manager: {em.MangFullName}");

				foreach (var pro in em.Projects)
				{
					var startDate = pro.ProStartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
					var endDate = pro.ProEndDate.HasValue ? pro.ProEndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) : "not finished";

					sb.AppendLine($"--{pro.ProName} - {startDate} - {endDate}");
				}
			}

			return sb.ToString().TrimEnd();
		}

		public static string GetAddressesByTown(SoftUniContext context)
		{
			return (string.Join(Environment.NewLine, context.Addresses
					.OrderByDescending(a => a.Employees.Count)
					.ThenBy(a => a.Town.Name)
					.ThenBy(a => a.AddressText)
					.Take(10)
					.Select(a => $"{a.AddressText}, {a.Town.Name} - {a.Employees.Count} employees")));
		}

		public static string GetEmployee147(SoftUniContext context)
		{
			var Employee147 = context.Employees
				.Where(x => x.EmployeeId == 147)
				.Select(x => new
				{
					FirsName = x.FirstName,
					LastName = x.LastName,
					JobTitle = x.JobTitle,
					Projects = x.EmployeesProjects.Select(p => p.Project.Name).OrderBy(pn => pn).ToArray()
				})
				.FirstOrDefault();

			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"{Employee147.FirsName} {Employee147.LastName} - {Employee147.JobTitle}");

			foreach (var em in Employee147.Projects)
			{
				sb.AppendLine($"{em}");
			}

			return sb.ToString().TrimEnd();
		}

		public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
		{
			var depart = context.Departments
				.Where(x => x.Employees.Count > 5)
				.OrderBy(x => x.Employees.Count)
				.ThenBy(x => x.Name)
				.Select(x => new
				{
					DeopName = x.Name,
					MangFirsName = x.Manager.FirstName,
					MangLastName = x.Manager.LastName,
					Employees = x.Employees
					.Select(e => new
					{
						EmFirsName = e.FirstName,
						EmLastName = e.LastName,
						EmJobTitle = e.JobTitle
					})
					.OrderBy(f => f.EmFirsName)
					.ThenBy(f => f.EmLastName)
					.ToList()
				})
				.ToList();

			StringBuilder sb = new StringBuilder();
			foreach (var dep in depart)
			{
				sb.AppendLine($"{dep.DeopName} - {dep.MangFirsName} {dep.MangLastName}");

				foreach (var emp in dep.Employees)
				{
					sb.AppendLine($"{emp.EmFirsName} {emp.EmLastName} - {emp.EmJobTitle}");
				}
			}

			return sb.ToString().TrimEnd();
		}

		public static string GetLatestProjects(SoftUniContext context)
		{
			var projects = context.Projects
				.Select(x => new
				{
					x.Name,
					x.Description,
					x.StartDate
				})
				.OrderByDescending(x => x.StartDate)
				.Take(10)
				.ToList();

			projects = projects.OrderBy(x => x.Name).ToList();

			StringBuilder sb = new StringBuilder();
			foreach (var pro in projects)
			{
				sb.AppendLine($"{pro.Name}");
				sb.AppendLine($"{pro.Description}");
				sb.AppendLine($"{pro.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)}");
			}

			return sb.ToString().TrimEnd();

		}

		public static string IncreaseSalaries(SoftUniContext context)
		{
			context.Employees
				.Where(x => x.Department.Name == "Engineering" || x.Department.Name == "Tool Design" || x.Department.Name == "Marketing" || x.Department.Name == "Information Services")
				.ToList()
				.ForEach(x => x.Salary += x.Salary * 12 / 100);

			context.SaveChanges();

			var employees = context.Employees
				.Where(x => x.Department.Name == "Engineering" || x.Department.Name == "Tool Design" || x.Department.Name == "Marketing" || x.Department.Name == "Information Services")
				.Select(x => new
				{
					x.FirstName,
					x.LastName,
					x.Salary
				})
				.OrderBy(x => x.FirstName)
				.ThenBy(x => x.LastName)
				.ToList();

			StringBuilder sb = new StringBuilder();
			foreach (var e in employees)
			{
				sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:F2})");
			}

			return sb.ToString().TrimEnd();
		}

		public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
		{
			var employees = context.Employees
				.Where(x => EF.Functions.Like(x.FirstName, "Sa%")) // .Where(x => x.FirstName.StartsWith("Sa")) - Sa6to stava no pra6ta razli4na po lo6a zaiavka do bazata
				.Select(x => new
				{
					x.FirstName,
					x.LastName,
					x.JobTitle,
					x.Salary
				})
				.OrderBy(x => x.FirstName)
				.ThenBy(x => x.LastName)
				.ToList();

			StringBuilder sb = new StringBuilder();
			foreach (var e in employees)
			{
				sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:F2})");
			}

			return sb.ToString().TrimEnd();
		}

		public static string DeleteProjectById(SoftUniContext context)
		{
			var project = context.Projects.FirstOrDefault(x => x.ProjectId == 2);

			var employeesProjects = context.EmployeesProjects.Where(x => x.ProjectId == 2);
			context.EmployeesProjects.RemoveRange(employeesProjects);

			context.Projects.Remove(project);

			context.SaveChanges();

			var projects = context.Projects
				.Select(x => x.Name)
				.Take(10)
				.ToList();

			StringBuilder sb = new StringBuilder();
			foreach (var p in projects)
			{
				sb.AppendLine($"{p}");
			}

			return sb.ToString().TrimEnd();
		}

		public static string RemoveTown(SoftUniContext context)
		{
			context.Employees
				.Where(x => x.Address.Town.Name == "Seattle")
				.ToList()
				.ForEach(x => x.AddressId = null);

			int count = context.Addresses
				.Where(x => x.Town.Name == "Seattle")
				.Count();

			context.Addresses
				.Where(x => x.Town.Name == "Seattle")
				.ToList()
				.ForEach(x => context.Addresses.Remove(x));

			context.Towns
				.Remove(context.Towns.SingleOrDefault(x => x.Name == "Seattle"));

			context.SaveChanges();

			return $"{count} addresses in Seattle were deleted";
		}
	}
}
