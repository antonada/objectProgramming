using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("We will convert a temperature, between degrees Celsius and degrees Fahrenheit ");

            Console.WriteLine("Enter a degrees in Celsius");
            int cel = Convert.ToInt32(Console.ReadLine());

            int far = (cel * 9 / 5) + 32;

            Console.WriteLine($"{cel} Celsius in Fahrenheit = {far}");

        }
    }
}
