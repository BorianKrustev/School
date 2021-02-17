using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputRow = Console.ReadLine();
            var phonebook = new Dictionary<string, string>();
            while (inputRow != "END")
            {
                var command = inputRow.Split().ToArray();

                switch (command[0])
                {
                    case "A": AddEntry(phonebook, command[1], command[2]); break;
                    case "S": SearchEntry(phonebook, command[1]); break;
                }
                inputRow = Console.ReadLine();
            }
        }

        private static void SearchEntry(Dictionary<string, string> phonebook, string name)
        {
            Console.WriteLine(phonebook.ContainsKey(name)
                ? $"{name} -> {phonebook[name]}"
                : $"Contact {name} does not exist.");
        }

        private static void AddEntry(Dictionary<string, string> phonebook, string name, string phone)
        {
            if (!phonebook.ContainsKey(name))
            {
                phonebook.Add(name, phone);
            }
            else
            {
                phonebook[name] = phone;
            }
        }
    }
}