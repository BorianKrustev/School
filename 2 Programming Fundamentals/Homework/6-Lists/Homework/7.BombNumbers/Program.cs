using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int[] comands = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int bomb = comands[0];
            int power = comands[1];

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == bomb)
                {
                    int elementsLeft = Math.Min(power, i);
                    int elementsRight = Math.Min(power, numbers.Count - 1 - i);
                    numbers.RemoveRange(i - elementsLeft, elementsLeft + 1 + elementsRight);
                    i--;
                }
            }

            Console.WriteLine($"{numbers.Sum()}");


            //List<int> nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            //int[] bombInfo = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            //int bomb = bombInfo[0];
            //int power = bombInfo[1];
            //
            //while (nums.Contains(bomb))
            //{
            //    int bombIndex = nums.IndexOf(bomb);
            //    int elementsOnRight = Math.Min(power, nums.Count - 1 - bombIndex);
            //    int elementsOnLeft = Math.Min(bombIndex, power);
            //    int startIndex = Math.Max(bombIndex - power, 0);
            //    nums.RemoveRange(startIndex, elementsOnLeft + 1 + elementsOnRight);
            //}
            //Console.WriteLine(nums.Sum());
        }
    }
}
