using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops
{
    class Program
    {
        static void Main(string[] args)
        {
            //For();
            //While();
            //DoWhile();
            //ForEach();
        }

        private static void ForEach()
        {
            string[] students = { "Ali", "Mehmet", "Ayşe" };
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
            Console.ReadLine();
        }

        private static void DoWhile()
        {
            int number = 10;
            do
            {
                Console.WriteLine(number);
                number--;
            } while (number >= 0);
            Console.ReadLine();
        }

        private static void While()
        {
            int number = 10;
            while (number >= 0)
            {
                Console.WriteLine(number);
                number--;
            }
            Console.ReadLine();
        }

        private static void For()
        {
            for (int i = 0; i <= 100; i++)
            {
                Console.WriteLine(i);

            }
            Console.ReadLine();
        }
    }
}
