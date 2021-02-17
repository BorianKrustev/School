using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.MOBAChallenger
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, Dictionary<string, int>> players = new Dictionary<string, Dictionary<string, int>>();

            while (input != "Season end")
            {
                if (input.Contains(" -> "))
                {
                    List<string> list = input.Split(" -> ").ToList();

                    if (!players.ContainsKey(list[0])) players.Add(list[0], new Dictionary<string, int>());
                    if (!players[list[0]].ContainsKey(list[1])) players[list[0]].Add(list[1], 0);
                    if (players[list[0]][list[1]] < int.Parse(list[2])) players[list[0]][list[1]] = int.Parse(list[2]);
                }
                else
                {
                    List<string> vsList = input.Split(" vs ").ToList();
                    if (!players.ContainsKey(vsList[0])) break;
                    if (!players.ContainsKey(vsList[1])) break;

                    bool removePlayer1 = false;
                    bool removePlayer2 = false;
                    int check = 0;

                    foreach (var player1 in players[vsList[0]])
                    {
                        foreach (var player2 in players[vsList[1]])
                        {
                            if (player1.Key == player2.Key)
                            {
                                if (player1.Value > player2.Value)
                                {
                                    removePlayer2 = true;
                                    check += 1;
                                }
                                else if (player2.Value > player1.Value)
                                {
                                    removePlayer1 = true;
                                    check += 1;
                                }
                            }
                            if (check > 0) break;
                        }
                        if (check > 0) break;
                    }

                    if (removePlayer1 == true) players.Remove(vsList[0]);
                    if (removePlayer2 == true) players.Remove(vsList[1]);
                }

                input = Console.ReadLine();
            }

            foreach (var item in players.OrderByDescending(x => x.Value.Values.Sum()))
            {
                Console.WriteLine($"{item.Key}: {item.Value.Values.Sum()} skill");

                foreach (var pos in item.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"- {pos.Key} <::> {pos.Value}");
                }
            }
        }
    }
}
