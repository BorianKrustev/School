using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace App3
{
	class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());

			string patern = @"s:([^;]+);r:([^;]+);m--""([A-Za-z ]+)""";
			string wordPatern = @"[A-Za-z ]+";

			List<int> numbers = new List<int>();
			string input = "";

			for (int i = 0; i < n; i++)
			{
				input += Console.ReadLine();
			}

			MatchCollection matches = Regex.Matches(input, patern);

			foreach (Match item in matches)
			{
				string mesig = item.Groups[3].ToString();

				MatchCollection matchSender = Regex.Matches(item.Groups[1].ToString(), wordPatern);
				MatchCollection matchResiver = Regex.Matches(item.Groups[2].ToString(), wordPatern);

				string sender = "";
				foreach (Match send in matchSender)
				{
					sender += send.ToString();
				}

				string resiver = "";
				foreach (Match send in matchResiver)
				{
					resiver += send.ToString();
				}

				Console.WriteLine($"{sender} says \"{mesig}\" to {resiver}");

				MatchCollection numbersSender = Regex.Matches(item.Groups[1].ToString(), "[0-9]");
				MatchCollection numbersResiver = Regex.Matches(item.Groups[2].ToString(), "[0-9]");

				foreach (Match nSend in numbersSender)
				{
					numbers.Add(int.Parse(nSend.ToString()));
				}
				foreach (Match nSend in numbersResiver)
				{
					numbers.Add(int.Parse(nSend.ToString()));
				}
			}

			Console.WriteLine($"Total data transferred: {numbers.Sum()}MB");
		}
	}
}