using _1.InitialSetup;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace _5.ChangeTownNamesCasing
{
	public class Program
	{
		public static void Main(string[] args)
		{
			string nameOfCuntry = Console.ReadLine();
			List<string> cetyNames = new List<string>();
			int rowsAfected = 0;

			using (SqlConnection connection = new SqlConnection(Configuration.ConactionString))
			{
				connection.Open();

				string updateTownSQL = @"UPDATE Towns
								   SET Name = UPPER(Name)
								 WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";

				using (SqlCommand command = new SqlCommand(updateTownSQL, connection))
				{
					command.Parameters.AddWithValue("@countryName", nameOfCuntry);

					rowsAfected = command.ExecuteNonQuery();
				}

				if (rowsAfected <= 0)
				{
					Console.WriteLine("No town names were affected.");
					return;
				}

				string selectTownNamesSQL = @" SELECT t.Name 
											  FROM Towns as t
											  JOIN Countries AS c ON c.Id = t.CountryCode
											 WHERE c.Name = @countryName";

				using (SqlCommand command = new SqlCommand(selectTownNamesSQL, connection))
				{
					command.Parameters.AddWithValue("@countryName", nameOfCuntry);

					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							cetyNames.Add((string)reader[0]);
						}
					}
				}

				Console.WriteLine($"{rowsAfected} town names were affected.");
				Console.WriteLine($"[{string.Join(", ", cetyNames)}]");
			}
		}
	}
}
