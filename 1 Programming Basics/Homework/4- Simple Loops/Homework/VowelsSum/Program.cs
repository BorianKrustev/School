using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VowelsSum
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            int number = 0;

            for (int i = 0; i < text.Length; i++)
            {
                char simbol = text[i];

                if (simbol == 'a')
                {
                    number += 1;
                }
                else if (simbol == 'e')
                {
                    number += 2;
                }
                else if (simbol == 'i')
                {
                    number += 3;
                }
                else if (simbol == 'o')
                {
                    number += 4;
                }
                else if (simbol == 'u')
                {
                    number += 5;
                }
            }
            Console.WriteLine(number);
        }
    }
}
