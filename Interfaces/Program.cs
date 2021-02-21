using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            // InterfacesIntro();
            // Demo();

            // Adamın benden istediği şeyi, hem Sql tabanında hemde ORacle tabanına yazdırmamı istedi. Bunu nasıl yapacağız:

            // o zaman bir array oluşturmamız gerek

            ICustomerDal[] customerDals = new ICustomerDal[2]    //Array'imizin içerisinde 2 tane değişken attım.
            {
                new SqlServerCustomerDal(),
                new OracleServerCustomerDal()
            };

            //elimizdkei bir datayı, bütün veritabanlarına bu sayede atıyoruz

            foreach (var customerDal in customerDals) //foreach döngüsü ile tüm veritabanlarıma yazdırma işlemini bu sayede yapabileceğim
            {
                customerDal.Add();

            }

            //foreach ile bütün veritabanlarını geziyoruz.


            // ************* ==> Mesela, ben yeni bir veritabanı daha getirdim. KArdeşim ben bundan sonra 
            // xy veritabanınıda destekliyorum ve bu datayı buna da yüklemek istiyorum dedim.
            // hiç bir şeyi ellemeden yeni veritabanı için kodlarımı yazdıktan sonra, sadece dizi "Array" içerisinden de
            // ekleme yaptıktan sonra işlemimiz tamamlanmış oluyor.



            Console.ReadLine();



        }

        private static void Demo()
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Add(new SqlServerCustomerDal());  //programımda hem Sql hem de oracle olduğu için, kolay bir şekilde hangisine ekleyeceğimizi buradan ayarlayabiliyoruz.
                                                              // Diyelim ki oracle:
                                                              //customerManager.Add(new OracleServerCustomerDal());
        }

        private static void InterfacesIntro()
        {
            PersonManager manager = new PersonManager();
            //manager.Add(new Customer { Id = 1, FirstName = "Halit", LastName = "Kaplan", Address = "İstanbul" })
            Customer customer = new Customer
            {
                Id = 1,
                FirstName = "Halit",
                LastName = "Kaplan",
                Address = "İstanbul"
            };

            Student student = new Student
            {
                Id = 2,
                FirstName = "Deniz",
                LastName = "Kaplan",
                Departmant = "Engineer"
            };

            manager.Add(student); //PersonManager Class'ında ekleme işlemine IPerson olarak parametreyi verdiğimizde herhangi bir sorun oluşmayacak.
            // ister student ister customer verebiliriz.
            manager.Add(customer);
        }
    }

    interface IPerson
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }


    class Customer : IPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

    }


    class Student : IPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Departmant { get; set; }



    }

    class PersonManager //MAnager ifadesi normalde iş katmanı sınıfları için kullanılır.
    {
        public void Add(IPerson person) //ben bir ekleme yapacağım ve parametre olarak bana bir müşteri nesnesi ver dedik
        {
            Console.WriteLine(person.FirstName);
        }

    }
}
