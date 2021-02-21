using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {

            Person[] persons = new Person[3]
            {
               new Customer
               {
                   FName = "Halit"
               },
               new Student
               {
                  FName = "Mert"
               },
           new Person
           {
               FName="Salih"
           },
            };

            foreach (var person in persons)
            {
                Console.WriteLine(person.FName);
            }

            Console.ReadLine();

        }
    }

    class Person
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LNAme { get; set; }
    }

    class Person2
    {

    }

    class Customer : Person // Customer'e sen bir Person'sun dedik. Yani senini baban PErson abi.
    {
        public string City { get; set; }


    }

    class Student : Person // ben buraya gelip Person , Person2 diyemem. Çünkü bir kişinin bir tane babası olur! interface kullanımından farklı bir özelliktedir.
    
    {
        public string Departmant { get; set; }
    }

     // Eğer interface varsa, Önce Inheritance'ler (KAlıtımlar) yazılır ardından interfaceler yazılır.

}
