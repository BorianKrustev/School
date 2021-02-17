using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOfTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int magick = int.Parse(Console.ReadLine());

            int count = 0;
            int ii = 0;
            int ff = 0;
            int check = 0;

            for (int i = start; i <= end; i++)
            {
                for (int f = start; f <= end; f++)
                {
                    count += 1;
                    ii = i;
                    ff = f;
                    if (ii + ff == magick)
                    {
                        check += 1;
                        break;
                    }

                }

                if (ii + ff == magick)
                {
                    break;
                }
            }

            if (check > 0)
            {
                Console.WriteLine($"Combination N:{count} ({ii} + {ff} = {magick})");
            }
            else
            {
                Console.WriteLine($"{count} combinations - neither equals {magick}");
            }
        }
    }
}
