using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals.Contracts
{
	public interface IAnimal
	{
		string Name { get; set; }
		double Weight { get; set; }
		int FoodEaten { get; set; }

		void Sound();
	}
}
