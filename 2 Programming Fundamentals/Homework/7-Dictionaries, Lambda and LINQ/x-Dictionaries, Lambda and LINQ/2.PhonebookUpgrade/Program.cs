using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_Phonebook_Upgrade
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputRow = Console.ReadLine();
            var phonebook = new SortedDictionary<string, string>();
            while (inputRow != "END")
            {
                var command = inputRow.Split().ToArray();

                switch (command[0])
                {
                    case "A": AddEntry(phonebook, command[1], command[2]); break;
                    case "S": SearchEntry(phonebook, command[1]); break;
                    case "ListAll": ListAll(phonebook); break;
                }
                inputRow = Console.ReadLine();
            }
        }

        private static void ListAll(SortedDictionary<string, string> phonebook)
        {
            foreach (var names in phonebook)
            {
                Console.WriteLine($"{names.Key} -> {names.Value}");
            }
        }

        private static void SearchEntry(SortedDictionary<string, string> phonebook, string name)
        {
            Console.WriteLine(phonebook.ContainsKey(name)
                ? $"{name} -> {phonebook[name]}"
                : $"Contact {name} does not exist.");
        }

        private static void AddEntry(SortedDictionary<string, string> phonebook, string name, string phone)
        {
            if (phonebook.ContainsKey(name))
            {
                phonebook[name] = phone;
            }
            else
            {
                phonebook.Add(name, phone);
            }
        }
    }
}