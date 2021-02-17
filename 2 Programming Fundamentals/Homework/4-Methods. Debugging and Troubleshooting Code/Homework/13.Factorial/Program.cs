using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;

namespace _13.Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger number = BigInteger.Parse(Console.ReadLine());
            Console.WriteLine($"{factorial(number)}");
        }

        static BigInteger factorial(BigInteger number)
        {
            BigInteger result = number;
            for (BigInteger i = number - 1; i >= 1; i--)
            {
                result *= i;
            }
            return result;
        }
    }
}
