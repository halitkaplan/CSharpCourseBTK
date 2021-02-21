using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Public_Metodu
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Customer
    {



        public void Save()
        {

        }

        public void Delete()
        {

        }
    }


    class Student : Customer
    {

        public void Save2()
        {

        }
    }

    public class Course
    {
        public string Name { get; set; }
    }
}


// (1) Mesela ben, Bir projede oluşturmuş olduğum Class'ı, farklı bir projede kullanmak istiyorum.
// (2) Bunun için yapılması gerek ilk adım, hangi projede kullanacaksam eğer, orada kullanacak olduğum class ya da farklı bir şey için 
// referans belirlemem gerekmektedir.
// (3) Hangi projede referans belirleyeceksem eğer, --> References --> Add Reference --> Project --> Solution
// adımlarından referansımı belirlemem gerekiyor.
// (4) Farklı bir projede buradaki Course Classımı kullanmak istiyorum
// (5) Public_Metodu_referans

// (5!!!) Ayrıca, Başka bir projedeki sınıfı kullanmak istiyorsam, kullanacağım projeye 
// diğer projeye ait using yazmam gerekir. -->  Public_Metodu_referans gidiyoruz .

