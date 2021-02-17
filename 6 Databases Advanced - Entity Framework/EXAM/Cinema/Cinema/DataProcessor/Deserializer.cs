using System.Linq;
using Cinema.Data.Models;
using Cinema.DataProcessor.ImportDto;

namespace Cinema.DataProcessor
{
    using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.Globalization;
	using System.IO;
	using System.Text;
	using System.Xml.Serialization;
	using Data;
	using Newtonsoft.Json;

	public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie 
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat 
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection 
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket 
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
	        var allMovies = JsonConvert.DeserializeObject<Movie[]>(jsonString);

			var validMovies = new List<Movie>();

	        var sb = new StringBuilder();

	        foreach (var movieDto in allMovies)
	        {
		        var check = context.Movies.FirstOrDefault(x => x.Id == movieDto.Id);
		        var isValid = IsValid(movieDto);

		        if (isValid && check == null)
		        {
					validMovies.Add(movieDto);
					sb.AppendLine($"Successfully imported {movieDto.Title} with genre {movieDto.Genre} and rating {movieDto.Rating:f2}!");
		        }
		        else
		        {
					sb.AppendLine(ErrorMessage);
				}
			}

	        context.Movies.AddRange(validMovies);
	        context.SaveChanges();

	        return sb.ToString().TrimEnd();
		}

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
			var allHalls = JsonConvert.DeserializeObject<ImportHallDto[]>(jsonString);

			var validHalls = new List<Hall>();

			var sb = new StringBuilder();

			foreach (var hallDto in allHalls)
			{
				bool seatsCheck = hallDto.Seats > 0;

				var isValid = IsValid(hallDto);

				if (isValid && seatsCheck)
				{
					var hall = new Hall
					{
						Name = hallDto.Name,
						Is4Dx = hallDto.Is4Dx,
						Is3D = hallDto.Is3D
					};

					for (int i = 0; i < hallDto.Seats; i++)
					{
						var seat = new Seat();

						hall.Seats.Add(seat);
					}

					var hold = "";

					if (hallDto.Is3D == true && hallDto.Is4Dx == true)
					{
						hold = "4Dx/3D";
					}
					else if(hallDto.Is3D == true)
					{
						hold = "3D";
					}
					else if(hallDto.Is4Dx == true)
					{
						hold = "4Dx";
					}
					else
					{
						hold = "Normal";
					}

					validHalls.Add(hall);
					sb.AppendLine($"Successfully imported {hallDto.Name}({hold}) with {hallDto.Seats} seats!");
				}
				else
				{
					sb.AppendLine(ErrorMessage);
				}
			}


			context.Halls.AddRange(validHalls);
			context.SaveChanges();

			return sb.ToString().TrimEnd();
		}

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
			var xmlSerializer = new XmlSerializer(typeof(ImportProjectionsDto[]), new XmlRootAttribute("Projections"));

			var ProjectionsDto = (ImportProjectionsDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

			var sb = new StringBuilder();

			var projections = new List<Projection>();

			foreach (var proDto in ProjectionsDto)
			{
				var movie = context.Movies.FirstOrDefault(x => x.Id == proDto.MovieId);
				var hall = context.Halls.FirstOrDefault(x => x.Id == proDto.HallId);

				if (movie == null || hall == null)
				{
					sb.AppendLine(ErrorMessage);
					continue;
				}

				var projection = new Projection
				{
					MovieId = proDto.MovieId,
					Movie = context.Movies.FirstOrDefault(x => x.Id == proDto.MovieId),
					HallId = proDto.HallId,
					Hall = context.Halls.FirstOrDefault(x => x.Id == proDto.HallId),
					DateTime = DateTime.ParseExact(proDto.DateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
				};

				projections.Add(projection);
				sb.AppendLine($"Successfully imported projection {projection.Movie.Title} on {projection.DateTime.ToString("MM/dd/yyyy")}!");
			}

			context.Projections.AddRange(projections);
			context.SaveChanges();

			return sb.ToString().TrimEnd();
		}

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
			var xmlSerializer = new XmlSerializer(typeof(ImportCustomerDto[]), new XmlRootAttribute("Customers"));

			var customersDto = (ImportCustomerDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

			var sb = new StringBuilder();

			var customers = new List<Customer>();

			foreach (var cuDto in customersDto)
			{
				var isValidCu = IsValid(cuDto);
				var check = false;

				if (!isValidCu)
				{
					sb.AppendLine(ErrorMessage);
					continue;
				}

				var customer = new Customer
				{
					FirstName = cuDto.FirstName,
					LastName = cuDto.LastName,
					Age = cuDto.Age,
					Balance = cuDto.Balance
				};

				foreach (var tiDto in cuDto.Tickets)
				{
					var isValidTi = IsValid(tiDto);

					if (!isValidTi)
					{
						check = true;
						break;
					}

					var ticket = new Ticket
					{
						ProjectionId = tiDto.ProjectionId,
						Price = tiDto.Price
					};

					customer.Tickets.Add(ticket);
				}

				if (check)
				{
					sb.AppendLine(ErrorMessage);
					continue;
				}

				customers.Add(customer);
				sb.AppendLine($"Successfully imported customer {customer.FirstName} {customer.LastName} with bought tickets: {customer.Tickets.Count()}!");
			}

			context.Customers.AddRange(customers);
			context.SaveChanges();

			return sb.ToString().TrimEnd();
		}

        private static bool IsValid(object entity)
        {
	        var validationContext = new ValidationContext(entity);
	        var validationResult = new List<ValidationResult>();

	        bool isValid = Validator.TryValidateObject(entity, validationContext, validationResult, true);

	        return isValid;
        }
	}
}