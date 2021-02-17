using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.TseamAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> games = Console.ReadLine().Split(" ").ToList();

            while (true)
            {
                List<string> input = Console.ReadLine().Split(new char[] { ' ', '-' }).ToList();

                if (input[0] == "Play!") break;
                else if (input[0] == "Install")
                {
                    if (games.Contains(input[1])) continue;
                    games.Add(input[1]);
                }
                else if (input[0] == "Uninstall")
                {
                    games.Remove(input[1]);
                }
                else if (input[0] == "Update")
                {
                    if (!games.Contains(input[1])) continue;
                    games.Remove(input[1]);
                    games.Add(input[1]);
                }
                else if (input[0] == "Expansion")
                {
                    if (!games.Contains(input[1])) continue;
                    string hold = string.Join(":", input[1], input[2]);
                    for (int i = 0; i < games.Count; i++)
                    {
                        if (games[i] == input[1])
                        {
                            if (i == games.Count - 1)
                            {
                                games.Add(hold);
                            }
                            else
                            {
                                games.Insert(i + 1, hold);
                            }
                        }
                    }
                }
            }

            Console.WriteLine($"{string.Join(" ", games)}");
        }
    }
}
