using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitOrVegetable
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            string banana = "banana";
            string apple = "apple";
            string kiwi = "kiwi";
            string cherry = "cherry";
            string lemon = "lemon";
            string grapes = "grapes";

            string tomato = "tomato";
            string cucumber = "cucumber";
            string pepper = "pepper";
            string carrot = "carrot";

            if (name == banana || name == apple || name == kiwi || name == cherry || name == lemon || name == grapes)
            {
                Console.WriteLine("fruit");
            }
            else if (name == tomato || name == cucumber || name == pepper || name == carrot)
            {
                Console.WriteLine("vegetable");
            }
            else
            {
                Console.WriteLine("unknown");
            }
        }
    }
}
