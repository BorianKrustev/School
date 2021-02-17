using System.ComponentModel.DataAnnotations;

namespace VaporStore.DataProcessor.ImportDtos
{
	public class ImportUserDto
	{
		[Required]
		[RegularExpression("^[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+$")]
		public string FullName { get; set; }

		[Required]
		[MinLength(3), MaxLength(20)]
		public string Username { get; set; }

		[Required]
		public string Email { get; set; }

		[Range(3, 103)]
		public int Age { get; set; }

		public CardsDto[] Cards { get; set; }
	}

	public class CardsDto
	{
		[Required]
		[RegularExpression(@"^[0-9]{4}\s+[0-9]{4}\s+[0-9]{4}\s+[0-9]{4}$")]
		public string Number { get; set; }

		[Required]
		[RegularExpression("^[0-9]{3}$")]
		public string CVC { get; set; }

		public string type { get; set; }
	}
}