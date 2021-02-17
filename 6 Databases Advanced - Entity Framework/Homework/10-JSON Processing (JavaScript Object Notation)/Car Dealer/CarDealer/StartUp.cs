using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
			var context = new CarDealerContext();
			//context.Database.EnsureDeleted();
			//context.Database.EnsureCreated();

			var usersJson = File.ReadAllText(@"D:\School\Projects\Car Dealer\CarDealer\Datasets\cars.json");

			Console.WriteLine(ImportCars(context, usersJson));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
	        var suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson).ToList();

			context.Suppliers.AddRange(suppliers);
			context.SaveChanges();

			return $"Successfully imported {suppliers.Count}.";
        }

		//public static string ImportParts(CarDealerContext context, string inputJson)
		//{
		//    var parts = JsonConvert.DeserializeObject<List<Part>>(inputJson).ToList();
		//
		//	context.Parts.AddRange(parts);
		//	context.SaveChanges();
		//
		//	return $"Successfully imported {parts.Count}.";
		//}

		//public static string ImportCars(CarDealerContext context, string inputJson)
		//{
		//	var cars = JsonConvert.DeserializeObject<List<Car>>(inputJson).ToList();
		//
		//	context.Cars.AddRange(cars);
		//	context.SaveChanges();
		//
		//	return $"Successfully imported {cars.Count}.";
		//}

		public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
	        var customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson).ToList();

			context.Customers.AddRange(customers);
			context.SaveChanges();

	        return $"Successfully imported {customers.Count}.";
		}
	}
}