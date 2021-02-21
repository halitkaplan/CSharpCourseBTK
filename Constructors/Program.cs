using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Constructors
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();  //(1) Buradaki newlediğimiz sınıfın yanında parantez açıp kapıyoruz.
            customerManager.List();                                     //(2) Buradaki parantez, Class'ımızın parametresiz olarak çalışacağızı gösterir.
                                                                        //(6) Burada da zaten altını çizmiş. Yani bizden bir değer istiyor. Örnek olarak 10 diyebiliriz.

            Product product = new Product { Id = 1, Name = "Laptop" };  // (14) New'leme işlemini yaptıktan sonra burada değerlerimizi verdik.
            Product product1 = new Product();   // (17) Hem parametreli, hem de gösterildiği gibi parametresizde kullanılabilir.
                                                // (18) Örnek olarak, (2,"Notebook") diyebiliriz.
            Console.ReadLine();

        }
    }

    class CustomerManager
    {
        private int _count=15;  // (5) Private bir field, "_" ile başlatılır. Bu bir standartır. Metod halinde ise alt çizgi kullanılmaz
        public CustomerManager(int count)    // (3) Construction oluşturmak için "ctor" yazıp tab+tab tuşlarına basarak oluşturabiliriz.
        {
            _count = count;                  // (4) Sınıfımızın, parametrelere ihtiyacı varsa, Bu parametreler değişiklik gösteriyorsa, o zaman Contructions'dan yararlanabiliriz.
        }                                    // (7) Main bloğumda göndermiş olduğum 10 değerini buraya gönderdik. Burada da 10 değerini _count yani private bir değişkenine atamış oldum.

        // (9) Contruction'ları aynı zamanda overload'da edebiliriz.

        public CustomerManager()      // (10) Burada parametresiz, dikkat edelim. 
        {                             // (11) Main bloğumda da CustomerManager yazdığımda parametresiz olduğunu yani buradan bahsettiğimizi söyleyebiliriz.
                                      // (12) Bize parametre olarak hiç bir şey verilmez ise 15, verilirse eğer; örnek olarak main bloğunda 23 yazarsak, 23 olarak ekranımıza geldiğini göreceğiz.  
        }


        public void List()
        {
            Console.WriteLine("Listed! {0} items", _count);  // (8) Mesela, burada da 10 tane müşteriyi listeleyeceğimizi varsayalım.
                                                             
        }

        public void Add()
        {
            Console.WriteLine("Added!");
        }
    }


    // Nesne örnekleri için constructor

    class Product           // (13) Product diye bir sınıf oluşturduk.
    {
        public Product()
        {

        }
        private int _id;
        private string _name;
        public Product(int id, string name)
        {
            _id = id;      // (15) id'yi, kullanıcının gönderdiği id'ye eşitliyorum.
            _name = name;  // (16) name'yi de, yine kullanıcının gönderdiği nameye göre eşitliyorum.
        }

        public int Id { get; set; }
        public String  Name { get; set; }
    }
}
