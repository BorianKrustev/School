using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace drawFort
{
    class Program
    {
        static void Main(string[] args)
        {
            int M = int.Parse(Console.ReadLine());
            int N = int.Parse(Console.ReadLine());
            int L = int.Parse(Console.ReadLine());
            int spesal = int.Parse(Console.ReadLine());
            int control = int.Parse(Console.ReadLine());

            int check = 0;
            for (int i = M; i >= 1; i--)
            {
                for (int f = N; f >= 1; f--)
                {
                    for (int g = L; g >= 1; g--)
                    {
                        int number = i * 100 + f * 10 + g;

                        if (number % 3 == 0)
                        {
                            spesal += 5;
                        }
                        else if (g == 5)
                        {
                            spesal -= 2;
                        }
                        else if (number % 2 == 0)
                        {
                            spesal *= 2;
                        }

                        if (spesal >= control)
                        {
                            check += 1;
                            break;
                        }
                    }
                    if (spesal >= control)
                    {
                        break;
                    }
                }
                if (spesal >= control)
                {
                    break;
                }
            }

            if (check > 0)
            {
                Console.WriteLine($"Yes! Control number was reached! Current special number is {spesal}.");
            }
            else
            {
                Console.WriteLine($"No! {spesal} is the last reached special number.");
            }
        }
    }
}