using System;
using System.Collections.Generic;
using System.Text;

namespace TestFactory.Animals.Birds
{
	public class Owl : Bird
	{
		public Owl(string name, double weight, double wingSize) 
			: base(name, weight, wingSize)
		{
		}

		public override void ProdusSound()
		{
			throw new NotImplementedException();
		}

		public override void EatFood()
		{
			throw new NotImplementedException();
		}
	}
}
