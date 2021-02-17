using System;
using System.Collections.Generic;
using System.Text;

namespace TesExceptions.Exceptions
{
	public class InvalidSongException : FormatException
	{
		public InvalidSongException(string mesige = "Invalid song.")
			: base(mesige)
		{
		}
	}
}
