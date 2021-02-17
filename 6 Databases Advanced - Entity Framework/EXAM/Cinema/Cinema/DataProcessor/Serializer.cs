using System.Linq;
using Castle.Core.Internal;
using Cinema.DataProcessor.ExportDto;

namespace Cinema.DataProcessor
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Text;
	using System.Xml;
	using System.Xml.Serialization;
	using Data;
	using Newtonsoft.Json;

	public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
	        var topMovies = context.Movies
		        .Where(x => x.Rating >= rating && x.Projections.Select(t => t.Tickets).Count() > 0)
		        .Select(x => new
		        {
			        MovieName = x.Title,
			        Rating = x.Rating.ToString("0.00"),
					TotalIncomes = x.Projections.Select(t => t.Tickets.Select(p => p.Price).Sum()).Sum().ToString("0.00"),
			        Customers = x.Projections.SelectMany(t => t.Tickets).Select(c => c.Customer).Select(q => new
			        {
				        FirstName = q.FirstName,
				        LastName = q.LastName,
				        Balance = q.Balance.ToString("0.00")
					})
						.OrderByDescending(q => q.Balance)
						.ThenBy(q => q.FirstName)
						.ThenBy(q => q.LastName)
						.ToArray()
				})
		        .OrderByDescending(x => decimal.Parse(x.Rating))
		        .ThenByDescending(x => decimal.Parse(x.TotalIncomes))
		        .Take(10)
		        .ToArray();

	        var jsonResult = JsonConvert.SerializeObject(topMovies, Newtonsoft.Json.Formatting.Indented);

	        return jsonResult;
		}
		
		public static string ExportTopCustomers(CinemaContext context, int age)
		{
			var topCust = context.Customers
		        .Where(x => x.Age >= age)
		        .Select(x => new ExportTopCustomerDto
		        {
			        FirstName = x.FirstName,
			        LastName = x.LastName,
			        SpentMoney = x.Tickets.Select(p => p.Price).Sum().ToString("0.00"),
			        SpentTime = Metod(x.Tickets.Select(p => p.Projection.Movie.Duration))
				})
		        .OrderByDescending(x => decimal.Parse(x.SpentMoney))
		        .Take(10)
		        .ToArray();

			var xmlSerializer = new XmlSerializer(typeof(ExportTopCustomerDto[]), new XmlRootAttribute("Customers"));

			var nameSpaces = new XmlSerializerNamespaces(new[]
			{
				XmlQualifiedName.Empty
			});

			var sb = new StringBuilder();

			xmlSerializer.Serialize(new StringWriter(sb), topCust, nameSpaces);

			return sb.ToString().TrimEnd();
		}

		private static string Metod(IEnumerable<TimeSpan> enumerable)
		{
			var hod = new TimeSpan();

			foreach (var en in enumerable)
			{
				hod += en;
			}

			return hod.ToString();
		}
	}
}