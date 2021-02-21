using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            //    int number1 = 20;
            //    int number2 = 100;

            //   var result = Add2(ref number1,number2);
            //    Console.WriteLine(result);
            //    Console.WriteLine(number1);
            //    Console.ReadLine();

            //    //int number1;
            //    //int number2 = 100;

            //    //var result = Add2(out number1, number2);

            Console.WriteLine(Multiply(2, 4));
            Console.WriteLine(Multiply(2, 4, 5));
            Console.ReadLine();


        }

        static void Add()
        {


        }

        static int Add2(ref int number1, int number2)
        {
            number1 = 30;
            return number1 + number2;

            //static int Add2(out int number1, int number2)
            //{
            //    number1 = 30;              out ile gönderdiğimizde muhakkak işlemden önce set etme işlemi yapmalıyız.
            //    return number1 + number2;
            //}

        }

        static int Multiply(int x, int y)
        {
            return x * y;
        }

        static int Multiply(int x, int y, int z)
        {
            return x * y * z;
        }


    }
}
