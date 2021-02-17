using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_Population_Counter
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, Dictionary<string, long>> populationData =
                new Dictionary<string, Dictionary<string, long>>();
            string inputData = Console.ReadLine();
            while (!inputData.Contains("report"))
            {
                string[] tokens = inputData.Split('|');
                string city = tokens[0];
                string country = tokens[1];
                long population = long.Parse(tokens[2]);
                if (!populationData.ContainsKey(country))
                {
                    populationData.Add(country, new Dictionary<string, long>());
                }

                if (!populationData[country].ContainsKey(city))
                {
                    populationData[country].Add(city, population);
                }
                inputData = Console.ReadLine();
            }
            PrintReport(populationData);
        }

        private static void PrintReport(Dictionary<string, Dictionary<string, long>> populationData)
        {
            foreach (var country in populationData.OrderByDescending(x => x.Value.Values.Sum()))
            {
                string countryName = country.Key;
                Console.WriteLine($"{countryName} (total population: {country.Value.Values.Sum()})");

                foreach (var city in country.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"=>{city.Key}: {city.Value}");
                }
            }
        }
    }
}