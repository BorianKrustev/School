using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace App3
{
	class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());
			string[] comandsList = Console.ReadLine().Split().ToArray();

			char[][] field = new char[n][];

			int playerRow = -1;
			int playerCol = -1;
			int colectedCool = 0;
			int coolCount = 0;

			for (int i = 0; i < n; i++)
			{
				field[i] = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();

				for (int f = 0; f < field[i].Length; f++)
				{
					if (field[i][f] == 'c')
					{
						coolCount += 1;
					}
				}

				if (field[i].Contains('s'))
				{
					playerRow = i;
					playerCol = Array.IndexOf(field[i], 's');
				}
			}

			for (int i = 0; i < comandsList.Length; i++)
			{
				int targerRow = -1;
				int targetCol = -1;

				switch (comandsList[i])
				{
					case "left":
						targerRow = playerRow;
						targetCol = playerCol - 1;
						break;
					case "right":
						targerRow = playerRow;
						targetCol = playerCol + 1;
						break;
					case "up":
						targerRow = playerRow - 1;
						targetCol = playerCol;
						break;
					case "down":
						targerRow = playerRow + 1;
						targetCol = playerCol;
						break;
					default:
						break;
				}

				if (IsInside(field, targerRow, targetCol))
				{
					if (field[targerRow][targetCol] == 'e')
					{
						Console.WriteLine($"Game over! ({targerRow}, {targetCol})");
						Environment.Exit(0);
					}
					else if (field[targerRow][targetCol] == 'c')
					{
						colectedCool += 1;

						field[playerRow][playerCol] = '*';
						field[targerRow][targetCol] = 's';
						playerRow = targerRow;
						playerCol = targetCol;

						if (colectedCool == coolCount)
						{
							Console.WriteLine($"You collected all coals! ({playerRow}, {playerCol})");
							Environment.Exit(0);
						}

					}
					else
					{
						field[playerRow][playerCol] = '*';
						field[targerRow][targetCol] = 's';
						playerRow = targerRow;
						playerCol = targetCol;
					}
				}
			}

			Console.WriteLine($"{coolCount - colectedCool} coals left. ({playerRow}, {playerCol})");
		}

		private static bool IsInside(char[][] jaggedArray, int row, int col)
		{
			return row >= 0 && row < jaggedArray.Length && col >= 0 && col < jaggedArray.Length;
		}
	}
}
