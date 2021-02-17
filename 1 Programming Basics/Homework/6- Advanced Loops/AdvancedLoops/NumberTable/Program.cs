using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                for (int f = 0; f < n; f++)
                {
                    int num = i + f + 1;
                    if (num > n)
                    {
                        num = 2 * n - num;
                    }
                    Console.Write($"{num} ");
                }
                Console.WriteLine();
            }
        }
    }
}
