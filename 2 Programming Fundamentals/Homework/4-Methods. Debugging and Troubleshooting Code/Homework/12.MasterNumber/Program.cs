using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.MasterNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                if (evenDigit(i) == true && sumOfDigit(i) == true && symmertic(i) == true)
                {
                    Console.WriteLine($"{i}");
                }
            }
        }

        static bool evenDigit (int number)
        {
            string toString = number.ToString();
            for (int i = 0; i <= toString.Length - 1; i++)
            {
                int backToInt = (int)char.GetNumericValue(toString[i]);
                if (backToInt % 2 == 0)
                {
                    return true;
                }
            }
            return false;
        }

        static bool sumOfDigit (int number)
        {
            string toString = number.ToString();
            int sum = 0;
            for (int i = 0; i <= toString.Length - 1; i++)
            {
                int backToInt = (int)char.GetNumericValue(toString[i]);
                sum += backToInt;
                if (i == toString.Length - 1 && sum % 7 == 0)
                {
                    return true;
                }
            }
            return false;
        }

        static bool symmertic (int number)
        {
            string toString = number.ToString();
            for (int i = 0; i < toString.Length; i++)
            {
                if (toString[i] != toString[toString.Length - 1 - i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
