using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LettersCombinations
{
    class Program
    {
        static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());
            char scip = char.Parse(Console.ReadLine());

            int count = 0;

            for (char i = start; i <= end; i++)
            {
                for (char f = start; f <= end; f++)
                {
                    for (char g = start; g <= end; g++)
                    {
                        if (i == scip || f == scip || g == scip)
                        {

                        }
                        else
                        {
                            Console.Write($"{i}{f}{g} ");
                            count += 1;
                        }
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}
