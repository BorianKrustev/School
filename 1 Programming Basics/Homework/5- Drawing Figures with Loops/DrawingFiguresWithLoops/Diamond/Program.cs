using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int stars = 0;
            int line = 0;
            int LLine = 0;
            int MLine = 0;
            double RowsLeft = 0;

            if (number % 2 != 0)
            {
                stars = 1;
                line = number - stars;

                Console.WriteLine($"{new string('-', line / 2)}{new string('*', stars)}{new string('-', line / 2)}");

                MLine = 1;
                LLine = number - 3;

                for (int i = 0; i < Math.Ceiling(((double)number - 2) / 2); i++)
                {
                    Console.WriteLine($"{new string ('-', LLine / 2)}*{new string ('-', MLine)}*{new string('-', LLine / 2)}");
                    MLine += 2;
                    LLine -= 2;
                }

                RowsLeft = number - (Math.Ceiling(((double)number - 2) / 2)) - 2;
                LLine = 2;
                MLine = number - 4;

                for (int i = 0; i < RowsLeft; i++)
                {
                    Console.WriteLine($"{new string ('-', LLine / 2)}*{new string ('-', MLine)}*{new string ('-', LLine / 2)}");
                    LLine += 2;
                    MLine -= 2;
                }

                if (number > 1)
                {
                    Console.WriteLine($"{new string('-', line / 2)}{new string('*', stars)}{new string('-', line / 2)}");
                }
            }

            else
            {
                int Oline = number - 2;
                int InsLine = 0;

                for (int i = 0; i < number / 2; i++)
                {
                    Console.WriteLine($"{new string ('-', Oline / 2)}*{new string ('-', InsLine)}*{new string('-', Oline / 2)}");
                    Oline -= 2;
                    InsLine += 2;
                }

                Oline = 2;
                InsLine = number - 4;

                for (int i = 0; i < (number / 2) - 1; i++)
                {
                    Console.WriteLine($"{new string ('-', Oline / 2)}*{new string ('-', InsLine)}*{new string('-', Oline / 2)}");
                    Oline += 2;
                    InsLine -= 2;
                }
            }
        }
    }
}
