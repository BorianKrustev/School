using System;
using System.IO;

namespace _1OddLines
{
	class Program
	{
		static void Main(string[] args)
		{
			using (StreamReader streamWriter = new StreamReader("..//..//..//..//files//text.txt"))
			{
				var line = streamWriter.ReadLine();

				int counter = 0;
				while (line != null)
				{
					if (counter % 2 != 0)
					{
						Console.WriteLine(line);
					}

					counter += 1;
					line = streamWriter.ReadLine();
				}
			}
		}
	}
}