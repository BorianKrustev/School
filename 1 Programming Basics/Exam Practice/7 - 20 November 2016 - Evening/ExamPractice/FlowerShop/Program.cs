using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal magnoli = decimal.Parse(Console.ReadLine());
            decimal zumbuli = decimal.Parse(Console.ReadLine());
            decimal rozi = decimal.Parse(Console.ReadLine());
            decimal kaktysi = decimal.Parse(Console.ReadLine());
            decimal prise = decimal.Parse(Console.ReadLine());

            magnoli *= 3.25m;
            zumbuli *= 4m;
            rozi *= 3.50m;
            kaktysi *= 8m;

            decimal all = magnoli + zumbuli + rozi + kaktysi;
            all -= all * 5 / 100;

            if (all >= prise)
            {
                Console.WriteLine($"She is left with {Math.Floor(all - prise)} leva.");
            }
            else
            {
                Console.WriteLine($"She will have to borrow {Math.Ceiling(prise - all)} leva.");
            }
        }
    }
}
