using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.HelloName
{
    class Program
    {
        static void Main(string[] args)
        {
            printName();
        }

        static void printName ()
        {
            string name = Console.ReadLine();
            Console.WriteLine($"Hello, {name}!");
        }
    }
}
