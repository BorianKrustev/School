using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;

namespace _18.DifferentIntegersSize
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();

            string print = "";

            try
            {
                sbyte.Parse(number);
                print += "* sbyte" + Environment.NewLine;
            }
            catch (Exception)
            {
            }
            try
            {
                byte.Parse(number);
                print += "* byte" + Environment.NewLine;
            }
            catch (Exception)
            {
            }
            try
            {
                short.Parse(number);
                print += "* short" + Environment.NewLine;
            }
            catch (Exception)
            {
            }
            try
            {
                ushort.Parse(number);
                print += "* ushort" + Environment.NewLine;
            }
            catch (Exception)
            {
            }
            try
            {
                int.Parse(number);
                print += "* int" + Environment.NewLine;
            }
            catch (Exception)
            {
            }
            try
            {
                uint.Parse(number);
                print += "* uint" + Environment.NewLine;
            }
            catch (Exception)
            {
            }
            try
            {
                long.Parse(number);
                print += "* long";
            }
            catch (Exception)
            {
            }

            if (print.Length == 0)
            {
                Console.WriteLine($"{number} can't fit in any type");
            }
            else
            {
                Console.WriteLine($"{number} can fit in:");
                Console.WriteLine($"{print}");
            }
        }
    }
}
