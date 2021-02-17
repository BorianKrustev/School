using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using AutoMapper;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
	        //using (context)
	        //{
	        //	context.Database.EnsureDeleted();
	        //	context.Database.EnsureCreated();
	        //}

			//Mapper.Initialize(x =>
			//{
			//	x.AddProfile<ProductShopProfile>();
			//});

			//var usersXml = File.ReadAllText(@"../../../Datasets/users.xml");
			//var usersXml = File.ReadAllText(@"../../../Datasets/products.xml");
			//var usersXml = File.ReadAllText(@"../../../Datasets/categories.xml");
			//var usersXml = File.ReadAllText(@"../../../Datasets/categories-products.xml");

			using (ProductShopContext context = new ProductShopContext())
			{
				Console.WriteLine(GetUsersWithProducts(context));
			}
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
	        XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportUserDto[]), new XmlRootAttribute("Users"));

	        var usersDto = (ImportUserDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

			var users = new List<User>();
	        foreach (var userDto in usersDto)
	        {
		        var user = Mapper.Map<User>(userDto);
		        users.Add(user);
	        }

			context.Users.AddRange(users);
			context.SaveChanges();

			return $"Successfully imported {users.Count}";
		}

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProductsDto[]), new XmlRootAttribute("Products"));

			var productsDto = (ImportProductsDto[]) xmlSerializer.Deserialize(new StringReader(inputXml));

			var products = new List<Product>();
			foreach (var productDto in productsDto)
			{
				var product = new Product
				{
					Name = productDto.Name,
					Price = productDto.Price,
					SellerId = productDto.SellerId,
					BuyerId = productDto.BuyerId
				};
				products.Add(product);
			}

			context.Products.AddRange(products);
			context.SaveChanges();

			return $"Successfully imported {products.Count}";
		}

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
	        XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCategoriesDto[]), new XmlRootAttribute("Categories"));

	        var categoriesDto = (ImportCategoriesDto[]) xmlSerializer.Deserialize(new StringReader(inputXml));

			var categories = new List<Category>();
			foreach (var categorieDto in categoriesDto)
			{
				if (categorieDto.Name == null)
				{
					continue;
				}

				var categorie = new Category
				{
					Name = categorieDto.Name
				};
				categories.Add(categorie);
			}

			context.Categories.AddRange(categories);
			context.SaveChanges();

			return $"Successfully imported {categories.Count}";
		}

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
	        XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCategoryProductDto[]), new XmlRootAttribute("CategoryProducts"));

	        var CategoriesProductsDto = (ImportCategoryProductDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

	        var categoriesProducts = new List<CategoryProduct>();
	        foreach (var categoryProductDto in CategoriesProductsDto)
	        {
		        var product = context.Products.Find(categoryProductDto.ProductId);
		        var category = context.Categories.Find(categoryProductDto.CategoryId);

		        if (product == null || category == null)
		        {
			        continue;
		        }

		        var categoryProduct = new CategoryProduct
		        {
					ProductId = product.Id,
					CategoryId = category.Id
				};

		        categoriesProducts.Add(categoryProduct);
			}

			context.CategoryProducts.AddRange(categoriesProducts);
			context.SaveChanges();

			return $"Successfully imported {categoriesProducts.Count}";
		}

		public static string GetProductsInRange(ProductShopContext context)
        {
	        var productsInRange = context.Products
		        .Where(x => x.Price >= 500 && x.Price <= 1000)
		        .Select(x => new ExportProductsInRangeDto
		        {
			        Name = x.Name,
			        Price = x.Price,
					Buyer = x.Buyer.FirstName + " " + x.Buyer.LastName
		        })
		        .OrderBy(x => x.Price)
		        .Take(10)
		        .ToArray();

			XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportProductsInRangeDto[]), new XmlRootAttribute("Products"));

			var sb = new StringBuilder();

			var namespaces = new XmlSerializerNamespaces(new []
			{
				new XmlQualifiedName("",""), 
			});

			xmlSerializer.Serialize(new StringWriter(sb), productsInRange, namespaces);

			return sb.ToString().TrimEnd();
        }

		public static string GetSoldProducts(ProductShopContext context)
		{
			var users = context.Users
				.Where(x => x.ProductsSold.Count >= 1)
				.OrderBy(x => x.LastName)
				.ThenBy(x => x.FirstName)
				.Select(x => new ExportSoldProductDto
				{
					FirstName = x.FirstName,
					LastName = x.LastName,
					ProductDto = x.ProductsSold.Select(p => new ProductDto
					{
						Name = p.Name,
						Price = p.Price
					}).ToArray()
				})
				.Take(5)
				.ToArray();

			XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportSoldProductDto[]), new XmlRootAttribute("Users"));

			var sb = new StringBuilder();

			var namespaces = new XmlSerializerNamespaces(new[]
			{
				XmlQualifiedName.Empty
			});

			xmlSerializer.Serialize(new StringWriter(sb), users, namespaces);

			return sb.ToString().TrimEnd();
		}

		public static string GetCategoriesByProductsCount(ProductShopContext context)
		{
			var categories = context.Categories
						.Select(x => new ExportCategoriesByProductsCountDto
						{
							Name = x.Name,
							Count = x.CategoryProducts.Count,
							AveragePrice = x.CategoryProducts.Select(p => p.Product.Price).Average(),
							TotalRevenue = x.CategoryProducts.Select(p => p.Product.Price).Sum()
						})
						.OrderByDescending(x => x.Count)
						.ThenBy(x => x.TotalRevenue)
						.ToArray();

			XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCategoriesByProductsCountDto[]), new XmlRootAttribute("Categories"));

			var sb = new StringBuilder();

			var namespaces = new XmlSerializerNamespaces(new[]
			{
				XmlQualifiedName.Empty
			});

			xmlSerializer.Serialize(new StringWriter(sb), categories, namespaces);

			return sb.ToString().TrimEnd();
		}

		public static string GetUsersWithProducts(ProductShopContext context)
		{
			var users = context.Users
				.Where(x => x.ProductsSold.Count >= 1)
				.OrderByDescending(x => x.ProductsSold.Count)
				.Select(x => new ExportUsersWithProductsDto
				{
					FirstName = x.FirstName,
					LastName = x.LastName,
					Age = x.Age,
					SoldProductDto = new SoldProductDto
					{
						Count = x.ProductsSold.Count,
						ProductDto = x.ProductsSold.Select(p => new ProductDto
						{
							Name = p.Name,
							Price = p.Price
						})
						.OrderByDescending(p => p.Price)
						.ToArray()
					}
				})
				.Take(10)
				.ToArray();

			var customExport = new ExportCustomUserProducktDto
			{
				Count = context.Users
					.Count(x => x.ProductsSold.Any()),
				ExportUsersWithProductsDto = users
			};

			XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCustomUserProducktDto), new XmlRootAttribute("Users"));

			var sb = new StringBuilder();

			var namespaces = new XmlSerializerNamespaces(new[]
			{
				XmlQualifiedName.Empty
			});

			xmlSerializer.Serialize(new StringWriter(sb), customExport, namespaces);

			return sb.ToString().TrimEnd();
		}
	}
}