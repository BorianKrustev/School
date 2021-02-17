using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.EmployeeData
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstNmae = Console.ReadLine();
            string lasttNmae = Console.ReadLine();
            byte age = byte.Parse(Console.ReadLine());
            char gender = char.Parse(Console.ReadLine());
            long idNumber = long.Parse(Console.ReadLine());
            long pursanalNumber = long.Parse(Console.ReadLine());

            Console.WriteLine($"First name: {firstNmae}");
            Console.WriteLine($"Last name: {lasttNmae}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"Gender: {gender}");
            Console.WriteLine($"Personal ID: {idNumber}");
            Console.WriteLine($"Unique Employee number: {pursanalNumber}");
        }
    }
}
