using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals
{
	public class Tiger : Feline
	{
		public Tiger(string name, double weight, int foodEaten, string livingRegion, string breed) 
			: base(name, weight, foodEaten, livingRegion, breed)
		{
		}

		override public void Sound()
		{
			Console.WriteLine("ROAR!!!");
		}
	}
}
