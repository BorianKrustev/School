using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.StringsAndObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            string hello = Console.ReadLine();
            string world = Console.ReadLine();

            string full = hello + " " + world;

            Console.WriteLine($"{full}");
        }
    }
}
