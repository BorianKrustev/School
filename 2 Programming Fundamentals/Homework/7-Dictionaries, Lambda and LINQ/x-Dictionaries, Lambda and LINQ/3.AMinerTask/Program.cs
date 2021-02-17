using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            string resource = Console.ReadLine();
            Dictionary<string, int> resourceColector = new Dictionary<string, int>();
            while (resource != "stop")
            {
                int resQuantity = int.Parse(Console.ReadLine());
                AddResource(resourceColector, resource, resQuantity);

                resource = Console.ReadLine();
            }

            PrinResult(resourceColector);
        }

        private static void PrinResult(Dictionary<string, int> resourceColector)
        {
            foreach (var names in resourceColector)
            {
                Console.WriteLine($"{names.Key} -> {names.Value}");
            }
        }

        private static void AddResource(Dictionary<string, int> resourceColector, string resource, int resQuantity)
        {
            if (resourceColector.ContainsKey(resource))
            {
                resourceColector[resource] += resQuantity;
            }
            else
            {
                resourceColector.Add(resource, resQuantity);
            }
        }
    }
}