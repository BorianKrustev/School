using System;
using System.Collections.Generic;

namespace _04_Fix_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            Dictionary<string, string> emailCollector = new Dictionary<string, string>();
            while (name != "stop")
            {
                string emailAddress = Console.ReadLine();
                CollectEmails(emailCollector, name, emailAddress);

                name = Console.ReadLine();
            }

            PrinResult(emailCollector);
        }

        private static void PrinResult(Dictionary<string, string> resourceColector)
        {
            foreach (var names in resourceColector)
            {
                Console.WriteLine($"{names.Key} -> {names.Value}");
            }
        }

        private static void CollectEmails(Dictionary<string, string> emailCollector, string name, string emailAddress)
        {
            if (emailCollector.ContainsKey(name))
            {
                emailCollector[name] = emailAddress;
            }
            else if (!(emailAddress.Contains(".us")) && !(emailAddress.Contains(".uk")))
            {
                emailCollector.Add(name, emailAddress);
            }
        }
    }
}