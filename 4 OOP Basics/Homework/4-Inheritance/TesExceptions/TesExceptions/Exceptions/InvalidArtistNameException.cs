using System;
using System.Collections.Generic;
using System.Text;

namespace TesExceptions.Exceptions
{
	class InvalidArtistNameException : InvalidSongException
	{
		public InvalidArtistNameException(string mesige = "Artist name should be between 3 and 20 symbols.")
			: base(mesige)
		{
		}
	}
}
