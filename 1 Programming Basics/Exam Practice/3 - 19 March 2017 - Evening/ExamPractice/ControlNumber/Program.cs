using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int control = int.Parse(Console.ReadLine());

            int chek = 0;
            int moves = 0;

            for (int i = 1; i <= n; i++)
            {
                for (int f = m; f >= 1; f--)
                {
                    int first = i * 2;
                    int second = f * 3;
                    chek += first + second;
                    moves += 1;

                    if (chek >= control)
                    {
                        break;
                    }
                }

                if (chek >= control)
                {
                    break;
                }
            }

            if (control > chek)
            {
                Console.WriteLine($"{moves} moves");
            }
            else
            {
                Console.WriteLine($"{moves} moves");
                Console.WriteLine($"Score: {chek} >= {control}");
            }
        }
    }
}
