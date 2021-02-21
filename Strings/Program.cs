using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            //İntro();

            string sentence = "My name is Halit Kaplan";

            var result = sentence.IndexOf("baba");
            Console.WriteLine(result);
            Console.ReadLine();

        }

        private static void İntro()
        {
            string city = "Ankara";

            foreach (var item in city)
            {
                Console.WriteLine(item);


            }

            //Console.ReadLine();

            string city2 = "İstanbul";

            Console.WriteLine(String.Format("{0} {1}", city, city2));
            Console.ReadLine();
        }
    }
}
