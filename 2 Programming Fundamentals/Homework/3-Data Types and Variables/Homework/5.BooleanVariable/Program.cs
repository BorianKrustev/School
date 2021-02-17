using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.BooleanVariable
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            if (word == "True")
            {
                Console.WriteLine($"Yes");
            }
            else
            {
                Console.WriteLine($"No");
            }
        }
    }
}
