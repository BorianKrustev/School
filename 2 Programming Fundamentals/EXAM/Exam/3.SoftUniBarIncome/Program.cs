using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _3.SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            string namePatern = "%([A-Z][a-z]+)%";
            string productPatern = "<([A-z]+)>";
            string countPatern = "\\|([0-9]*)\\|";
            string pricePatern = "([0-9]+.[0-9]*)\\$";
            decimal finalMuny = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of shift") break;

                Match name = Regex.Match(input, namePatern);
                Match produckt = Regex.Match(input, productPatern);
                Match count = Regex.Match(input, countPatern);
                Match price = Regex.Match(input, pricePatern);

                if (name.Success && produckt.Success && count.Success && price.Success)
                {
                    string holdCount = count.Groups[1].ToString();
                    string holdPrise = price.Groups[1].ToString();
                    Console.WriteLine($"{name.Groups[1]}: {produckt.Groups[1]} - {decimal.Parse(holdCount) * decimal.Parse(holdPrise):f2}");
                    finalMuny += decimal.Parse(holdCount) * decimal.Parse(holdPrise);
                }
            }

            Console.WriteLine($"Total income: {finalMuny:f2}");
        }
    }
}
