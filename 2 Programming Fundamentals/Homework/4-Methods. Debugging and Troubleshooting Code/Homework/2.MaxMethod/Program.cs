using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.MaxMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            int bigest = maxNumber(a, b, c);

            Console.WriteLine($"{bigest}");
        }

        static int maxNumber (int a , int b, int c)
        {
            int bigest = 0;
            if (a > b && a > c)
            {
                bigest = a;
            }
            else if (b > a && b > c)
            {
                bigest = b;
            }
            else
            {
                bigest = c;
            }

            return bigest;
        }
    }
}
