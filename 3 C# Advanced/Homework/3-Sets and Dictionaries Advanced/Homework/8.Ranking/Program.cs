using System;
using System.Linq;
using System.Collections.Generic;

namespace _8.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> students = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of contests") break;

                string[] elements = input.Split(":");

                string contestName = elements[0];
                string pasword = elements[1];

                if (!contests.ContainsKey(contestName))
                {
                    contests.Add(contestName, pasword);
                }
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of submissions") break;

                string[] elements = input.Split("=>");

                string contestName = elements[0];
                string pasword = elements[1];
                string userName = elements[2];
                int points = int.Parse(elements[3]);

                if (contests.ContainsKey(contestName) && contests[contestName] == pasword)
                {
                    if (!students.ContainsKey(userName))
                    {
                        students.Add(userName, new Dictionary<string, int>());
                    }

                    if (!students[userName].ContainsKey(contestName))
                    {
                        students[userName].Add(contestName, points);
                    }

                    if (students[userName][contestName] < points)
                    {
                        students[userName][contestName] = points;
                    }
                }
            }

            var topStudent = students.OrderByDescending(x => x.Value.Sum(s => s.Value)).FirstOrDefault();

            Console.WriteLine($"Best candidate is {topStudent.Key} with total {topStudent.Value.Sum(x => x.Value)} points.");

            Console.WriteLine($"Ranking:");

            var sortedStudents = students.OrderBy(x => x.Key);

            foreach (var kvp in sortedStudents)
            {
                Console.WriteLine($"{kvp.Key}");

                foreach (var item in kvp.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {item.Key} -> {item.Value}");
                }
            }
        }
    }
}
