using System;

namespace _4.Telephony
{
	public class StartUp
	{
		public static void Main(string[] args)
		{
			string[] numbers = Console.ReadLine().Split();
			string[] urls = Console.ReadLine().Split();

			ICall call = new Smartphone();
			IBrows brows = new Smartphone();

			//Smartphone smartphone = new Smartphone();

			foreach (var item in numbers)
			{
				call.Call(item);
			}

			foreach (var item in urls)
			{
				brows.Brows(item);
			}
		}
	}
}
