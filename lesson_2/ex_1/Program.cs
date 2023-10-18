using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex_1
{
    public class Count
    {
        private int value;

        public Count (int initialValue)
        {
            this.value = initialValue;
        }

        public void add (int number)
        {
            this.value += number;
        }

        public void subtract (int number)
        {
            this.value -= number;
        }

        public void printValue()
        {
            Console.WriteLine($"Current value {this.value}");
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Count counter = new Count(25); 

            counter.printValue(); 

            counter.add(5); 
            counter.printValue(); 

            counter.subtract(4); 
            counter.printValue();
        }
    }
}
