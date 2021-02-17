using _1.InitialSetup;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace _7.PrintAllMinionNames
{
	public class StartUp
	{
		public static void Main(string[] args)
		{
			using (SqlConnection connection = new SqlConnection(Configuration.ConactionString))
			{
				connection.Open();

				string nameSQL = "SELECT Name FROM Minions";
				List<string> nams = new List<string>();

				using (SqlCommand command = new SqlCommand(nameSQL, connection))
				{
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							nams.Add((string)reader[0]);
						}
					}
				}

				int lastCount = nams.Count - 1;
				for (int i = 0; i < nams.Count / 2; i++)
				{
					Console.WriteLine($"{nams[i]}");
					Console.WriteLine($"{nams[lastCount]}");

					lastCount -= 1;
				}
			}
		}
	}
}
