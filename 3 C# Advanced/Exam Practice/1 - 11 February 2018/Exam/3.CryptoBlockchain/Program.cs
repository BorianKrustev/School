using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _3.CryptoBlockchain
{
    class Program
    {
        static void Main(string[] args)
        {
			string patern = @"{[^{}\[\]]+}|\[[^{}\[\]]+\]";

			string input = "";

			int n = int.Parse(Console.ReadLine());
			for (int i = 0; i < n; i++)
			{
				input += Console.ReadLine();
			}

			MatchCollection fulMatch = Regex.Matches(input, patern);

			List<string> fulMachesList = new List<string>();
			patern = @"[\d+]";
			List<string> stringNum = new List<string>();

			foreach (var item in fulMatch)
			{
				MatchCollection hold = Regex.Matches(item.ToString(), patern);
				string holdStringNum = "";

				foreach (var nGrup in hold)
				{
					holdStringNum += nGrup.ToString();
				}

				if (holdStringNum.Length % 3 == 0 && holdStringNum != "")
				{
					fulMachesList.Add(item.ToString());
					stringNum.Add(holdStringNum);
				}
			}

			for (int i = 0; i < fulMachesList.Count; i++)
			{
				while (stringNum[i].Length != 0)
				{
					int count = 0;
					string hold = "";

					for (int f = 0; f < stringNum[i].Length; f++)
					{
						hold += stringNum[i][f];
						count += 1;
						if (count == 3) break;
					}

					int curentNumber = int.Parse(hold);
					Console.Write($"{(char)(curentNumber - fulMachesList[i].Length)}");

					stringNum[i] = stringNum[i].Remove(0, 3);
				}
			}


			//List<char> numbers = new List<char>();
			//for (char i = '0'; i <= '9'; i++)
			//{
			//	numbers.Add(i);
			//}
			//
			//for (int i = 0; i < fulMachesList.Count; i++)
			//{
			//	int count = 0;
			//
			//	char[] hold = fulMachesList[i].ToCharArray();
			//	for (int f = 0; f < hold.Length; f++)
			//	{
			//		for (int g = 0; g < numbers.Count; g++)
			//		{
			//			if (hold[f] == (numbers[g]))
			//			{
			//				count += 1;
			//			}
			//		}
			//	}
			//
			//	if (count % 3 == 0 && count > 0) ;
			//	else
			//	{
			//		fulMachesList.RemoveAt(i);
			//		i -= 1;
			//	}
			//}
		}
    }
}
