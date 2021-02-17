using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousePrice
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal smallRome = decimal.Parse(Console.ReadLine());
            decimal kyhnia = decimal.Parse(Console.ReadLine());
            decimal prise = decimal.Parse(Console.ReadLine());

            decimal bathrome = smallRome / 2;
            decimal rome2 = smallRome + smallRome * 10 / 100;
            decimal rome3 = rome2 + rome2 * 10 / 100;

            decimal allRomes = smallRome + bathrome + kyhnia + rome2 + rome3;
            allRomes += allRomes * 5 / 100;
            prise *= allRomes;

            Console.WriteLine($"{prise:f2}");
        }
    }
}
