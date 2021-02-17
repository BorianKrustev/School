using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupName
{
    class Program
    {
        static void Main(string[] args)
        {
            char A = char.Parse(Console.ReadLine());
            char a = char.Parse(Console.ReadLine());
            char b = char.Parse(Console.ReadLine());
            char c = char.Parse(Console.ReadLine());
            int number = int.Parse(Console.ReadLine());

            int count = -1;

            for (char i = 'A'; i <= A; i++)
            {
                for (char f = 'a'; f <= a; f++)
                {
                    for (char g = 'a'; g <= b; g++)
                    {
                        for (char h = 'a'; h <= c; h++)
                        {
                            for (int j = 0; j <= number; j++)
                            {
                                count += 1;
                            }
                        }
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}
