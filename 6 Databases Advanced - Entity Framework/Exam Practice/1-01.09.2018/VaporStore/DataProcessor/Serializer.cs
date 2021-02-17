using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using VaporStore.Data.Models.Enums;
using VaporStore.DataProcessor.ExportDtos;
using Formatting = Newtonsoft.Json.Formatting;

namespace VaporStore.DataProcessor
{
	using System;
	using Data;

	public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
			var genres = context.Genres
				.Where(x => genreNames.Contains(x.Name))
				.Select(x => new
				{
					Id = x.Id,
					Genre = x.Name,
					Games = x.Games
						.Where(y => y.Purchases.Count >= 1)
						.Select(y => new
					{
						Id = y.Id,
						Title = y.Name,
						Developer = y.Developer.Name,
						Tags = string.Join(", ", y.GameTags.Select(t => t.Tag.Name).ToArray()),
						Players = y.Purchases.Count
					})
					.OrderByDescending(p => p.Players)
					.ThenBy(p => p.Id)
					.ToArray(),
					TotalPlayers = x.Games.Sum(v => v.Purchases.Count)
				})
				.OrderByDescending(x => x.TotalPlayers)
				.ThenBy(x => x.Id)
				.ToArray();

			var jsonResult = JsonConvert.SerializeObject(genres, Formatting.Indented);

			return jsonResult;
		}

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
			var storeTypeEnum = Enum.Parse<PurchaseType>(storeType);

			var users = context.Users
				.Where(x => x.Cards.SelectMany(y => y.Purchases).Any(v => v.Type == storeTypeEnum))
				.Select(x => new ExportUserDto
				{
					Username = x.Username,
					Purchases = x.Cards.SelectMany(p => p.Purchases).Select(p => new ExportPurchaseDto
					{
						Card = p.Card.Number,
						Cvc = p.Card.Cvc,
						Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
						Game = new ExportGameDto
						{
							Genre = p.Game.Genre.Name,
							Title = p.Game.Name,
							Price = p.Game.Price
						}
					})
					.OrderByDescending(d => d.Date)
					.ToArray(),
					TotalSpent = x.Cards.SelectMany(p => p.Purchases).Sum(p => p.Game.Price)
				})
				.OrderByDescending(x => x.TotalSpent)
				.ThenBy(x => x.Username)
				.ToArray();

			var xmlSerializer = new XmlSerializer(typeof(ExportUserDto[]), new XmlRootAttribute("Users"));

			var nameSpaces = new XmlSerializerNamespaces(new []
			{
				XmlQualifiedName.Empty
			});

			var sb = new StringBuilder();

			xmlSerializer.Serialize(new StringWriter(sb), users, nameSpaces);

			return sb.ToString().TrimEnd();
		}
	}
}