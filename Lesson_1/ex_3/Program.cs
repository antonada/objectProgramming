using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please chose what appperation you wont do");
            Console.WriteLine("1 - checks the num is valid even or odd");
            Console.WriteLine("2 - print all even numbers from 1 to num on the console");

            Console.WriteLine("Please enter number");
            int num = Convert.ToInt32(Console.ReadLine());

            int opp = Convert.ToInt32(Console.ReadLine());

            if (opp == 1)
            {
                if (num % 2 == 0)
                {
                    Console.WriteLine($"Your number {num} is valid");
                }
                else if (num % 2 != 0)
                {
                    Console.WriteLine($"Your number {num} is not valid");
                }
            }
            else if (opp == 2)
            {
                for (int i = 0; i < num; i++)
                {
                    if (i % 2 == 0)
                    {
                        Console.WriteLine(i);
                    }
                }
            }
            else
            {
                Console.WriteLine("Ooops!!  Try again");
            }

            Console.ReadKey();
        }
    }
}
