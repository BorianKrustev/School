﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Cinema.Data.Models;

namespace Cinema.DataProcessor.ImportDto
{
	public class ImportHallDto
	{
		[Required]
		[MinLength(3), MaxLength(20)]
		public string Name { get; set; }

		public bool Is4Dx { get; set; }

		public bool Is3D { get; set; }

		public int Seats { get; set; }
	}
}