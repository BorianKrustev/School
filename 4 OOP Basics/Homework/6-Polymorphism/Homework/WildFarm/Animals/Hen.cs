using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals
{
	public class Hen : Bird
	{
		public Hen(string name, double weight, int foodEaten, double wingSize) 
			: base(name, weight, foodEaten, wingSize)
		{
		}

		override public void Sound()
		{
			Console.WriteLine("Cluck");
		}
	}
}
