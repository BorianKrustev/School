using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetClinic.Models
{
	public class Procedure
	{
		public Procedure()
		{
			this.ProcedureAnimalAids = new List<ProcedureAnimalAid>();
		}

		[Key]
		public int Id { get; set; }

		public int AnimalId { get; set; }
		[Required]
		public Animal Animal { get; set; }

		public int VetId { get; set; }
		[Required]
		public Vet Vet { get; set; }

		public ICollection<ProcedureAnimalAid> ProcedureAnimalAids { get; set; }

		public decimal Cost { get; set; } //TODO Mybe

		[Required]
		public DateTime DateTime { get; set; }
	}
}