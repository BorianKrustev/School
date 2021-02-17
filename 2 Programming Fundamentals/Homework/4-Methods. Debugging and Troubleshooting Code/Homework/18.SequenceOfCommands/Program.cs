using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18.SequenceOfCommands
{
    class Program
    {
        static void Main(string[] args)
        {
            int dontNeedIt = int.Parse(Console.ReadLine());

            List<int> numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                string[] comands = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (comands[0] == "stop")
                {
                    break;
                }
                else if (comands[0] == "multiply")
                {
                    numbers[int.Parse(comands[1]) - 1] *= int.Parse(comands[2]);
                }
                else if (comands[0] == "add")
                {
                    numbers[int.Parse(comands[1]) - 1] += int.Parse(comands[2]);
                }
                else if (comands[0] == "subtract")
                {
                    numbers[int.Parse(comands[1]) - 1] -= int.Parse(comands[2]);
                }
                else if (comands[0] == "lshift")
                {
                    int holder = numbers[0];
                    for (int i = 0; i < numbers.Count - 1; i++)
                    {
                        numbers[i] = numbers[i + 1];
                    }
                    numbers[numbers.Count - 1] = holder;
                }
                else if (comands[0] == "rshift")
                {
                    int holder = numbers[numbers.Count - 1];
                    for (int i = numbers.Count - 1; i > 0; i--)
                    {
                        numbers[i] = numbers[i - 1];
                    }
                    numbers[0] = holder;
                }

                for (int i = 0; i < numbers.Count; i++)
                {
                    Console.Write($"{numbers[i]} ");
                    if (i == numbers.Count - 1) Console.WriteLine($"");
                }
            }
        }
    }
}
