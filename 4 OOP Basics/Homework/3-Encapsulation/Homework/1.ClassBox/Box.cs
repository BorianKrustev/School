using System;
using System.Collections.Generic;
using System.Text;

namespace _1.ClassBox
{
	public class Box
	{
		private double length;
		private double width;
		private double height;

		public Box(double length, double width, double height)
		{
			this.Length = length;
			this.Width = width;
			this.Height = height;
		}

		private double Length
		{
			get => this.length;
			set => this.length = value;
		}

		private double Width
		{
			get => this.width;
			set => this.width = value;
		}

		private double Height
		{
			get => this.height;
			set => this.height = value;
		}

		public double GetVolume()
		{
			return this.Length * this.Width * this.Height;
		}

		public double GetLateralSurfaceArea()
		{
			return this.Length * this.Height * 2 + this.Width * this.Height * 2;
		}

		public double GetSurfaceArea()
		{
			return 2 * this.Length * this.Width + 2 * this.Length * this.Height + 2 * this.Width * this.Height;
		}
	}
}
