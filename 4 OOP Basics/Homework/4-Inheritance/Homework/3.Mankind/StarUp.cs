using System;

namespace _3.Mankind
{
	public class StarUp
	{
		static void Main(string[] args)
		{
			string[] holdStudent = Console.ReadLine().Split();
			string[] holdWorckor = Console.ReadLine().Split();

			try
			{
				Student student = new Student(holdStudent[0], holdStudent[1], holdStudent[2]);
				Worker worker = new Worker(holdWorckor[0], holdWorckor[1], decimal.Parse(holdWorckor[2]), decimal.Parse(holdWorckor[3]));

				Console.WriteLine($"First Name: {student.FirsName}");
				Console.WriteLine($"Last Name: {student.LastName}");
				Console.WriteLine($"Faculty number: {student.FacultyNumber}");

				Console.WriteLine();

				Console.WriteLine($"First Name: {worker.FirsName}");
				Console.WriteLine($"Last Name: {worker.LastName}");
				Console.WriteLine($"Week Salary: {worker.WeekSalary:f2}");
				Console.WriteLine($"Hours per day: {worker.WorkHours:f2}");
				Console.WriteLine($"Salary per hour: {worker.MoneyEarnt():f2}");
			}
			catch (ArgumentException ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}
