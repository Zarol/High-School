using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatePi
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime starting = DateTime.Now;
            int input;
            Console.Write("The number of iterations:...");
            input = int.Parse(Console.ReadLine());
            decimal sum = 0;

            for (int i = 1; i <= input; i++)
            {
                decimal numberAdding = (decimal)(1.0 / ((i * 2) - 1));

                if (i % 2 > 0)
                {
                    sum = sum + numberAdding;
                }
                else
                {
                    sum = sum - numberAdding;
                }

                if (i % 20 == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Pi = " + (sum * 4));
                    Console.WriteLine("Iterations Remainining: " + (input - i));
                    Console.WriteLine("Console Run Time: " + (DateTime.Now - starting));
                }
            }
            Console.Clear();
            Console.WriteLine("Pi = " + (sum * 4));
            Console.WriteLine("Number of iterations: " + String.Format("{0:n}", input));
            Console.WriteLine("Console Run Time: " + (DateTime.Now - starting));
            Console.ReadLine();
        }
    }
}
