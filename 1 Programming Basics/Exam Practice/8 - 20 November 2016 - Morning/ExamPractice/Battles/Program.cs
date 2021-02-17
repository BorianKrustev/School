using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battles
{
    class Program
    {
        static void Main(string[] args)
        {
            int star = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int over = int.Parse(Console.ReadLine());

            int check = 0;

            for (int i = 1; i <= star; i++)
            {
                for (int f = 1; f <= end; f++)
                {
                    Console.Write($"({i} <-> {f}) ");
                    check += 1;

                    if (check >= over)
                    {
                        break;
                    }
                }
                if (check >= over)
                {
                    break;
                }
            }
        }
    }
}
