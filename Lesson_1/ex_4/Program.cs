using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number: ");
            double number = Convert.ToDouble(Console.ReadLine());

            double coeff = number * number;

            Console.WriteLine($"The coefficient is: {coeff}");

            Console.ReadKey();
        }
    }
}
