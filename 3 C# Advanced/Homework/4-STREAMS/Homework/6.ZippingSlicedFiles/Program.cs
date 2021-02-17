using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO.Compression;

namespace _6.ZippingSlicedFiles
{
	class Program
	{
		static List<string> paths;

		static void Main(string[] args)
		{
			paths = new List<string>();

			string sourseFile = "..//..//..//..//files//sliceMe.mp4";
			string destination = "..//..//..//..//files//assemble.mp4";
			int parts = 4;

			Slice(sourseFile, destination, parts);
			Assemble(paths, destination);
		}


		static void Slice(string sourceFile, string destinatonDirectory, int parts)
		{
			using (FileStream readFile = new FileStream(sourceFile, FileMode.Open))
			{
				long size = readFile.Length / parts + readFile.Length % parts;

				byte[] buffer = new byte[size];

				for (int i = 0; i < parts; i++)
				{
					string disPath = destinatonDirectory + $"Path{i}.mp4";

					paths.Add(disPath);

					using (FileStream writeFile = new FileStream(disPath, FileMode.Create))
					{
						int bytsCount = readFile.Read(buffer, 0, buffer.Length);
						writeFile.Write(buffer, 0, buffer.Length);
					}

					using (GZipStream gz = new GZipStream(new FileStream(disPath + ".gz", FileMode.Create), CompressionMode.Compress, false))
					{
						gz.Write(buffer, 0, buffer.Length);
					}
				}
			}
		}

		static void Assemble(List<string> files, string destinatonDirectory)
		{
			using (FileStream writFile = new FileStream(destinatonDirectory, FileMode.Create))
			{
				byte[] buffer = new byte[1024];

				foreach (var path in files)
				{
					using (FileStream readFile = new FileStream(path, FileMode.Open))
					{
						while (true)
						{
							int bytsCount = readFile.Read(buffer, 0, buffer.Length);

							if (bytsCount == 0)
							{
								break;
							}
							else
							{
								writFile.Write(buffer);
							}
						}
					}
				}
			}
		}
	}
}
