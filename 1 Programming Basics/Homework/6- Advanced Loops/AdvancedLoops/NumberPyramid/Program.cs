using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberPyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int curentNumber = 1;

            for (int i = 1; i <= n; i++)
            {
                for (int f = 1; f <= i; f++)
                {
                    Console.Write($"{curentNumber} ");
                    curentNumber += 1;
                    if (curentNumber > n)
                    {
                        break;
                    }
                }
                Console.WriteLine();
                if (curentNumber > n)
                {
                    break;
                }
            }
        }
    }
}
