using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.SumReversedNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> numbersInString = Console.ReadLine()
                .Split(' ')
                .ToList();

            List<int> numbers = new List<int>();
            for (int i = 0; i < numbersInString.Count; i++)
            {
                numbers.Add(int.Parse(reversString(numbersInString[i])));
            }

            Console.WriteLine($"{numbers.Sum()}");
        }

        static string reversString (string revers)
        {
            char[] charArr = revers.ToCharArray();
            Array.Reverse(charArr);
            revers = new string(charArr);
            return revers;
        }
    }
}
