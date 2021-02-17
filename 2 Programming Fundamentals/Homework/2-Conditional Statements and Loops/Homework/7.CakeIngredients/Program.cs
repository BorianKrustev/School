using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.CakeIngredients
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;

            while (true)
            {
                string ingred = Console.ReadLine();

                if (ingred == "Bake!")
                {
                    Console.WriteLine($"Preparing cake with {count} ingredients.");
                    break;
                }

                count++;
                Console.WriteLine($"Adding ingredient {ingred}.");
            }
        }
    }
}
