using System;
using System.Collections.Generic;
using System.Text;
using Remotion.Linq.Parsing.Structure.IntermediateModel;

namespace P01_HospitalDatabase.Data.Models
{
	public class Medicament
	{
		public Medicament()
		{
			this.Prescriptions = new HashSet<PatientMedicament>();
		}

		public int MedicamentId { get; set; }
		public string Name { get; set; }

		public ICollection<PatientMedicament> Prescriptions { get; set; }
	}
}
