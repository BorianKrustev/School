using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.SearchForANumber
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();
            int[] comands = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int take = comands[0];
            int delete = comands[1];
            int search = comands[2];

            List<int> takenNumbers = numbers.Take(take).ToList();
            takenNumbers.RemoveRange(0, delete);

            if (takenNumbers.Contains(search))
            {
                Console.WriteLine($"YES!");
            }
            else
            {
                Console.WriteLine($"NO!");
            }
        }
    }
}
