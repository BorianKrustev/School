using System;
using System.Linq;
using System.Collections.Generic;

namespace _7.BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] openP = { '(', '{', '[' };
            char[] closP = { ')', '}', ']' };

            char[] input = Console.ReadLine().ToCharArray();
            Stack<char> history = new Stack<char>();
            bool isBalast = true;

            foreach (var item in input)
            {
                if (openP.Contains(item))
                {
                    history.Push(item);
                    continue;
                }

                if (closP.Contains(item))
                {
                    if (history.Count == 0)
                    {
                        isBalast = false;
                        break;
                    }

                    char opensWith = history.Pop();

                    if (!checkBalans(opensWith, item))
                    {
                        isBalast = false;
                        break;
                    }
                }
            }

            Console.WriteLine(isBalast ? "YES" : "NO");
        }

        static bool checkBalans (char opensWith, char clostWitch)
        {
            switch (opensWith)
            {
                case '(':
                    return clostWitch == ')' ? true : false;
                case '{':
                    return clostWitch == '}' ? true : false;
                case '[':
                    return clostWitch == ']' ? true : false;
                default:
                    return false;
            }
        }
    }
}
