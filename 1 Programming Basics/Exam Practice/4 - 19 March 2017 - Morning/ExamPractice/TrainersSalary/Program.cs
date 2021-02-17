using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainersSalary
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal pres = decimal.Parse(Console.ReadLine());
            decimal budget = decimal.Parse(Console.ReadLine());

            decimal pJelev = 0m;
            decimal pRoYaL = 0m;
            decimal pRoli = 0m;
            decimal pTrofon = 0m;
            decimal pSino = 0m;
            decimal pOthers = 0m;

            decimal mony = budget / pres;

            for (int i = 1; i <= pres; i++)
            {
                string name = Console.ReadLine();

                if (name == "Jelev")
                {
                    pJelev += 1m;
                }
                else if (name == "RoYaL")
                {
                    pRoYaL += 1m;
                }
                else if (name == "Roli")
                {
                    pRoli += 1m;
                }
                else if (name == "Trofon")
                {
                    pTrofon += 1m;
                }
                else if (name == "Sino")
                {
                    pSino += 1m;
                }
                else
                {
                    pOthers += 1m;
                }
            }

            Console.WriteLine($"Jelev salary: {mony * pJelev:f2} lv");
            Console.WriteLine($"RoYaL salary: {mony * pRoYaL:f2} lv");
            Console.WriteLine($"Roli salary: {mony * pRoli:f2} lv");
            Console.WriteLine($"Trofon salary: {mony * pTrofon:f2} lv");
            Console.WriteLine($"Sino salary: {mony * pSino:f2} lv");
            Console.WriteLine($"Others salary: {mony * pOthers:f2} lv");
        }
    }
}
