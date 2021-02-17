using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.CompareCharArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr1 = Console.ReadLine()
                            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();
            string[] arr2 = Console.ReadLine()
                            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();

            bool first = false;
            bool second = false;
            for (int i = 0; i < Math.Min(arr1.Length, arr2.Length); i++)
            {
                char arr1Char = char.Parse(arr1[i]);
                char arr2Char = char.Parse(arr2[i]);
                if (arr1Char > arr2Char)
                {
                    first = true;
                    break;
                }
                else if (arr2Char > arr1Char)
                {
                    second = true;
                    break;
                }
            }

            if (first == true)
            {
                Console.WriteLine($"{string.Join("", arr2)}");
                Console.WriteLine($"{string.Join("", arr1)}");
            }
            else if (second == true)
            {
                Console.WriteLine($"{string.Join("", arr1)}");
                Console.WriteLine($"{string.Join("", arr2)}");
            }
            else
            {
                if (arr1.Length < arr2.Length)
                {
                    Console.WriteLine($"{string.Join("", arr1)}");
                    Console.WriteLine($"{string.Join("", arr2)}");
                }
                else
                {
                    Console.WriteLine($"{string.Join("", arr2)}");
                    Console.WriteLine($"{string.Join("", arr1)}");
                }
            }
        }
    }
}
