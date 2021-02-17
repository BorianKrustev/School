using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int sum = 0;

            for (int i = 0; i < number; i++)
            {
                int firstNumber = int.Parse(Console.ReadLine());
                sum += firstNumber;
            }
            Console.WriteLine(sum);
        }   
    }
}
