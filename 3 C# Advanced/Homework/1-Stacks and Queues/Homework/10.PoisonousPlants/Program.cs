namespace _11.PoisonousPlants
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<int> plants = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> toRemove = new List<int>();
            int days = 0;

            while (true)
            {
                for (int i = 0; i < plants.Count - 1; i++)
                {
                    if (plants[i] < plants[i + 1])
                    {
                        toRemove.Add(i + 1);
                    }
                }

                if (toRemove.Count == 0) break;

                int check = 0;
                for (int i = 0; i < toRemove.Count; i++)
                {
                    plants.RemoveAt(toRemove[i] - check);
                    check += 1;
                }

                toRemove.Clear();
                days += 1;
            }

            Console.WriteLine(days);
        }
    }
}