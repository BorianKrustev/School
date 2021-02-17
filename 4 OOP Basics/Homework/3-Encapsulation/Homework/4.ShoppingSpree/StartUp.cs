using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.ShoppingSpree
{
	class StartUp
	{
		static void Main(string[] args)
		{
			string[] holdPepol = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
			string[] holdProduckts = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

			List<Person> pepol = new List<Person>();
			List<Product> products = new List<Product>();

			GetPepol(holdPepol, pepol);
			GetProducts(holdProduckts, products);

			while (true)
			{
				string[] comands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

				if (comands[0] == "END") break;

				string curentName = comands[0];
				string curentProduckt = comands[1];

				pepol.First(x => x.Name == curentName).Add(products.First(x => x.Name == curentProduckt));
			}

			foreach (var item in pepol)
			{
				Console.WriteLine(item.ToString());
			}
		}

		private static void GetProducts(string[] holdProduckts, List<Product> products)
		{
			foreach (var item in holdProduckts)
			{
				string[] hold = item.Split("=");

				try
				{
					Product produckt = new Product(hold[0], decimal.Parse(hold[1]));

					products.Add(produckt);
				}
				catch (ArgumentException ex)
				{
					Console.WriteLine(ex.Message);
					Environment.Exit(0);
				}
			}
		}

		private static void GetPepol(string[] holdPepol, List<Person> pepol)
		{
			foreach (var item in holdPepol)
			{
				string[] hold = item.Split("=");

				try
				{
					Person person = new Person(hold[0], decimal.Parse(hold[1]));

					pepol.Add(person);
				}
				catch (ArgumentException ex)
				{
					Console.WriteLine(ex.Message);
					Environment.Exit(0);
				}
			}
		}
	}
}
