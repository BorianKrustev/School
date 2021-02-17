using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.ReversedChars
{
    class Program
    {
        static void Main(string[] args)
        {
            char a = char.Parse(Console.ReadLine ());
            char b = char.Parse(Console.ReadLine());
            char c = char.Parse(Console.ReadLine());

            string word = c.ToString() + b.ToString() + a.ToString();

            Console.WriteLine($"{word}");
        }
    }
}
