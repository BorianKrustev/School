using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO.Compression;

namespace _7.DirectoryTraversal
{
	class Program
	{
		static void Main(string[] args)
		{
			string[] files = Directory.GetFiles("..//..//..//..//files//",
			"*.*",
			SearchOption.TopDirectoryOnly);

			// Display all the files.
			foreach (string file in files)
			{
				Console.WriteLine(file);
			}
		}
	}
}
