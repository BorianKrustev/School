using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.GameOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int magic = int.Parse(Console.ReadLine());

            int chek = 0;
            int a = 0;
            int b = 0;
            int count = 0;

            for (int i = n; i <= m; i++)
            {
                for (int f = n; f <= m; f++)
                {
                    count++;

                    if (i + f == magic)
                    {
                        a = i;
                        b = f;
                        chek++;
                    }
                }
            }

            if (chek > 0)
            {
                Console.WriteLine($"Number found! {a} + {b} = {magic}");
            }
            else
            {
                Console.WriteLine($"{count} combinations - neither equals {magic}");
            }
        }
    }
}
