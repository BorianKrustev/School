using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.CubeProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            string properti = Console.ReadLine();

            if (properti == "face")
            {
                face(number);
            }
            else if (properti == "space")
            {
                spase(number);
            }
            else if (properti == "volume")
            {
                volume(number);
            }
            else if (properti == "area")
            {
                area(number);
            }
        }

        public static double face(double s)
        {
            double res = Math.Sqrt(2 * (s * s));
            Console.WriteLine($"{res:f2}");
            return res;
        }

        public static double spase(double s)
        {
            double res = Math.Sqrt(3 * (s * s));
            Console.WriteLine($"{res:f2}");
            return res;
        }

        public static double volume(double s)
        {
            double res = s * s * s;
            Console.WriteLine($"{res:f2}");
            return res;
        }

        public static double area(double s)
        {
            double res = 6 * (s * s);
            Console.WriteLine($"{res:f2}");
            return res;
        }
    }
}
