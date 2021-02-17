using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace _4.Telephony
{
	public class Smartphone : ICall, IBrows
	{
		public void Brows(string url)
		{
			if (url.Any(x => Char.IsDigit(x)))
			{
				Console.WriteLine("Invalid URL!");
			}
			else
			{
				Console.WriteLine($"Browsing: {url}!");
			}
		}

		public void Call(string number)
		{
			if (number.All(x => Char.IsDigit(x)))
			{
				Console.WriteLine($"Calling... {number}");
			}
			else
			{
				Console.WriteLine($"Invalid number!");
			}
		}
	}
}
