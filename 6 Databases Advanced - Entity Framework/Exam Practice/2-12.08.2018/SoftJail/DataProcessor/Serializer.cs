using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using SoftJail.DataProcessor.ExportDto;
using Formatting = Newtonsoft.Json.Formatting;

namespace SoftJail.DataProcessor
{

    using Data;
    using System;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
	        var prisonersByCells = context.Prisoners
		        .Where(x => ids.Contains(x.Id))
		        .Select(x => new
		        {
			        Id = x.Id,
			        Name = x.FullName,
			        CellNumber = x.Cell.CellNumber,
			        Officers = x.PrisonerOfficers.Select(o => new
				        {
					        OfficerName = o.Officer.FullName,
					        Department = o.Officer.Department.Name
				        })
				        .OrderBy(o => o.OfficerName)
						.ToArray(),
			        TotalOfficerSalary = x.PrisonerOfficers.Select(o => o.Officer.Salary).Sum()
		        })
		        .OrderBy(x => x.Name)
				.ThenBy(x => x.Id)
				.ToArray();

	        var jsonResult = JsonConvert.SerializeObject(prisonersByCells, Formatting.Indented);

	        return jsonResult;
		}

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
	        var prisonersNamesArr = prisonersNames.Split(",").ToArray();

	        var exportPrisonersInbox = context.Prisoners
		        .Where(x => prisonersNamesArr.Contains(x.FullName))
		        .Select(x => new ExportPrisonerDto
		        {
			        Id = x.Id,
			        Name = x.FullName,
			        IncarcerationDate = x.IncarcerationDate.ToString("yyyy-MM-dd"),
			        EncryptedMessages = x.Mails.Select(m => new MailDto
			        {
				        Description = Reverse(m.Description)
					}).ToArray()
		        })
		        .OrderBy(x => x.Name)
		        .ThenBy(x => x.Id)
		        .ToArray();

	        var xmlSerializer = new XmlSerializer(typeof(ExportPrisonerDto[]), new XmlRootAttribute("Prisoners"));

	        var nameSpaces = new XmlSerializerNamespaces(new[]
	        {
		        XmlQualifiedName.Empty
	        });

	        var sb = new StringBuilder();

	        xmlSerializer.Serialize(new StringWriter(sb), exportPrisonersInbox, nameSpaces);

	        return sb.ToString().TrimEnd();
        }

        private static string Reverse(string text)
		{
			char[] cArray = text.ToCharArray();
			string reverse = String.Empty;
			for (int i = cArray.Length - 1; i > -1; i--)
			{
				reverse += cArray[i];
			}
			return reverse;
		}
	}
}