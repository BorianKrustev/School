using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.FoldAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int a = arr.Length / 4;
            int[] left = arr.Take(a).ToArray();
            int[] mid = arr.Skip(a).Take(a * 2).ToArray();
            int[] right = arr.Skip(a * 3).ToArray();

            Array.Reverse(left);
            Array.Reverse(right);

            List<int> midAndLeftList = new List<int>();
            midAndLeftList.AddRange(left);
            midAndLeftList.AddRange(right);
            int[] leftAndRigt = midAndLeftList.ToArray();

            int[] arrToPrint = new int[mid.Length];
            for (int i = 0; i < mid.Length; i++)
            {
                arrToPrint[i] = leftAndRigt[i] + mid[i];
            }

            Console.WriteLine($"{string.Join(" ", arrToPrint)}");

            //int[] arr = Console.ReadLine()
            //            .Split(' ')
            //            .Select(int.Parse)
            //            .ToArray();
            //
            //int skip = arr.Length / 4;
            //int[] left = new int[skip];
            //int[] mid = new int[skip * 2];
            //int[] right = new int[skip];
            //
            //for (int i = 0; i < left.Length; i++)
            //{
            //    left[i] = arr[i];
            //}
            //for (int i = skip; i < arr.Length - skip; i++)
            //{
            //    mid[i - skip] = arr[i];
            //}
            //for (int i = arr.Length - 1; i >= skip * 3; i--)
            //{
            //    right[i - skip * 3] = arr[i];
            //}
            //
            //int[] leftAndRigt = new int[skip * 2];
            //
            //Array.Reverse(left);
            //Array.Reverse(right);
            //for (int i = 0; i < left.Length; i++)
            //{
            //    leftAndRigt[i] = left[i];
            //}
            //for (int i = 0; i < right.Length; i++)
            //{
            //    leftAndRigt[i + skip] = right[i];
            //}
            //
            //for (int i = 0; i < mid.Length; i++)
            //{
            //    mid[i] += leftAndRigt[i];
            //}
            //
            //Console.WriteLine($"{string.Join(" ", mid)}");
        }
    }
}
