using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, int>> examResults = new SortedDictionary<string, Dictionary<string, int>>();
            SortedDictionary<string, int> langugCount = new SortedDictionary<string, int>();

            while (true)
            {
                string[] input = Console.ReadLine().Split('-').ToArray();
                if (input[0] == "exam finished") break;

                if (input[1] == "banned")
                {
                    examResults.Remove(input[0]);
                }
                else
                {
                    if (!examResults.ContainsKey(input[0]))
                    {
                        examResults.Add(input[0], new Dictionary<string, int>());
                    }

                    if (!examResults[input[0]].ContainsKey(input[1]))
                    {
                        examResults[input[0]].Add(input[1], 0);
                    }

                    if (!langugCount.ContainsKey(input[1]))
                    {
                        langugCount.Add(input[1], 0);
                    }

                    langugCount[input[1]] += 1;

                    if (int.Parse(input[2]) > examResults[input[0]][input[1]])
                    {
                        examResults[input[0]][input[1]] = int.Parse(input[2]);
                    }
                }
            }

            Console.WriteLine($"Results:");
            foreach (var item in examResults.OrderByDescending(x => x.Value.Values.Sum()))
            {
                Console.WriteLine($"{item.Key} | {item.Value.Values.Sum()}");
            }

            Console.WriteLine($"Submissions:");
            foreach (var item in langugCount.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
    }
}
