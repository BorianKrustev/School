using System;
using System.Collections.Generic;
using System.Linq;

public class TruckTour
{
    public static void Main(string[] args)
    {
        long stops = long.Parse(Console.ReadLine());

        Queue<long[]> fullAnDistens = new Queue<long[]>();

        for (long i = 0; i < stops; i++)
        {
            long[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();

            fullAnDistens.Enqueue(input);
        }

        long position = 0;

        while (true)
        {
            long fullRemaining = 0;
            foreach (var item in fullAnDistens)
            {
                fullRemaining += item[0] - item[1];
                if (fullRemaining < 0)
                {
                    position += 1;
                    long[] hold = fullAnDistens.Dequeue();
                    fullAnDistens.Enqueue(hold);
                    break;
                }
            }

            if (fullRemaining >= 0)
            {
                break;
            }
        }

        Console.WriteLine(position);
    }
}