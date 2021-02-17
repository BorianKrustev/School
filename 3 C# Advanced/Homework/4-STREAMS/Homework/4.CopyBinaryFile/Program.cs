using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _4.CopyBinaryFile
{
	class Program
	{
		static void Main(string[] args)
		{
			string sourseFile = "..//..//..//..//files//copyMe.png";
			string distinationPath = "..//..//..//..//files//copyMe-copy.png";

			using (FileStream readFile = new FileStream(sourseFile, FileMode.Open))
			{
				var size = readFile.Length;

				byte[] buffer = new byte[size];

				readFile.Read(buffer, 0, buffer.Length);

				using (FileStream writeFile = new FileStream(distinationPath, FileMode.Create))
				{
					writeFile.Write(buffer, 0, buffer.Length);
				}
			}
		}
	}
}
