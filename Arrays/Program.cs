using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] students = new string[3];
            //students[0] = "Ali";
            //students[1] = "Mehmet";
            //students[2] = "Ayşe";

            //string[] students = {"Ali", "Mehmet", "Ayşe"};

            //foreach ( var student in students)
            //{
            //    Console.WriteLine(student);
            //}

            //Console.WriteLine();
            //Console.ReadLine();


            string[,] regions = new string[7, 3]
            {
               {"İsanbul","izmir","Bursa" },
               {"Sivas","Mersin","Isparta" },
               {"Yozgat","Ordu","Giresun" },
               {"Zonguldak","KArabük","Samsun" },
               {"Sinop","Ankara","Hatay" },
               {"Şırnak","MArdin","Van" },
               {"Hakkari","Trabzon","Niğde" },
            };

            for ( int i=0; i<= regions.GetUpperBound(0);i++)
            {
                for ( int j = 0; j<=regions.GetUpperBound(1); j++)
                {
                    Console.WriteLine(regions[i, j]);

                }
                Console.WriteLine("********");
            }

            Console.ReadLine();

        }
    }
}
