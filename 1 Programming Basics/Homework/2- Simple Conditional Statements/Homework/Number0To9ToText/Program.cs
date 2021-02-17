using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number0To9ToText
{
    class Program
    {
        static void Main(string[] args)
        {
            int Number = int.Parse(Console.ReadLine());

            if (Number == 1)
            {
                Console.WriteLine("one");
            }

            else if (Number == 2)
            {
                Console.WriteLine("two");
            }
            else if (Number == 3)
            {
                Console.WriteLine("three");
            }
            else if (Number == 4)
            {
                Console.WriteLine("four");
            }
            else if (Number == 5)
            {
                Console.WriteLine("five");
            }
            else if (Number == 6)
            {
                Console.WriteLine("six");
            }
            else if (Number == 7)
            {
                Console.WriteLine("seven");
            }
            else if (Number == 8)
            {
                Console.WriteLine("eight");
            }
            else if (Number == 9)
            {
                Console.WriteLine("nine");
            }
            else
            {
                Console.WriteLine("number too big");
            }
        }
    }
}
