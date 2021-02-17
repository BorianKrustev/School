using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                List<string> comands = Console.ReadLine()
                    .Split(' ')
                    .ToList();

                if (comands[0] == "Delete")
                {
                    int delete = int.Parse(comands[1]);
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] == delete)
                        {
                            numbers.RemoveAt(i);
                            i--;
                        }
                    }
                }
                else if (comands[0] == "Insert")
                {
                    int element = int.Parse(comands[1]);
                    int position = int.Parse(comands[2]);
                    numbers.Insert(position, element);
                }
                else if (comands[0] == "Odd")
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] % 2 != 0)
                        {
                            Console.Write($"{numbers[i]} ");
                        }
                    }

                    break;
                }
                else
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] % 2 == 0)
                        {
                            Console.Write($"{numbers[i]} ");
                        }
                    }

                    break;
                }
            }
        }
    }
}
