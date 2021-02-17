using System;
using System.Collections.Generic;
using System.Text;

namespace _8.RawData
{
	public class Engine
	{
		private int speed;
		private int power;

		public Engine(int speed, int power)
		{
			this.speed = speed;
			this.power = power;
		}

		public int Speed
		{
			get => this.speed;
			set => this.speed = value;
		}

		public int Power
		{
			get => this.power;
			set => this.power = value;
		}
	}
}
