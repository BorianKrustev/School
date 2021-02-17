using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalfSumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberToDo = int.Parse(Console.ReadLine());

            int bigestNumber = 0;
            int totalSum = 0;
            int sum = 0;

            for (int i = 0; i < numberToDo; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number > bigestNumber)
                {
                    bigestNumber = number;
                }

                totalSum += number;
            }

            sum = totalSum - bigestNumber;
            if (sum == bigestNumber)
            {
                Console.WriteLine($"Yes sum = {Math.Abs(sum)}");
            }
            else
            {
                Console.WriteLine($"No Diff = {Math.Abs(sum - bigestNumber)}");
            }
        }
    }
}
