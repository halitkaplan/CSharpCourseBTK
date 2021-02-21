using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypesAndVariable
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int x = 10;
            Console.WriteLine(x);
            short y = 500;
            Console.WriteLine(y);
            double a = 10.12345678901234;
            Console.WriteLine(a);
            decimal b = 10.123456m;
            Console.WriteLine(b);


            var h = 10.4;
            
            Console.WriteLine(h);



            Console.ReadLine();
        }
    }

    enum days
    {
        pazartesi,salı,çarşamba
    }
}
