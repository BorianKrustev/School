using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.SoftUniCoursePlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> schedule = Console.ReadLine().Split(", ").ToList();

            while (true)
            {
                string hold = Console.ReadLine();
                if (hold == "course start") break;

                List<string> input = hold.Split(":").ToList();

                if (input[0] == "Add")
                {
                    if (schedule.Contains(input[1])) continue;
                    schedule.Add(input[1]);
                }
                else if (input[0] == "Insert")
                {
                    if (schedule.Contains(input[1])) continue;
                    if (int.Parse(input[2]) > schedule.Count - 1 && int.Parse(input[2]) < 0) continue;

                    schedule.Insert(int.Parse(input[2]), input[1]);
                }
                else if (input[0] == "Remove")
                {
                    for (int i = 0; i < schedule.Count; i++)
                    {
                        if (schedule[i] == input[1])
                        {
                            if (schedule[i + 1].StartsWith(input[1]))
                            {
                                schedule.RemoveAt(i + 1);
                                i--;
                            }

                            schedule.RemoveAt(i);
                            i--;
                        }
                    }
                }
                else if (input[0] == "Swap")
                {
                    string leson1 = input[1];
                    string leson2 = input[2];

                    if (!schedule.Contains(leson1) || !schedule.Contains(leson2)) continue;

                    int index1 = -1;
                    int index2 = -1;

                    for (int i = 0; i < schedule.Count; i++)
                    {
                        if (schedule[i] == leson1)
                        {
                            index1 = i;
                        }
                        if (schedule[i] == leson2)
                        {
                            index2 = i;
                        }
                    }

                    if (index1 > index2)
                    {
                        schedule[index2] = leson2;
                        schedule[index1] = leson1;
                    }
                    else
                    {
                        schedule[index1] = leson2;
                        schedule[index2] = leson1;
                    }
                }
                else if (input[0] == "Exercise")
                {
                    string temp = input[1] + ":" + input[0];
                    if (!schedule.Contains(input[1]))
                    {
                        schedule.Add(input[1]);
                        schedule.Add(temp);
                    }
                    else
                    {
                        for (int i = 0; i < schedule.Count; i++)
                        {
                            if (schedule[i] == input[1])
                            {
                                string temp2 = input[1] + "-" + input[0];
                                schedule.Insert(i + 1, temp2);
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < schedule.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{schedule[i]}");
            }
        }
    }
}