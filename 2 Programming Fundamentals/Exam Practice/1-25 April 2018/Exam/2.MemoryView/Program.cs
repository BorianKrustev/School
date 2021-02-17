using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.MemoryView
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<string> list = new List<string>();
            List<string> wordInInt = new List<string>();
            int toDo = 0;

            while (input != "Visual Studio crash")
            {
                list.AddRange(input.Split(" ").ToList());
                input = Console.ReadLine();
            }

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == "32656" && list[i + 1] == "19759" && list[i + 2] == "32763" && list[i + 3] == "0" && list[i + 5] == "0")
                {
                    toDo = int.Parse(list[i + 4]);
                    for (int f = i + 6; f < i + 6 + toDo; f++)
                    {
                        wordInInt.Add(list[f]);
                    }

                    i += 6 + toDo;

                    for (int g = 0; g < wordInInt.Count; g++)
                    {
                        Console.Write($"{(char)int.Parse(wordInInt[g])}");
                    }
                    Console.WriteLine($"");

                    wordInInt.Clear();
                }
            }
        }
    }
}
