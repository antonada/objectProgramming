using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex_2
{
    public class Adder
    {
        private int[] numbers;

        public Adder (int[] numbers)
        {
            this.numbers = numbers;
        }

        public int sum()
        {
            int sum = 0;

            foreach (int number in numbers)
            {
                sum += number;
            }
            return sum;
        }

        public int sumDivide3()
        {
            int sum = 0;

            foreach (int number in numbers)
            {
                if (number % 3 == 0)
                {
                    sum += number;
                }
            }
            return sum;
        }

        public int Elements()
        {
            return numbers.Length;
        }

        public void PrintAllElements()
        {
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
        }

        public void PrintElementInRange(int lowIndex, int hightIndex)
        {
            if (lowIndex < 0)
                lowIndex = 0;

            if (hightIndex >= numbers.Length)
                hightIndex = numbers.Length - 1;

            for (int i = lowIndex; i < hightIndex; i++)
            {
                Console.WriteLine(numbers[i]);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Adder adder = new Adder(numbers);

            Console.WriteLine($"Sum of all numbers: {adder.sum()}" );
            Console.WriteLine($"Sum of numbers divisible by 3: {adder.sumDivide3()} ");
            Console.WriteLine($"Number of elements in the array: {adder.Elements()} ");

        }
    }
}
