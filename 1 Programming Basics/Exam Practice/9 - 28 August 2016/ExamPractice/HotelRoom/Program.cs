using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            string time = Console.ReadLine();
            decimal spent = decimal.Parse(Console.ReadLine());

            decimal studio = 0m;
            decimal apartament = 0m;

            if (time == "May" || time == "October")
            {
                studio = spent * 50m;
                apartament = spent * 65m;

                if (spent > 14)
                {
                    studio = studio - (studio * 30 / 100);
                    apartament = apartament - (apartament * 10 / 100);
                }
                else if (spent > 7)
                {
                    studio = studio - (studio * 5 / 100);
                }
            }
            else if (time == "June" || time == "September")
            {
                studio = spent * 75.20m;
                apartament = spent * 68.70m;

                if (spent > 14)
                {
                    studio = studio - (studio * 20 / 100);
                    apartament = apartament - (apartament * 10 / 100);
                }
            }
            else
            {
                studio = spent * 76m;
                apartament = spent * 77m;

                if (spent > 14)
                {
                    apartament = apartament - (apartament * 10 / 100);
                }
            }

            Console.WriteLine($"Apartment: {apartament:f2} lv.");
            Console.WriteLine($"Studio: {studio:f2} lv.");
        }
    }
}
