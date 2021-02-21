using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClasses
{
    //interfaceler ve virtual metodların birleşimi gibi düşünebiliriz
    //inheritance mantığı ile kullanılır.
    //abstrackt bir class oluiturmak için abstract ile başlanır class denir.

    class Program
    {
        static void Main(string[] args)
        {
            // abstract classlar 'new'lenemez

            Database database = new Oracle();
            database.Add();
            database.Delete();


            Database database2 = new SqlServer();
            database2.Add();
            database2.Delete();

            Console.ReadLine();
        }


    }


    abstract class Database
    {
        public void Add()
        {
            Console.Write("added");
        }

        //ekleme bütn veritabanlarında aynıdır fakat,
        //bunlar tamamlanmış metodlardır.
        public abstract void Delete(); // ama iş silmeye gelince bütün veritabanlarında farklı
                                       // bu ise tamamlanmamış metodlardır.
                                       // aslında; içi dolu olmayan virtual metoddur.
                                       // yani bu her ortamda ayrı olduğu için her yerde farklı farkklı implemente etmesi gerekir.
    }

    class SqlServer : Database
    {
        public override void Delete()
        {
            Console.WriteLine("Deleted by Sql");
        }



    }

    class Oracle : Database
    {
        public override void Delete()
        {
            Console.WriteLine("Deleted by Oracle");
        }
    }



}
