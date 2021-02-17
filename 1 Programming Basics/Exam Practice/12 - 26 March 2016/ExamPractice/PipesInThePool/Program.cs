using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipesInThePool
{
    class Program
    {
        static void Main(string[] args)
        {
            double pool = double.Parse(Console.ReadLine());
            double pip1 = double.Parse(Console.ReadLine());
            double pip2 = double.Parse(Console.ReadLine());
            double houers = double.Parse(Console.ReadLine());

            pip1 *= houers;
            pip2 *= houers;
            double all = pip1 + pip2;
            double present = all / pool * 100;
            pip1 = pip1 / all * 100;
            pip2 = pip2 / all * 100;

            if (all > pool)
            {
                Console.WriteLine($"For {houers} hours the pool overflows with {all - pool:f1} liters.");
            }
            else
            {
                Console.WriteLine($"The pool is {(int)present}% full. Pipe 1: {(int)pip1}%. Pipe 2: {(int)pip2}%.");
            }
        }
    }
}
