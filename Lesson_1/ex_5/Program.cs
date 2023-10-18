using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int rnum = rnd.Next();

            Console.WriteLine("Wa have random number, trie to guess it");
            int num = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("You have 3 trys");

            for (int i = 0; i < 3; i++)
            {
                if (num == rnum)
                {
                    Console.WriteLine("Yesss, yo did it!!");
                }
                else if (num != rnum)
                {
                    Console.WriteLine("Try again");
                }
                else if (i > 3)
                {

                    Console.WriteLine("You LOSE! :(");
                    break;
                }

                Console.ReadKey();
            }
        }
    }
}
