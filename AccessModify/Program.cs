using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessModify
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Customer
    {
        //  private int Id { get; set; } // [1] private  (2) bunu bu şekilde tanımladığımız zaman, Id yi bu, class custome riçerisinde her yerde eğişebilmem mümkün
        // buradaki classın he yerinde bu Id yi kullanabiliriz                                           

        // [2] protected (4) buradaki private yerine protected yazıyoruz
        protected int Id { get; set; } // (6) Protected' da ise, farklı bir class içerisinde de bu Id değişkenini kulanacaksak
                                        // o class'ın yanına sen de bir customersin dediğimiz zaman
                                        // orada bu Id değişkenini kullanabiliriz.
        public void Save()
        {

        }

        public void Delete()
        {

        }
    }


    class Student : Customer  // (5) yukarıda, private int Id { get; set; } bu yazılı olmasıyla beraber, burada da studente
                              // sen de bir customersin dediğimiz zaman, yine bu kısımda id gelmeyecek. 
                              // çünkü Private, sadece ve sadece tanımladığı blok içerisinde geçerlidir.
    {

        public void Save2()
        {
          //  Customer customer = new Customer();

            // (1) burada, Customerin Id sini çağırmak istiyorum fakat bu şekilde
            // customer.id gelmemekte. Çünkü id, yukarıda yazdığımız id, sadece tanımlandığı 
            // blok içerisinde geçerlidir. Yani Private bir değişkendir, yalnızca tanımlandığı blokta kullanılabilir.

            // (3) fakat, customer. dediğimiz zaman yine id'nin gelmediğini göreceğiz.
            
            // (7) Student'lere, sende bir Customer'sin dediğimiz zaman, Customerlerin içerisinde
            // protected olarak tanımlanmış Id değişkenini burada da kullanabileceğiz.

            // (8) protected tanımladığımız zaman, inherit edildiği sınıflarda kullanılır yani.
            // privateyi inherit seviyesine çıkarmış oluyoruz.
        }
    }

}
