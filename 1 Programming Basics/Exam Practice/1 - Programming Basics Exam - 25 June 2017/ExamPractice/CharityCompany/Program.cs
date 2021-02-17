using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityCompany
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal dni = decimal.Parse(Console.ReadLine());
            decimal sladkari = decimal.Parse(Console.ReadLine());
            decimal torti =    decimal.Parse(Console.ReadLine());
            decimal gofreti =  decimal.Parse(Console.ReadLine());
            decimal pala4inki = decimal.Parse(Console.ReadLine());

            decimal pTorti = 45m;
            decimal pGofreti = 5.80m;
            decimal pPala4inki = 3.20m;

            torti = sladkari * torti;
            gofreti = gofreti * sladkari;
            pala4inki = pala4inki * sladkari;

            pTorti = torti * pTorti;
            pGofreti = pGofreti * gofreti;
            pPala4inki = pPala4inki * pala4inki;

            decimal oneDay = pTorti + pPala4inki + pGofreti;
            dni = dni * oneDay;
            dni = dni - (dni / 8);

            Console.WriteLine($"{dni:f2}");
        }
    }
}
