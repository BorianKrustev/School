using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int bigestNumber = int.MinValue;

            for (int i = 0; i < number; i++)
            {
                int aNumber = int.Parse(Console.ReadLine());
                if (bigestNumber < aNumber)
                {
                    bigestNumber = aNumber;
                }
            }
            Console.WriteLine(bigestNumber);
        }
    }
}
