using System;
using System.Linq;
using System.Collections.Generic;

namespace _5.DateModifier
{
	class Program
	{
		static void Main(string[] args)
		{
			string forsDate = Console.ReadLine();
			string secondDate = Console.ReadLine();

			DateModifier diff = new DateModifier();

			Console.WriteLine($"{diff.PrintDif(forsDate, secondDate)}");
		}
	}
}
