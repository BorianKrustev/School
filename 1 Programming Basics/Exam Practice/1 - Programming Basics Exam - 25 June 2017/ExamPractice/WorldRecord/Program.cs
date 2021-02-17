using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double meters = double.Parse(Console.ReadLine());
            double timeMeter = double.Parse(Console.ReadLine());

            int timeSlold = (int)meters / 15;
            double slold = timeSlold * 12.5;

            double time = timeMeter * meters + slold;

            if (time < record)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {time:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {time - record:f2} seconds slower.");
            }
        }
    }
}
