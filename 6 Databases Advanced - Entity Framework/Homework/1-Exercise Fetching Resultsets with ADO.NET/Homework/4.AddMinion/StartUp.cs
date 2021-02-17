using _1.InitialSetup;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace _4.AddMinion
{
	public class StartUp
	{
		public static void Main(string[] args)
		{
			using (SqlConnection connection = new SqlConnection(Configuration.ConactionString))
			{
				connection.Open();

				string[] minionInfo = Console.ReadLine().Split(new char[] { ' ', ':' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
				string[] villainInfo = Console.ReadLine().Split(" ").ToArray();

				string miName = minionInfo[1];
				int miGae = int.Parse(minionInfo[2]);
				string miTownName = minionInfo[3];

				string vName = villainInfo[1];

				int? id = GetTownByName(connection, miTownName);

				if (id is null)
				{
					AddTown(connection, miTownName);
				}

				id = GetTownByName(connection, miTownName);

				AddMinion(connection, miName, miGae, id);

				int? vilenId = GetVilenByName(connection, vName);

				if (vilenId is null)
				{
					AddVilen(connection, vName);
				}

				vilenId = GetVilenByName(connection, vName);

				int minionId = GetMinionByName(connection, miName);

				AddMinionVilen(connection, vilenId, minionId, miName, vName);
			}
		}

		private static void AddMinionVilen(SqlConnection connection, int? vilenId, int minionId, string miName, string vName)
		{
			string insertSQL = "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@villainId, @minionId)";

			using (SqlCommand command = new SqlCommand(insertSQL, connection))
			{
				command.Parameters.AddWithValue("@villainId", vilenId);
				command.Parameters.AddWithValue("@minionId", minionId);
				command.ExecuteNonQuery();
			}

			Console.WriteLine($"Successfully added {miName} to be minion of {vName}.");
		}

		private static int GetMinionByName(SqlConnection connection, string miName)
		{
			string minionSQL = "SELECT Id FROM Minions WHERE Name = @Name";

			using (SqlCommand command = new SqlCommand(minionSQL, connection))
			{
				command.Parameters.AddWithValue("@Name", miName);
				return (int)command.ExecuteScalar();
			}
		}

		private static void AddVilen(SqlConnection connection, string vName)
		{
			string inserQ = "INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";

			using (SqlCommand command = new SqlCommand(inserQ, connection))
			{
				command.Parameters.AddWithValue("@villainName", vName);
				command.ExecuteNonQuery();
			}

			Console.WriteLine($"Villain {vName} was added to the database.");
		}

		private static int? GetVilenByName(SqlConnection connection, string vName)
		{
			string villenIdQ = "SELECT Id FROM Villains WHERE Name = @Name";

			using (SqlCommand command = new SqlCommand(villenIdQ, connection))
			{
				command.Parameters.AddWithValue("@Name", vName);

				return (int?)command.ExecuteScalar();
			}
		}

		private static void AddMinion(SqlConnection connection, string miName, int miGae, int? id)
		{
			string insertMinionQ = "INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";

			using (SqlCommand command = new SqlCommand(insertMinionQ, connection))
			{
				command.Parameters.AddWithValue("@name", miName);
				command.Parameters.AddWithValue("@age", miGae);
				command.Parameters.AddWithValue("@townId", id);

				command.ExecuteNonQuery();
			}
		}

		private static int? GetTownByName(SqlConnection connection, string miTownName)
		{
			string townIdQ = "SELECT Id FROM Towns WHERE Name = @townName";

			using (SqlCommand command = new SqlCommand(townIdQ, connection))
			{
				command.Parameters.AddWithValue("@townName", miTownName);

				return (int?)command.ExecuteScalar();
			}
		}

		private static void AddTown(SqlConnection connection, string miTownName)
		{
			string insertTown = "INSERT INTO Towns (Name) VALUES (@townName)";

			using (SqlCommand command = new SqlCommand(insertTown, connection))
			{
				command.Parameters.AddWithValue("@townName", miTownName);
				command.ExecuteNonQuery();
			}

			Console.WriteLine($"Town {miTownName} was added to the database.");
		}
	}
}
