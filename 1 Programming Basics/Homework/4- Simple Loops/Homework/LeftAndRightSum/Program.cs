using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeftAndRightSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputNumber = int.Parse(Console.ReadLine());

            int left = 0;
            int right = 0;

            for (int i = 0; i < inputNumber; i++)
            {
                int number = int.Parse(Console.ReadLine());
                left += number;
            }

            for (int i = 0; i < inputNumber; i++)
            {
                int number = int.Parse(Console.ReadLine());
                right += number;
            }

            if (left == right)
            {
                Console.WriteLine($"Yes, sum = {left}");
            }
            else
            {
                Console.WriteLine($"No, diff = {Math.Abs(left - right)}");
            }
        }
    }
}
