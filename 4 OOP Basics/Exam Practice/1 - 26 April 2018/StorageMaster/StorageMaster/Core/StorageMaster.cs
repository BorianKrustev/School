using StorageMaster.Factorys;
using StorageMaster.Products;
using StorageMaster.Storages;
using StorageMaster.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Core
{
	public class StorageMaster
	{
		private Dictionary<string, Stack<Product>> products;
		private Dictionary<string, Storage> storages;

		private Vehicle curentVehicle;

		private ProductFactory productFactory;
		private StorageFactory storageFactory;

		public StorageMaster()
		{
			this.products = new Dictionary<string, Stack<Product>>();
			this.storages = new Dictionary<string, Storage>();

			this.productFactory = new ProductFactory();
			this.storageFactory = new StorageFactory();
		}

		public string AddProduct(string type, double price)
		{
			Product product = productFactory.CreateProduct(type, price);

			if (!products.ContainsKey(type))
			{
				products.Add(type, new Stack<Product>());
			}

			products[type].Push(product);

			string result = $"Added {type} to pool";
			return result;
		}

		public string RegisterStorage(string type, string name)
		{
			Storage storage = storageFactory.CreateStorage(type, name);
			this.storages.Add(name, storage);

			string result = $"Registered {name}";
			return result;
		}

		public string SelectVehicle(string storageName, int garageSlot)
		{
			this.curentVehicle = storages[storageName].GetVehicle(garageSlot);

			string result = $"Selected {this.curentVehicle.GetType().Name}";
			return result;
		}

		public string LoadVehicle(IEnumerable<string> productNames)
		{
			int count = 0;

			foreach (var name in productNames)
			{
				if (this.curentVehicle.IsFull)
				{
					break;
				}

				if (!this.products.ContainsKey(name))
				{
					throw new InvalidOperationException($"{name} is out of stock!");
				}

				if (this.products[name].Count == 0)
				{
					throw new InvalidOperationException($"{name} is out of stock!");
				}

				Product product = products[name].Pop();
				this.curentVehicle.LoadProduct(product);

				count += 1;
				//var a = this.products.Where(x => x.GetType().Name == item).LastOrDefault(); for List!!!
			}

			string result = $"Loaded {count}/{productNames.Count()} products into {this.curentVehicle.GetType().Name}";
			return result;
		}

		public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
		{
			if (!this.storages.ContainsKey(sourceName))
			{
				throw new InvalidOperationException("Invalid source storage!");
			}

			if (!this.storages.ContainsKey(destinationName))
			{
				throw new InvalidOperationException("Invalid destination storage!");
			}

			Storage sourceStorage = this.storages[sourceName];
			Storage destinationStorage = this.storages[destinationName];
			Vehicle vehicle = sourceStorage.GetVehicle(sourceGarageSlot);

			int destinationSlot = sourceStorage.SendVehicleTo(sourceGarageSlot, destinationStorage);

			string result = $"Sent {vehicle.GetType().Name} to {destinationName} (slot {destinationSlot})";
			return result;
		}

		public string UnloadVehicle(string storageName, int garageSlot)
		{
			Storage storage = this.storages[storageName];

			int productsInVehicle = storage.GetVehicle(garageSlot).Trunk.Count;
			int ulodetProduckts = storage.UnloadVehicle(garageSlot);

			string result = $"Unloaded {ulodetProduckts}/{productsInVehicle} products at {storageName}";
			return result;
		}

		public string GetStorageStatus(string storageName)
		{
			Storage storage = this.storages[storageName];

			Dictionary<string, int> productsCount = new Dictionary<string, int>();
			foreach (Product product in storage.Products)
			{
				string name = product.GetType().Name;

				if (!productsCount.ContainsKey(name))
				{
					productsCount.Add(name, 1);
				}
				else
				{
					productsCount[name] += 1;
				}
			}

			string[] producktsAsString = productsCount
				.OrderByDescending(x => x.Value)
				.ThenBy(x => x.Key)
				.Select(x => $"{x.Key} ({x.Value})")
				.ToArray();

			double productsSum = storage.Products.Sum(x => x.Weight);
			int storygCapasaty = storage.Capacity;

			string stockLIne = $"Stock ({productsSum}/{storygCapasaty}): [{string.Join(", ", producktsAsString)}]";

			string[] garagToString = storage.Garage.Select(x => x == null ? "empty" : x.GetType().Name).ToArray();

			string garadgLine = $"Garage: [{string.Join("|", garagToString)}]";

			string result = stockLIne + Environment.NewLine + garadgLine;
			return result;
		}

		public string GetSummary()
		{
			string[] resultArr = this.storages
				.OrderByDescending(x => x.Value.Products.Sum(p => p.Price))
				.Select(x => $"{x.Key}:{Environment.NewLine}Storage worth: ${x.Value.Products.Sum(p => p.Price):F2}")
				.ToArray();

			string result = $"{string.Join("\n", resultArr)}";
			return result;
		}
	}
}
