using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddEvenSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputNumber = int.Parse(Console.ReadLine());

            int even = 0;
            int odd = 0;

            for (int i = 0; i < inputNumber; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (i % 2==0)
                {
                    even += number;
                }
                else
                {
                    odd += number;
                }
            }
            if (even == odd)
            {
                Console.WriteLine($"Yes Sum = {even}");
            }
            else
            {
                Console.WriteLine($"No Diff = {Math.Abs(even - odd)}");
            }
        }
    }
}
