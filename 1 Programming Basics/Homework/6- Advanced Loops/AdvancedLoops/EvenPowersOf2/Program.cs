using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenPowersOf2
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int num = 1;

            for (int i = 0; i <= number ; i+=2)
            {
                Console.WriteLine(num);
                num = num * 4;
            }
        }
    }
}
