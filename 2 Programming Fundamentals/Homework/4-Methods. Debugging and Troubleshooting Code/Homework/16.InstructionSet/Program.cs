using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;

namespace _16.InstructionSet
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string[] codeArgs = Console.ReadLine().Split(' ').ToArray();

                BigInteger result = 0;

                if (codeArgs[0] == "INC")
                {
                    BigInteger operandOne = BigInteger.Parse(codeArgs[1]);
                    result = operandOne + 1;
                }
                else if (codeArgs[0] == "DEC")
                {
                    BigInteger operandOne = BigInteger.Parse(codeArgs[1]);
                    result = operandOne - 1;
                }
                else if (codeArgs[0] == "ADD")
                {
                    BigInteger operandOne = BigInteger.Parse(codeArgs[1]);
                    BigInteger operandTwo = BigInteger.Parse(codeArgs[2]);
                    result = operandOne + operandTwo;
                }
                else if (codeArgs[0] == "MLA")
                {
                    BigInteger operandOne = BigInteger.Parse(codeArgs[1]);
                    BigInteger operandTwo = BigInteger.Parse(codeArgs[2]);
                    result = (BigInteger)(operandOne * operandTwo);
                }
                else if (codeArgs[0] == "END")
                {
                    break;
                }

                Console.WriteLine(result);
            }
        }
    }
}
