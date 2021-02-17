using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeComissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            double sell = Double.Parse(Console.ReadLine());

            if (city == "Sofia" || city == "Varna" || city == "Plovdiv" && sell >= 0)
            {
                if (city == "Sofia")
                {
                    if (sell >= 0 && sell <= 500)
                    {
                        Console.WriteLine($"{sell * 5/ 100:f2}");
                    }
                    else if (sell > 500 && sell <= 1000)
                    {
                        Console.WriteLine($"{sell * 7/100:f2}");
                    }
                    else if (sell > 1000 && sell <= 10000)
                    {
                        Console.WriteLine($"{sell * 8/ 100:f2}");
                    }
                    else if (sell > 10000)
                    {
                        Console.WriteLine($"{sell * 12/ 100:f2}");
                    }
                }
                else if (city == "Varna")
                {
                    if (sell >= 0 && sell <= 500)
                    {
                        Console.WriteLine($"{sell * 4.5/ 100:f2}");
                    }
                    else if (sell > 500 && sell <= 1000)
                    {
                        Console.WriteLine($"{sell * 7.5/ 100:f2}");
                    }
                    else if (sell > 1000 && sell <= 10000)
                    {
                        Console.WriteLine($"{sell * 10/ 100:f2}");
                    }
                    else if (sell > 10000)
                    {
                        Console.WriteLine($"{sell * 13/ 100:f2}");
                    }
                }
                else if (city == "Plovdiv")
                {
                    if (sell >= 0 && sell <= 500)
                    {
                        Console.WriteLine($"{sell * 5.5/ 100:f2}");
                    }
                    else if (sell > 500 && sell <= 1000)
                    {
                        Console.WriteLine($"{sell * 8/ 100:f2}");
                    }
                    else if (sell > 1000 && sell <= 10000)
                    {
                        Console.WriteLine($"{sell * 12/ 100:f2}");
                    }
                    else if (sell > 10000)
                    {
                        Console.WriteLine($"{sell * 14.5/ 100:f2}");
                    }
                }
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}
