using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetClinic.Models
{
	public class AnimalAid
	{
		public AnimalAid()
		{
			this.AnimalAidProcedures = new LinkedList<ProcedureAnimalAid>();
		}

		[Key]
		public int Id { get; set; }

		[Required]
		[MinLength(3), MaxLength(30)]
		public string Name { get; set; } //TODO unique Done!

		[Required]
		[Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
		public decimal Price { get; set; }

		public ICollection<ProcedureAnimalAid> AnimalAidProcedures { get; set; }
	}
}