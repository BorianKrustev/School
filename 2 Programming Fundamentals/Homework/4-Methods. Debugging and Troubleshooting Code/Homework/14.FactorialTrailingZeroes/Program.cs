using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;

namespace _14.FactorialTrailingZeroes
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger number = BigInteger.Parse(Console.ReadLine());

            Console.WriteLine($"{zero(factorial(number))}");
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

        static BigInteger zero(BigInteger number)
        {
            string toString = number.ToString();
            BigInteger count = 0;
            for (int i = toString.Length - 1; i >= 0; i--)
            {
                BigInteger bakToNumber = (BigInteger)char.GetNumericValue(toString[i]);
                if (bakToNumber == 0)
                {
                    count += 1;
                }
                else
                {
                    break;
                }
            }

            return count;
        }
    }
}