using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.MagicLetter
{
    class Program
    {
        static void Main(string[] args)
        {
            char a = char.Parse(Console.ReadLine());
            char b = char.Parse(Console.ReadLine());
            char c = char.Parse(Console.ReadLine());

            for (char i = a; i <= b; i++)
            {
                for (char f = a; f <= b; f++)
                {
                    for (char g = a; g <= b; g++)
                    {
                        if (i == c || f == c || g == c)
                        {

                        }
                        else
                        {
                            Console.Write($"{i}{f}{g} ");
                        }
                    }
                }
            }
        }
    }
}
