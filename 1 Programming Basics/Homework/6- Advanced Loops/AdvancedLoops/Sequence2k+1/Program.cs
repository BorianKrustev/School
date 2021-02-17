using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequence2k_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int num = 1;

            for (int i = 1; i <= number; i++)
            {
                while (num <= number)
                {
                    Console.WriteLine(num);
                    num = (num * 2) + 1;
                }
            }
        }
    }
}
