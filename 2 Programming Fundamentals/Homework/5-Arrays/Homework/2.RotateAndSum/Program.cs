using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.RotateAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rotatins = int.Parse(Console.ReadLine());

            List<int> sum = new List<int>(arr);
            for (int i = 0; i < sum.Count; i++)
            {
                sum[i] = 0;
            }

            for (int i = 0; i < rotatins; i++)
            {
                int hold = arr[arr.Length - 1];
                for (int f = arr.Length - 1; f >= 1; f--)
                {
                    arr[f] = arr[f - 1];
                }
                arr[0] = hold;

                for (int g = 0; g < arr.Length; g++)
                {
                    sum[g] += arr[g];
                }
            }

            Console.WriteLine($"{string.Join(" ", sum)}");
        }
    }
}
