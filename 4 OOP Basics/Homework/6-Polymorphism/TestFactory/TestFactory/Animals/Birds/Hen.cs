using System;
using System.Collections.Generic;
using System.Text;

namespace TestFactory.Animals.Birds
{
	public class Hen : Bird
	{
		public Hen(string name, double weight, double wingSize) 
			: base(name, weight, wingSize)
		{
		}

		public override void EatFood()
		{
			throw new NotImplementedException();
		}

		public override void ProdusSound()
		{
			throw new NotImplementedException();
		}
	}
}
