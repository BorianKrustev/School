using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoNumbersSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int magick = int.Parse(Console.ReadLine());

            int count = 0;
            int check = 0;
            int over = 0;
            int ii = 0;
            int ff = 0;

            for (int i = start; i >= end; i--)
            {
                for (int f = start; f >= end; f--)
                {
                    count += 1;
                    ii = i;
                    ff = f;
                    check = i + f;
                    if (check == magick)
                    {
                        over += 1;
                        break;
                    }
                }
                if (check == magick)
                {
                    break;
                }
            }

            if (over > 0)
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
