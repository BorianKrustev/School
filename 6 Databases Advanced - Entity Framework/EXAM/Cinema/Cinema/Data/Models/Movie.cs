using System;
using Cinema.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Cinema.Data.Models
{
    public class Movie
	{
		public Movie()
		{
			this.Projections = new List<Projection>();
		}

		public int Id { get; set; }

		[Required]
		[MinLength(3), MaxLength(20)]
		public string Title { get; set; }

		[Required]
		public Genre Genre { get; set; }

		[Required]
		public TimeSpan Duration { get; set; }

		[Required]
		[Range(1, 10)] //TODO Mybe
		public double Rating { get; set; }

		[Required]
		[MinLength(3), MaxLength(20)]
		public string Director { get; set; }

		public ICollection<Projection> Projections { get; set; }
	}
}
