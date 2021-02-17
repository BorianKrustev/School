using _1.InitialSetup;
using System;
using System.Data.SqlClient;

namespace _6.RemoveVillain
{
	public class StartUp
	{
		public static void Main(string[] args)
		{
			using (SqlConnection connection = new SqlConnection(Configuration.ConactionString))
			{
				connection.Open();

				string vilenName = null;
				int targetId = int.Parse(Console.ReadLine());
				string vilenNameSQL = "SELECT Name FROM Villains WHERE Id = @villainId";

				using (SqlCommand command = new SqlCommand(vilenNameSQL, connection))
				{
					command.Parameters.AddWithValue("@villainId", targetId);

					vilenName = (string)command.ExecuteScalar();

					if (vilenName is null)
					{
						Console.WriteLine($"No such villain was found.");
						return;
					}
				}

				int affRows = DeliteMinionsVillainsById(connection, targetId);

				DeliteVillenById(connection, targetId);

				Console.WriteLine($"{vilenName} was deleted.");
				Console.WriteLine($"{affRows} minions were released.");
			}
		}

		private static void DeliteVillenById(SqlConnection connection, int targetId)
		{
			string deliteVilenSQL = @"DELETE FROM Villains
												WHERE Id = @villainId";

			using (SqlCommand command = new SqlCommand(deliteVilenSQL, connection))
			{
				command.Parameters.AddWithValue("@villainId", targetId);

				command.ExecuteNonQuery();
			}
		}

		private static int DeliteMinionsVillainsById(SqlConnection connection, int targetId)
		{
			string deliteVilenSQL = @"DELETE FROM MinionsVillains 
												WHERE VillainId = @villainId";

			using (SqlCommand command = new SqlCommand(deliteVilenSQL, connection))
			{
				command.Parameters.AddWithValue("@villainId", targetId);

				return command.ExecuteNonQuery();
			}
		}
	}
}
