using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bills
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal munts = decimal.Parse(Console.ReadLine());
            decimal tok = 0m;
            for (int i = 1; i <= munts; i++)
            {
                decimal mTok = decimal.Parse(Console.ReadLine());
                tok += mTok;
            }

            decimal voda = munts * 20m;
            decimal internet = munts * 15m;
            decimal all = tok + voda + internet;
            decimal oters = all + (all * 20 / 100);

            decimal final = (tok + voda + internet + oters) / munts;

            Console.WriteLine($"Electricity: {tok:f2} lv");
            Console.WriteLine($"Water: {voda:f2} lv");
            Console.WriteLine($"Internet: {internet:f2} lv");
            Console.WriteLine($"Other: {oters:f2} lv");
            Console.WriteLine($"Average: {final:f2} lv");
        }
    }
}
