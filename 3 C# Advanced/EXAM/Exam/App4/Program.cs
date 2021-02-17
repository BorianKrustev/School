using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace App4
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] holdCups = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
			int[] holdBotels = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

			Stack<int> botels = new Stack<int>();
			List<int> cups = new List<int>();

			for (int i = 0; i < holdCups.Length; i++)
			{
				cups.Add(holdCups[i]);
			}

			for (int i = 0; i < holdBotels.Length; i++)
			{
				botels.Push(holdBotels[i]);
			}

			int waisted = 0;
			int id = 0;

			while (cups.Count > 0 && botels.Count > 0)
			{
				int curentCup = cups[id];
				int curentBotel = botels.Pop();

				if (curentBotel >= curentCup)
				{
					cups.RemoveAt(id);
					waisted += curentBotel - curentCup;
					continue;
				}

				if (curentCup > curentBotel)
				{
					curentCup = curentCup - curentBotel;
					cups[id] = curentCup;
					continue;
				}
			}


			if (cups.Count <= 0)
			{
				Console.WriteLine($"Bottles: {string.Join(" ", botels)}");
				Console.WriteLine($"Wasted litters of water: {waisted}");
			}
			else
			{
				Console.WriteLine($"Cups: {string.Join(" ", cups)}");
				Console.WriteLine($"Wasted litters of water: {waisted}");
			}
		}
	}
}
