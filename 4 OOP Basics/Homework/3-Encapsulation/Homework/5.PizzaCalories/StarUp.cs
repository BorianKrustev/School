using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.PizzaCalories
{
	class StarUp
	{
		static void Main(string[] args)
		{
			Pizza pizza = new Pizza("Hold");

			GetPizza(pizza);

			double result = pizza.GetCaloris();

			Console.WriteLine($"{pizza.Name} - {result:f2} Calories.");
		}

		private static void GetPizza(Pizza pizza)
		{
			while (true)
			{
				string input = Console.ReadLine();

				if (input == "END") break;

				string[] hold = input.Split();

				string comand = hold[0];

				if (comand == "Pizza")
				{
					pizza.Name = hold[1];
				}
				else if (comand == "Dough")
				{
					string curentFlouer = hold[1];
					string curentBaking = hold[2];
					double curentDoughGr = double.Parse(hold[3]);

					Dough holdDough = new Dough(curentFlouer, curentBaking, curentDoughGr);

					pizza.Dough = holdDough;
				}
				else
				{
					string curentType = hold[1];
					double curentGr = double.Parse(hold[2]);

					Topping curentTopping = new Topping(curentType, curentGr);

					pizza.Toppings.Add(curentTopping);

					if (pizza.Toppings.Count > 10)
					{
						Console.WriteLine($"Number of toppings should be in range [0..10].");
						Environment.Exit(0);
					}
				}
			}
		}
	}
}
