using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;
using System.IO;
using Newtonsoft.Json.Serialization;
using ProductShop.Dtos.Export;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
			var context = new ProductShopContext();
			//context.Database.EnsureDeleted();
			//context.Database.EnsureCreated();

			//var usersJson = File.ReadAllText(@"D:\School\Projects\Product Shop\ProductShop\Datasets\users.json");
			//var usersJson = File.ReadAllText(@"D:\School\Projects\Product Shop\ProductShop\Datasets\products.json");
			//var usersJson = File.ReadAllText(@"D:\School\Projects\Product Shop\ProductShop\Datasets\categories.json");
			//var usersJson = File.ReadAllText(@"D:\School\Projects\Product Shop\ProductShop\Datasets\categories-products.json");

			Console.WriteLine(GetCategoriesByProductsCount(context));
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
	        var users = JsonConvert.DeserializeObject<List<User>>(inputJson)
		        .Where(x => x.LastName != null && x.LastName.Length >= 3)
		        .ToList();

			context.Users.AddRange(users);
			context.SaveChanges();

	        return $"Successfully imported {users.Count}";
		}

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
	        var products = JsonConvert.DeserializeObject<List<Product>>(inputJson)
		        .Where(x => !string.IsNullOrEmpty(x.Name) && x.Name.Trim().Length >= 3)
		        .ToList();

			context.Products.AddRange(products);
			context.SaveChanges();

			return $"Successfully imported {products.Count}";
		}

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
	        var categories = JsonConvert.DeserializeObject<List<Category>>(inputJson)
		        .Where(x => x.Name != null && x.Name.Trim().Length >= 3 && x.Name.Length <= 15)
		        .ToList();

	        context.Categories.AddRange(categories);
	        context.SaveChanges();

	        return $"Successfully imported {categories.Count}";
		}

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
	        var categoryProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson).ToList();

			context.CategoryProducts.AddRange(categoryProducts);
			context.SaveChanges();

			return $"Successfully imported {categoryProducts.Count}";
		}

        public static string GetProductsInRange(ProductShopContext context)
        {
	        var productsInRang = context.Products
						.Select(x => new ProductDto
						{
						    Name = x.Name,
						    Price = x.Price,
						    Seller = $"{x.Seller.FirstName} {x.Seller.LastName}" //x.Seller.FirstName == null ? x.Seller.LastName : $"{x.Seller.FirstName} {x.Seller.LastName}"
						})
						.Where(x => x.Price >= 500 && x.Price <= 1000)
						.OrderBy(x => x.Price)
						.ToList();

	        var json = JsonConvert.SerializeObject(productsInRang, Formatting.Indented);

	        return json;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
	        var soldProducts = context.Users
						.Where(x => x.ProductsSold.Any(y => y.Buyer != null))
						.Select(x => new
						{
						    firstName = x.FirstName,
						    lastName = x.LastName,
						    soldProducts = x.ProductsSold
						        .Where(c => c.Buyer != null)
						        .Select(v => new
						        {
							        name = v.Name,
							        price = v.Price,
							        buyerFirstName = v.Buyer.FirstName,
							        buyerLastName = v.Buyer.LastName
						        }).ToList()
						})
						.OrderBy(x => x.lastName)
						.ThenBy(x => x.firstName)
						.ToList();

	        var json = JsonConvert.SerializeObject(soldProducts, Formatting.Indented);

	        return json;
        }

		public static string GetCategoriesByProductsCount(ProductShopContext context)
		{
			var result = context.Categories
				.Select(c => new
				{
					category = c.Name,
					productsCount = c.CategoryProducts
						.Select(cp => cp.Product)
						.Count(),
					averagePrice = c.CategoryProducts
						.Select(cp => cp.Product)
						.Average(p => p.Price),
					totalRevenue = c.CategoryProducts
						.Select(cp => cp.Product)
						.Sum(p => p.Price)
				})
				.OrderByDescending(c => c.productsCount)
				.ToList();

			//var result = context.Categories
			//	.Select(x => new
			//	{
			//		name = x.Name,
			//		productsCount = x.CategoryProducts.Select(s => s.Product).Count(),
			//		averagePrice = x.CategoryProducts.Select(s => s.Product.Price).Average(),
			//		totalRevenue = x.CategoryProducts.Select(s => s.Product.Price).Sum()
			//	})
			//	.OrderByDescending(x => x.productsCount)
			//	.ToList();

			var json = JsonConvert.SerializeObject(result, Formatting.Indented);
			return json;
		}

		public static string GetUsersWithProducts(ProductShopContext context)
		{
			var users = context.Users
				.Where(x => x.ProductsSold.Any(c => c.Buyer != null))
				.OrderByDescending(x => x.ProductsSold.Count(p => p.Buyer != null))
				.Select(x => new
				{
					firstName = x.FirstName,
					lastName = x.LastName,
					age = x.Age,
					soldProducts = new
					{
						count = x.ProductsSold.Count(p => p.Buyer != null),
						products = x.ProductsSold
							.Where(c => c.Buyer != null)
							.Select(v => new
							{
								name = v.Name,
								price = v.Price
							})
							.ToList()
					}
				})
				.ToList();

			var result = new
			{
				usersCount = users.Count,
				users = users
			};

			DefaultContractResolver contractResolver = new DefaultContractResolver()
			{
				NamingStrategy = new CamelCaseNamingStrategy()
			};

			var json = JsonConvert.SerializeObject(
				result, 
				new JsonSerializerSettings
				{
					Formatting = Formatting.Indented,
					ContractResolver = contractResolver,
					NullValueHandling = NullValueHandling.Ignore
				});

			return json;
		}
	}
}