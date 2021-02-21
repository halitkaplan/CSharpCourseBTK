using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticClasses_and_Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.List();


            Product product = new Product { Id = 1, Name = "Laptop" };
            Product product1 = new Product();

            // (7) Static nesneler ortak nesnelerdir ve herkes kullanabilir.
            // (8) Bir değer değiştiğinde diğerinin de değişmesini istiyorsam static olarak tanımlama yapabilirim.
            // (9) Genellikle Static nesnelerden uzak durmaya çalışırız fakat durmadığımız kısımlarda oluşabiliyor.


            Teacher.Number = 10;

            Utilities.Validate(); // (11) Static olmasını istediğim zaman bunun gibi çağırabiliyorum.

            Manager.DoSomething();  // (15) DoSomething'i bu şekilde ; Yani : Static olanı bu şekilde ; 

            Manager manager = new Manager();  // (16) DoSomething2 'yi de bu şekilde çağırabilirim. !! Static olmayanı bu şekilde çağırabiliyoruz.
            manager.DoSomething2();

            Console.ReadLine();

        }
    }

    class CustomerManager
    {
        private int _count = 15;
        public CustomerManager(int count)
        {
            _count = count;
        }



        public CustomerManager()
        {

        }


        public void List()
        {
            Console.WriteLine("Listed! {0} items", _count);

        }

        public void Add()
        {
            Console.WriteLine("Added!");
        }
    }




    class Product
    {
        public Product()
        {

        }
        private int _id;
        private string _name;
        public Product(int id, string name)
        {
            _id = id;
            _name = name;
        }

        public int Id { get; set; }
        public String Name { get; set; }
    }

    static class Teacher // (1)  Sınıfı Static hale bu şekilde getirebiliriz.
    {                    // (2) Peki burada ki Static nedir: Static bir nesnenin hiç bir zaman instancesini oluşturamayız. yani New'leyemeyiz.
                         // (3) Sistem tarafından tek bir nesne oluşturuyor ve tüketiliyor.
                         // (4) Static bir nesne oluşturduğum zaman, bunun paylaşılır olup olmadığına dikkat etmem gerekiyor.

        public static int Number { get; set; } // (5) Böyle bir durumda , bizim static nesnemizin bütün özellikleride static bildirgesine sahip olması gerekiyor.
                                               // (6) Burayı da, Main bloğunda Teacher.Number = 10; şeklinde kullanabilirim. Ama burası herkes için aynı olur yani uygulamayı kullanan herkes, bu hafızada durduğu için herkes için aynı durum gereçerlidir. 
    }


    static class Utilities
    {
        // (10) Genellikle burada, sıklıkla kullandığımız operasyonlar varsa utilities gibi bir class'ın içerisinde tanımlayabiliriz.

        static Utilities()
        {
            // (17) Static bir nesnede mutlaka çalışmasını istediğim bi kod bloğum varsa eğer; onu da buraya yazıyorum.
        }
         
        public static void Validate()
        {
            Console.WriteLine("Validation is done");
        }




    }

    // (12) Bir Class'ı Static yapmayıp, özelliklerini static yapabilirim.

    class Manager
    {
        public static void DoSomething()    // (13) Eğer ben DoSomething'i kullanacaksam hiç instance üretmeden yukarıya [Main Bloğuna] gidip Manager.DoSomething() gib kullanabiliriz.
        {
            Console.WriteLine("done");

        }

        public void DoSomething2()          // (14) Fakat, DoSomething2 yi kullanacaksam, Main bloğuna gidip; Manager manager = new Manager() demem gerekiyor.
        {
            Console.WriteLine("done2");
        }

    }






}
