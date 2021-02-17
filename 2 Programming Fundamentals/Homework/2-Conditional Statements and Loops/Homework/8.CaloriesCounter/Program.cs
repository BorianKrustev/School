using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.CaloriesCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int calories = 0;

            for (int i = 0; i < number; i++)
            {
                string ingridiant = Console.ReadLine().ToLower();

                if (ingridiant == "cheese")
                {
                    calories += 500;
                }
                else if (ingridiant == "tomato sauce")
                {
                    calories += 150;
                }
                else if (ingridiant == "salami")
                {
                    calories += 600;
                }
                else if (ingridiant == "pepper")
                {
                    calories += 50;
                }
            }

            Console.WriteLine($"Total calories: {calories}");
        }
    }
}
