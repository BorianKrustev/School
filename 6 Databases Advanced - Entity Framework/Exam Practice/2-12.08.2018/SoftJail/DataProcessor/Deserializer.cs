using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using SoftJail.Data.Models;
using SoftJail.Data.Models.Enums;
using SoftJail.DataProcessor.ImportDto;

namespace SoftJail.DataProcessor
{

    using Data;
    using System;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
	        var allDepartments = JsonConvert.DeserializeObject<Department[]>(jsonString);

			var valodDepartments = new List<Department>();

			var sb = new StringBuilder();

			foreach (var department in allDepartments)
			{
				var isValid = IsValid(department) && department.Cells.All(IsValid);

				if (isValid)
				{
					valodDepartments.Add(department);
					sb.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");
				}
				else
				{
					sb.AppendLine("Invalid Data");
				}
			}

			context.Departments.AddRange(valodDepartments);
			context.SaveChanges();	
			
			return sb.ToString().TrimEnd();

			//var departmentsCellsDto = JsonConvert.DeserializeObject<ImportDepartmentDto[]>(jsonString);
			//
			//var sb = new StringBuilder();
			//
			//var departments = new List<Department>();
			//
			//foreach (var depDto in departmentsCellsDto)
			//{
			//	if (!IsValid(depDto))
			//	{
			//		sb.AppendLine("Invalid Data");
			//		continue;
			//	}
			//
			//	var department = new Department
			//	{
			//		Name = depDto.Name
			//	};
			//
			//	bool check = false;
			//
			//	foreach (var cellDto in depDto.Cells)
			//	{
			//		if (!IsValid(cellDto))
			//		{
			//			check = true;
			//			break;
			//		}
			//
			//		var cell = new Cell
			//		{
			//			CellNumber = cellDto.CellNumber,
			//			HasWindow = cellDto.HasWindow
			//		};
			//
			//		department.Cells.Add(cell);
			//	}
			//
			//	if (check)
			//	{
			//		sb.AppendLine("Invalid Data");
			//		continue;
			//	}
			//
			//	departments.Add(department);
			//	sb.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");
			//}
			//
			//context.Departments.AddRange(departments);
			//context.SaveChanges();
			//
			//return sb.ToString().TrimEnd();
		}

		public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
	        var prisonersDto = JsonConvert.DeserializeObject<ImportPrisonerDto[]>(jsonString);

	        var sb = new StringBuilder();

	        var prisoners = new List<Prisoner>();

	        foreach (var priDto in prisonersDto)
	        {
		        if (!IsValid(priDto))
		        {
			        sb.AppendLine("Invalid Data");
			        continue;
		        }

				var prisoner = new Prisoner
				{
					FullName = priDto.FullName,
					Nickname = priDto.Nickname,
					Age = priDto.Age,
					IncarcerationDate = DateTime.ParseExact(priDto.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
					ReleaseDate = priDto.ReleaseDate == null ? (DateTime?)null : DateTime.ParseExact(priDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture), // TODO
					Bail = priDto.Bail,
					CellId = priDto.CellId
				};

				bool check = false;

				foreach (var mailDto in priDto.Mails)
				{
					if (!IsValid(mailDto))
					{
						check = true;
						break;
					}

					var mail = new Mail
					{
						Description = mailDto.Description,
						Sender = mailDto.Sender,
						Address = mailDto.Address
					};

					prisoner.Mails.Add(mail);
				}

				if (check)
				{
					sb.AppendLine("Invalid Data");
					continue;
				}

				prisoners.Add(prisoner);
				sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
	        }

			context.Prisoners.AddRange(prisoners);
			context.SaveChanges();

			return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
			var xmlSerializer = new XmlSerializer(typeof(ImportOfficerDto[]), new XmlRootAttribute("Officers"));

			var officersDto = (ImportOfficerDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

			var sb = new StringBuilder();

			var officers = new List<Officer>();

			foreach (var dto in officersDto)
			{
				var isWeaponValid = Enum.TryParse(dto.Weapon, out Weapon weapon);
				bool isPositionValid = Enum.TryParse(dto.Position, out Position position);

				var isValid = IsValid(dto) && isWeaponValid && isPositionValid;

				if (isValid)
				{
					var officer = new Officer
					{
						FullName = dto.Name,
						Salary = dto.Money,
						Position = position,
						Weapon = weapon,
						DepartmentId = dto.DepartmentId,
						OfficerPrisoners = dto.Prisoners.Select(x => new OfficerPrisoner
						{
							PrisonerId = x.Id
						})
						.ToArray()
					};

					officers.Add(officer);
					sb.AppendLine($"Imported {officer.FullName} ({officer.OfficerPrisoners.Count} prisoners)");
				}
				else
				{
					sb.AppendLine("Invalid Data");
				}
			}

			context.Officers.AddRange(officers);
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