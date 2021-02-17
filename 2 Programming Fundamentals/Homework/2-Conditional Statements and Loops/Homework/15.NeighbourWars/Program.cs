using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.NeighbourWars
{
    class Program
    {
        static void Main(string[] args)
        {
            int peshoD = int.Parse(Console.ReadLine());
            int goshoD = int.Parse(Console.ReadLine());

            int heltGosho = 100;
            int heltPesho = 100;
            int count = 0;
            string winer = "";

            for (int i = 1; i > -1; i++)
            {
                count++;

                if (i % 2 != 0)
                {
                    heltGosho -= peshoD;

                    if (heltGosho <= 0)
                    {
                        winer = "Pesho";
                        break;
                    }

                    Console.WriteLine($"Pesho used Roundhouse kick and reduced Gosho to {heltGosho} health.");
                }
                else
                {
                    heltPesho -= goshoD;

                    if (heltPesho <= 0)
                    {
                        winer = "Gosho";
                        break;
                    }

                    Console.WriteLine($"Gosho used Thunderous fist and reduced Pesho to {heltPesho} health.");
                }

                if (i % 3 == 0)
                {
                    heltGosho += 10;
                    heltPesho += 10;
                }
            }

            Console.WriteLine($"{winer} won in {count}th round.");
        }
    }
}
