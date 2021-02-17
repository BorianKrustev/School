using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _3.WordCount
{
	class Program
	{
		static void Main(string[] args)
		{
			Dictionary<string, int> words = new Dictionary<string, int>();

			string wordsSoursFile = "..//..//..//..//files//words.txt";
			string textSoursFile = "..//..//..//..//files//text.txt";
			string distinationPath = "..//..//..//..//files//result.txt";

			using (StreamReader stremReader = new StreamReader(wordsSoursFile))
			{
				string line = stremReader.ReadLine();

				while (line != null)
				{
					line = line.ToLower();

					if (!words.ContainsKey(line))
					{
						words.Add(line, 0);
					}

					line = stremReader.ReadLine();
				}
			}

			using (StreamReader stremReader = new StreamReader(textSoursFile))
			{
				string line = stremReader.ReadLine();

				while (line != null)
				{
					line = line.ToLower();

					Regex regex = new Regex("[A-Za-z]+");

					foreach (Match item in regex.Matches(line))
					{
						if (words.ContainsKey(item.Value))
						{
							words[item.Value] += 1;
						}
					}

					line = stremReader.ReadLine();
				}
			}

			using (StreamWriter stremWriter = new StreamWriter(distinationPath))
			{
				foreach (var item in words.OrderByDescending(x => x.Value))
				{
					stremWriter.WriteLine($"{item.Key} - {item.Value}");
				}
			}
		}
	}
}
