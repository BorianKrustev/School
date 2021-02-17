using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine().Split().Select(long.Parse).ToList();
            string command;
            while ((command = Console.ReadLine()) != "print")
            {
                var split = command.Split();
                switch (split[0])
                {
                    case "add":
                        {
                            var n = int.Parse(split[1]);
                            list.Insert(n, int.Parse(split[2]));
                            break;
                        }
                    case "addMany":
                        {
                            var n = int.Parse(split[1]);
                            list.InsertRange(n, split.Skip(2).Select(long.Parse).ToArray());
                            break;
                        }
                    case "contains":
                        {
                            var n = int.Parse(split[1]);
                            long index = -1;
                            for (int i = 0; i < list.Count; i++)
                            {
                                if (list[i] != n) continue;
                                index = i;
                                break;
                            }
                            Console.WriteLine(index);
                            break;
                        }
                    case "remove":
                        {
                            var n = int.Parse(split[1]);
                            list.RemoveAt(n);
                            break;
                        }
                    case "shift":
                        {
                            var n = int.Parse(split[1]);
                            var arr = new long[list.Count];
                            for (int index = 0; index < list.Count; index++)
                            {
                                int targetIndex = index - n;
                                while (targetIndex > arr.Length)
                                    targetIndex -= arr.Length;
                                while (targetIndex < 0)
                                    targetIndex += arr.Length;
                                arr[targetIndex] = list[index];
                            }
                            list = arr.ToList();
                            break;
                        }
                    case "sumPairs":
                        var newList = new List<long>();
                        for (int i = 1; i < list.Count; i += 2)
                        {
                            if (i % 2 == 0) continue;
                            newList.Add(list[i] + list[i - 1]);
                        }
                        if (list.Count % 2 != 0)
                        {
                            newList.Add(list[list.Count - 1]);
                        }
                        list = newList;
                        break;
                }
            }
            Console.WriteLine("[" + string.Join(", ", list) + "]");
        }


        //static void Main(string[] args)
        //{
        //    List<long> numbers = Console.ReadLine()
        //        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
        //        .Select(long.Parse)
        //        .ToList();
        //
        //    string input = "";
        //    while ((input = Console.ReadLine()) != "print")
        //    {
        //        List<string> comands = input.Split(' ').ToList();
        //
        //        if (comands[0] == "add") Add(numbers, comands);
        //        else if (comands[0] == "addMany") AddMany(numbers, comands);
        //        else if (comands[0] == "contains") Contains(numbers, comands);
        //        else if (comands[0] == "remove") Remove(numbers, comands);
        //        else if (comands[0] == "shift") Shift(numbers, comands);
        //        else if (comands[0] == "sumPairs") SumPairs(numbers, comands);
        //    }
        //
        //    Console.WriteLine($"[{string.Join(", ", numbers)}]");
        //}
        //
        //static void Add (List<long> numbers, List<string> comands)
        //{
        //    numbers.Insert(int.Parse(comands[1]), long.Parse(comands[2]));
        //}
        //
        //static void AddMany (List<long> numbers, List<string> comands)
        //{
        //    numbers.InsertRange(int.Parse(comands[1]), comands.Skip(2).Select(long.Parse).ToList());
        //}
        //
        //static void Contains (List<long> numbers, List<string> comands)
        //{
        //    bool check = true;
        //    for (int i = 0; i < numbers.Count; i++)
        //    {
        //        if (numbers[i] == long.Parse(comands[1]))
        //        {
        //            check = false;
        //            Console.WriteLine($"{i}");
        //            break;
        //        }
        //    }
        //    if (check == true) Console.WriteLine($"-1");
        //}
        //
        //static void Remove (List<long> numbers, List<string> comands)
        //{
        //    numbers.RemoveAt(int.Parse(comands[1]));
        //}
        //
        //static void Shift (List<long> numbers, List<string> comands)
        //{
        //    for (int i = 1; i <= int.Parse(comands[1]); i++)
        //    {
        //        long hold = numbers[0];
        //        for (int f = 0; f < numbers.Count - 1; f++)
        //        {
        //            numbers[f] = numbers[f + 1];
        //        }
        //        numbers[numbers.Count - 1] = hold;
        //    }
        //}
        //
        //static void SumPairs (List<long> numbers, List<string> comands)
        //{
        //    long hold = numbers[numbers.Count - 1];
        //    int stop = numbers.Count / 2;
        //    for (int i = 0; i < stop; i++)
        //    {
        //        numbers[i] = numbers[i] + numbers[i + 1];
        //        numbers.RemoveAt(i + 1);
        //    }
        //}
    }
}