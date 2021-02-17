using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.VowelOrDigit
{
    class Program
    {
        static void Main(string[] args)
        {
            char simbol = char.Parse(Console.ReadLine());

            if (simbol == 'a' || simbol == 'e' || simbol == 'o' || simbol == 'u' || simbol == 'i')
            {
                Console.WriteLine($"vowel");
            }
            else if (char.IsNumber(simbol))
            {
                Console.WriteLine($"digit");
            }
            else
            {
                Console.WriteLine($"other");
            }
        }
    }
}
