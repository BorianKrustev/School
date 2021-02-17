using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxCombination
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int over = int.Parse(Console.ReadLine());

            int check = 1;

            for (int i = start; i <= end; i++)
            {
                for (int f = start; f <= end; f++)
                {
                    Console.Write($"<{i}-{f}>");
                    check += 1;

                    if (check > over)
                    {
                        break;
                    }
                }
                if (check > over)
                {
                    break;
                }
            }
        }
    }
}
