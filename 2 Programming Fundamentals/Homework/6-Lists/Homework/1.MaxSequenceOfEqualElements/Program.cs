using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int lengt = 0;
            int bestLenght = 0;
            int element = 0;

            int check = 0;

            for (int i = 0; i < numbers.Count - 1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    lengt++;
                    check++;

                    if (lengt > bestLenght)
                    {
                        bestLenght = lengt;
                        element = numbers[i];
                    }
                }
                else
                {
                    lengt = 0;
                }
            }

            if (check == 0)
            {
                Console.WriteLine($"{numbers[0]}");
            }
            else
            {
                for (int i = 0; i < bestLenght + 1; i++)
                {
                    Console.Write($"{element} ");
                }
            }
        }
    }
}
