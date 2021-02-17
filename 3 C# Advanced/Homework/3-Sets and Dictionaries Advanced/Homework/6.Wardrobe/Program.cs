using System;
using System.Linq;
using System.Collections.Generic;

namespace _6.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ").ToArray();

                string coler = input[0];
                string[] arr = input[1].Split(",").ToArray();

                if (!wardrobe.ContainsKey(coler))
                {
                    wardrobe.Add(coler, new Dictionary<string, int>());
                }

                for (int f = 0; f < arr.Length; f++)
                {
                    if (!wardrobe[coler].ContainsKey(arr[f]))
                    {
                        wardrobe[coler].Add(arr[f], 1);
                    }
                    else
                    {
                        wardrobe[coler][arr[f]] += 1;
                    }
                }
            }

            string[] lokingFor = Console.ReadLine().Split().ToArray();

            foreach (var item in wardrobe)
            {
                Console.WriteLine($"{item.Key} clothes:");

                foreach (var clothes in item.Value)
                {
                    if (lokingFor[0] == item.Key && lokingFor[1] == clothes.Key)
                    {
                        Console.WriteLine($"* {clothes.Key} - {clothes.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {clothes.Key} - {clothes.Value}");
                    }
                }
            }
        }
    }
}