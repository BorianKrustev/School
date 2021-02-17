using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rectangle_Border
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());

            var onLeftSide = (x == x1) && (y >= y1) && (y <= y2);
            var onRightSide = (x == x2) && (y >= y1) && (y <= y2);
            var onUpSide = (y == y1) && (x >= x1) && (x <= x2);
            var onDownSide = (y == y2) && (x >= x1) && (x <= x2);
            if (onLeftSide || onRightSide || onUpSide || onDownSide)
            {
                Console.WriteLine("Border");
            }

            else
            {
                Console.WriteLine("Inside / Outside");
            }
        }
    }
}




//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//
//namespace PointOnRectangleBorder
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//           double x1 = double.Parse(Console.ReadLine());
//           double y1 = double.Parse(Console.ReadLine());
//           double x2 = double.Parse(Console.ReadLine());
//           double y2 = double.Parse(Console.ReadLine());
//          
//           double x = double.Parse(Console.ReadLine());
//           double y = double.Parse(Console.ReadLine());
//          
//           if (y >= y1 && y <= y2)
//           {
//               if (x == x1)
//               {
//                   Console.WriteLine("Border");
//               }
//               else if (x == x2)
//               {
//                   Console.WriteLine("Border");
//               }
//               else
//               {
//                   Console.WriteLine("Inside / Outside");
//               }
//           }
//           else if (x >= x1 && x <= x2)
//           {
//               if (y == y1)
//               {
//                   Console.WriteLine("Border");
//               }
//               else if (y == y2)
//               {
//                   Console.WriteLine("Border");
//               }
//               else
//               {
//                   Console.WriteLine("Inside / Outside");
//               }
//           }
//           else
//           {
//               Console.WriteLine("Inside / Outside");
//           }
//        }
//    }
//}
