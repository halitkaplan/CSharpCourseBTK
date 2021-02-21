using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Methods_ParamasKeyword
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Add(1, 2, 3, 4, 5, 6));
            Console.ReadLine();
        }

        static int Add (params int[] numbers )
        {
            return numbers.Sum();
        }
    }
}
