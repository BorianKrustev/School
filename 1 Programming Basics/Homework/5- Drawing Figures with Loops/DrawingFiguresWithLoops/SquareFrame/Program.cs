using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareFrame
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Console.Write("+");
            for (int i = 1; i <= number - 2; i++)
            {
                Console.Write(" -");
            }
            Console.WriteLine(" +");


            for (int i = 1; i <= number - 2; i++)
            {
                Console.Write("|");
                for (int f = 1; f <= number - 2; f++)
                {
                    Console.Write(" -");
                }
                Console.WriteLine(" |");
            }


            Console.Write("+");
            for (int i = 1; i <= number - 2; i++)
            {
                Console.Write(" -");
            }
            Console.WriteLine(" +");
        }
    }
}
