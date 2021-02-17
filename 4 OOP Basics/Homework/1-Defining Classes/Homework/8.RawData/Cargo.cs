using System;
using System.Collections.Generic;
using System.Text;

namespace _8.RawData
{
	public class Cargo
	{
		public int weight;
		public string type;

		public Cargo(int weight, string type)
		{
			this.weight = weight;
			this.type = type;
		}

		public string Type
		{
			get => this.type;
			set => this.type = value;
		}

		public int Weight
		{
			get => this.weight;
			set => this.weight = value;
		}
	}
}
