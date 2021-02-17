using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19.TheaThePhotographer
{
    class Program
    {
        static void Main(string[] args)
        {
            double picturs = double.Parse(Console.ReadLine());
            double timeForFilter = double.Parse(Console.ReadLine());
            double presentigGoodPic = double.Parse(Console.ReadLine());
            double timeToUplod = double.Parse(Console.ReadLine());

            double filterTime = picturs * timeForFilter;
            double goodPic = Math.Ceiling(picturs * presentigGoodPic / 100);
            double uplodTime = goodPic * timeToUplod;
            double totalTime = filterTime + uplodTime;

            TimeSpan time = TimeSpan.FromSeconds(totalTime);
            string timeRes = string.Format($"{time.Days:D1}:{time.Hours:D2}:{time.Minutes:D2}:{time.Seconds:D2}");

            Console.WriteLine($"{timeRes}");
        }
    }
}
