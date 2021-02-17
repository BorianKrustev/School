using System.ComponentModel.DataAnnotations;
using System.Xml;
using System.Xml.Serialization;

namespace Cinema.DataProcessor.ImportDto
{
	[XmlType("Projection")]
	public class ImportProjectionsDto
	{
		public int MovieId { get; set; }

		public int HallId { get; set; }

		[Required]
		public string DateTime { get; set; }
	}
}