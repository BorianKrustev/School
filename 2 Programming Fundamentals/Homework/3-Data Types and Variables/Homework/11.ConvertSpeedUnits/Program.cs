using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace warmuptest
{
    class Program
    {
        static void Main(string[] args)
        {
            float meters = float.Parse(Console.ReadLine());
            float houers = float.Parse(Console.ReadLine());
            float minutes = float.Parse(Console.ReadLine());
            float seconds = float.Parse(Console.ReadLine());

            float timeInSec = ((houers * 60) * 60) + (minutes * 60) + seconds;
            float timeInHour = (timeInSec / 60) / 60;
            float km = meters / 1000;
            km /= timeInHour;
            float miles = meters / 1609;
            miles /= timeInHour;
            meters /= timeInSec;

            Console.WriteLine($"{meters}");
            Console.WriteLine($"{km}");
            Console.WriteLine($"{miles}");
        }
    }
}
