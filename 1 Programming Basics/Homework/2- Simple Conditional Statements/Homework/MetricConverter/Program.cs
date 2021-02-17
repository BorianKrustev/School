using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetricConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            string ras1 = Console.ReadLine();
            string ras2 = Console.ReadLine();

            string metersString = "m";
            string milimitersString = "mm";
            string cantemitersString = "cm";
            string milesString = "mi";
            string inchesString = "in";
            string kilomitersString = "km";
            string feetString = "ft";
            string yardsString = "yd";

            double milimiters = 1000;
            double cantimiters = 100;
            double miles = 0.000621371192;
            double inches = 39.3700787;
            double kilomiters = 0.001;
            double feet = 3.2808399;
            double yards = 1.0936133;

            Double numberInMeters = 0;
            if (ras1 == metersString)
            {
                numberInMeters = number;
            }
            else if (ras1 == milimitersString)
            {
                numberInMeters = number / milimiters;                
            }
            else if (ras1 == cantemitersString)
            {
                numberInMeters = number / cantimiters;
            }
            else if (ras1 == milesString)
            {
                numberInMeters = number / miles;
            }
            else if (ras1 == inchesString)
            {
                numberInMeters = number / inches;
            }
            else if (ras1 == kilomitersString)
            {
                numberInMeters = number / kilomiters;
            }
            else if (ras1 == feetString)
            {
                numberInMeters = number / feet;
            }
            else if (ras1 == yardsString)
            {
                numberInMeters = number / yards;
            }



            if (ras2 == metersString)
            {
                numberInMeters = numberInMeters;
            }
            else if (ras2 == milimitersString)
            {
                numberInMeters *= milimiters;
            }
            else if (ras2 == cantemitersString)
            {
                numberInMeters *= cantimiters;
            }
            else if (ras2 == milesString)
            {
                numberInMeters *= miles;
            }
            else if (ras2 == inchesString)
            {
                numberInMeters *= inches;
            }
            else if (ras2 == kilomitersString)
            {
                numberInMeters *= kilomiters;
            }
            else if (ras2 == feetString)
            {
                numberInMeters *= feet;
            }
            else if (ras2 == yardsString)
            {
                numberInMeters *= yards;
            }

            double result = Math.Round(numberInMeters, 8);

            Console.WriteLine($"{result} {ras2}");
        }
    }
}
