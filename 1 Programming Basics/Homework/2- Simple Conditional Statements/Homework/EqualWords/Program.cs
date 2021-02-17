using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualWords
{
    class Program
    {
        static void Main(string[] args)
        {
            String word =  Console.ReadLine();
            String word2 = Console.ReadLine();

            word = word.ToLower();
            word2 = word2.ToLower();

            if (word == word2)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
