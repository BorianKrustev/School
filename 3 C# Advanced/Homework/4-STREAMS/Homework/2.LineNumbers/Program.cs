using System;
using System.IO;

namespace _2.LineNumbers
{
	class Program
	{
		static void Main(string[] args)
		{
			string soursFile = "..//..//..//..//files//text.txt";
			string distination = "..//..//..//..//files//output.txt";

			using (StreamReader stremReader = new StreamReader(soursFile))
			{
				using (StreamWriter streamWriter = new StreamWriter(distination))
				{
					string line = stremReader.ReadLine();

					int counter = 1;
					while (line != null)
					{
						streamWriter.WriteLine($"Line {counter}:{line}");

						counter += 1;
						line = stremReader.ReadLine();
					}
				}
			}
		}
	}
}
