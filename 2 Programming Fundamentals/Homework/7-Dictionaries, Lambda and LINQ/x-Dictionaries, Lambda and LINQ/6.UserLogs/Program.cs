using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_User_Logs
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, int>> log = new SortedDictionary<string, Dictionary<string, int>>();
            string inputLine = Console.ReadLine();
            while (inputLine != "end")
            {
                var userFromInput = inputLine.Split(new string[] { "user=", " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
                userFromInput.RemoveRange(0, 2);
                string user = userFromInput[0];
                //---------------------------------//
                var ipFromInput = inputLine.Split(new string[] { "IP=", " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
                ipFromInput.RemoveRange(1, 2);
                string ip = ipFromInput[0];

                int message = 1;
                if (!log.ContainsKey(user))
                {
                    log.Add(user, new Dictionary<string, int>());
                }
                if (!log[user].ContainsKey(ip))
                {
                    log[user].Add(ip, message);
                }
                else
                {
                    log[user][ip]++;
                }
                inputLine = Console.ReadLine();
            }
            foreach (var users in log)
            {
                string user = users.Key;
                var ipData = users.Value;
                Console.WriteLine($"{user}:");
                foreach (var ipAddress in ipData)
                {
                    string ip = ipAddress.Key;
                    var sendedMessage = ipAddress.Value;
                    Console.Write(ipAddress.Key != ipData.Keys.Last()
                        ? $"{ip} => {sendedMessage}, "
                        : $"{ip} => {sendedMessage}. ");
                }
                Console.WriteLine();
            }
        }
    }
}