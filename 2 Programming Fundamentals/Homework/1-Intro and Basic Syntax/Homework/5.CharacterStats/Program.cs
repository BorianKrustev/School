using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.CharacterStats
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int HCurent = int.Parse(Console.ReadLine());
            int HMax = int.Parse(Console.ReadLine());
            int ECurent = int.Parse(Console.ReadLine());
            int EMax = int.Parse(Console.ReadLine());

            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Health: |{new string ('|', HCurent)}{new string ('.', HMax - HCurent)}|");
            Console.WriteLine($"Energy: |{new string('|', ECurent)}{new string('.', EMax - ECurent)}|");
        }
    }
}
