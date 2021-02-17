using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonusScore
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            double bonusP = 0;

            if (number <= 100)
            {
                bonusP += 5;
            }
            else if (number > 1000)
            {
                bonusP = number * 10/100;
            }
            else if (number > 100)
            {
                bonusP = number * 20/100;
            }

            if (number %2 == 0)
            {
                bonusP += 1;
            }
            else if (number %10 == 5)
            {
                bonusP += 2;
            }

            Console.WriteLine(bonusP);
            Console.WriteLine(number + bonusP);
        }
    }
}
