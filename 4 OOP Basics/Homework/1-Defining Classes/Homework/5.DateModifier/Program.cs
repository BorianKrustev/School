using System;

namespace _5.DateModifier
{
	class Program
	{
		static void Main(string[] args)
		{
			string first = Console.ReadLine();
			string second = Console.ReadLine();

			DateModifier print = new DateModifier();

			Console.WriteLine($"{print.PrintDif(first, second)}");
		}
	}
}
