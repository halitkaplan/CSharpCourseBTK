using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal
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

    internal class Course // (1) bu classın önünde access modify yazmıyor. O zaman default'u nedir?
                          // (2) Bir Class'ın Defaultu "Internal" dir.
                          // (3) Biz, internal bir classı, bağlı bulunduğu proje içerisinde referans ihtiyacı olmadan kullanabiliriz.
                          // (4) Ben farklı bi class oluşturduğum zaman ; --> add --> Class --> CourseManager
    {                     // (7) Bir classın önüne, protected ya da private yazamayız. olmuyor zaten. Çünkü, bunu kullanacak bir otam mümkün değil.
                          // (8) Bir class, ya "Internal" olur ya da "public" olur.
                          // (9) Peki, Bir class hiç mi private olamaz?  
                          // (10) Bir class, private olur ama iç içe class larda olur.
        public string Name { get; set; }

       private class NestedClass // bura da iç içe bir class tanımlamış olduk.
        {                        // (11) Bu classa private diyebiliriz. Bu Class'ı sadece ve sadece
                                 // Course class'ının içerisinde kullanabileceğimiz anlamına gelir.

                                 // (12) Bu classa eğer, public ya da internal deseydik; dışarıdan da erişilebilir hala gelirdi !!!

                                 // (13) Bir internal, bağlı bulunduğu proje içerisinde hiç sıkıntı olmadan kullanılabilir.

        }

    }
}
