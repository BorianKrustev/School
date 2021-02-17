using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.IndexOfLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] index = new char[26];
            int place = 0;
            for (char i = 'a'; i <= 'z'; i++)
            {
                index[place] = i;
                place += 1;
            }

            string word = Console.ReadLine();

            for (int i = 0; i < word.Length; i++)
            {
                for (int f = 0; f < index.Length; f++)
                {
                    if (word[i] == index[f])
                    {
                        Console.WriteLine($"{word[i]} -> {f}");
                    }
                }
            }
        }
    }
}
