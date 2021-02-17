using _1.InitialSetup;
using System;
using System.Data.SqlClient;

namespace _3.MinionNames
{
	public class StartUp
	{
		public static void Main(string[] args)
		{
			using (SqlConnection connection = new SqlConnection(Configuration.ConactionString))
			{
				connection.Open();

				int Id = int.Parse(Console.ReadLine());

				string sqlQueryOne = @"SELECT Name FROM Villains WHERE Id = @id";

				string sqlQueryTwo = @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
											  m.Name, 
											  m.Age
											FROM MinionsVillains AS mv
											JOIN Minions As m ON mv.MinionId = m.Id
											WHERE mv.VillainId = @id
										ORDER BY m.Name";

				using (SqlCommand command = new SqlCommand(sqlQueryOne, connection))
				{
					command.Parameters.AddWithValue("@id", Id);

					string villName = (string)command.ExecuteScalar();

					if (villName is null)
					{
						Console.WriteLine($"No villain with ID {Id} exists in the database");
					}
					else
					{
						Console.WriteLine($"Villain: {villName}");
					}
				}

				using (SqlCommand command = new SqlCommand(sqlQueryTwo, connection))
				{
					command.Parameters.AddWithValue("@id", Id);

					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							long rowNum = (long)reader[0];
							string name = (string)reader[1];
							int age = (int)reader[2];

							Console.WriteLine($"{rowNum}. {name} {age}");
						}

						if (!reader.HasRows)
						{
							Console.WriteLine("(no minions)");
						}
					}
				}
			}
		}
	}
}
