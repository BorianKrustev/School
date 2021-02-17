using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDto
{
	[XmlType("Officer")]
	public class ImportOfficerDto
	{
		[Required]
		[MinLength(3), MaxLength(30)]
		public string Name { get; set; }

		[Range(typeof(decimal), "0.00", "79228162514264337593543950335")]
		public decimal Money { get; set; }

		[Required]
		public string Position { get; set; }

		[Required]
		public string Weapon { get; set; }

		[Required]
		public int DepartmentId { get; set; }

		[XmlArray("Prisoners")]
		public OfficerPrisonerDto[] Prisoners { get; set; }
	}

	[XmlType("Prisoner")]
	public class OfficerPrisonerDto
	{
		[XmlAttribute("id")]
		public int Id { get; set; }
	}
}