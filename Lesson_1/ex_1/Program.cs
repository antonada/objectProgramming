using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter number");

            int num = Convert.ToInt32(Console.ReadLine());

            if (num % 2 == 0)
            {
                Console.WriteLine($"Your number {num} is valid");
            }
            else if (num % 2 != 0)
            {
                Console.WriteLine($"Your number {num} is not valid");
            }

            Console.ReadKey();
        }
    }
}
