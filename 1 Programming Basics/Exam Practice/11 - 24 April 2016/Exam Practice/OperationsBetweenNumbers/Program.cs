using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationsBetweenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double n1 = double.Parse(Console.ReadLine());
            double n2 = double.Parse(Console.ReadLine());
            string tipe = Console.ReadLine();

            double resolt = 0;
            int check = 0;

            if (n2 == 0 && tipe == "/")
            {
                Console.WriteLine($"Cannot divide {n1} by zero");
                check += 1;
            }
            if (n2 == 0 && tipe == "%")
            {
                Console.WriteLine($"Cannot divide {n1} by zero");
                check += 1;
            }
            else if (tipe == "+")
            {
                resolt = n1 + n2;
            }
            else if (tipe == "-")
            {
                resolt = n1 - n2;
            }
            else if (tipe == "*")
            {
                resolt = n1 * n2;
            }
            else if (tipe == "/")
            {
                resolt = n1 / n2;
            }
            else if (tipe == "%")
            {
                resolt = n1 % n2;
            }

            if (tipe == "+" && resolt % 2 == 0)
            {
                Console.WriteLine($"{n1} {tipe} {n2} = {resolt} - even");
            }
            else if (tipe == "-" && resolt % 2 == 0)
            {
                Console.WriteLine($"{n1} {tipe} {n2} = {resolt} - even");
            }
            else if (tipe == "*" && resolt % 2 == 0)
            {
                Console.WriteLine($"{n1} {tipe} {n2} = {resolt} - even");
            }
            else if (tipe == "+" && resolt % 2 != 0)
            {
                Console.WriteLine($"{n1} {tipe} {n2} = {resolt} - odd");
            }
            else if (tipe == "-" && resolt % 2 != 0)
            {
                Console.WriteLine($"{n1} {tipe} {n2} = {resolt} - odd");
            }
            else if (tipe == "*" && resolt % 2 != 0)
            {
                Console.WriteLine($"{n1} {tipe} {n2} = {resolt} - odd");
            }
            else if (tipe == "/" && check == 0)
            {
                Console.WriteLine($"{n1} {tipe} {n2} = {resolt}");
            }
            else if (tipe == "%" && check == 0)
            {
                Console.WriteLine($"{n1} {tipe} {n2} = {resolt}");
            }
        }
    }
}
