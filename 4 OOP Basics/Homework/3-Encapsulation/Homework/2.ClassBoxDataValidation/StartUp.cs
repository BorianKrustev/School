﻿using System;

namespace _2.ClassBoxDataValidation
{
	class StartUp
	{
		static void Main(string[] args)
		{
			double length = double.Parse(Console.ReadLine());
			double width = double.Parse(Console.ReadLine());
			double height = double.Parse(Console.ReadLine());

			try
			{
				Box box = new Box(length, width, height);

				Console.WriteLine($"Surface Area - {box.GetSurfaceArea():f2}");
				Console.WriteLine($"Lateral Surface Area - {box.GetLateralSurfaceArea():f2}");
				Console.WriteLine($"Volume - {box.GetVolume():f2}");
			}
			catch (Exception ex)
			{

				Console.WriteLine(ex.Message);
			}
		}
	}
}