using _1.InitialSetup;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace _8.IncreaseMinionAge
{
	public class StartUP
	{
		public static void Main(string[] args)
		{
			using (SqlConnection connection = new SqlConnection(Configuration.ConactionString))
			{
				connection.Open();

				int[] ids = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

				string updatMinions = @" UPDATE Minions
												  SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
												WHERE Id = @Id";

				foreach (var id in ids)
				{
					using (SqlCommand command = new SqlCommand(updatMinions, connection))
					{
						command.Parameters.AddWithValue("@Id", id);
						command.ExecuteNonQuery();
					}
				}

				string sql = @"SELECT Name, Age FROM Minions";

				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							Console.WriteLine($"{reader[0]} {reader[1]}");
						}
					}
				}
			}
		}
	}
}
