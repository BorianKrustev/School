using System;
using TestFactory.Core;

namespace TestFactory
{
	public class StartUp
	{
		public static void Main(string[] args)
		{
			Engine engine = new Engine();
			engine.Run();
		}
	}
}
