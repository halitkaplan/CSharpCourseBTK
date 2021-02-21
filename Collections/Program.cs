using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] cities = new string[2] { "Ankara", "İstanbul" };
            // (1) Biz burada biraz çalıştık. Programın ilerleyen satırlarında buraya yeni bir şey eklememiz gerekti diyelim.

            cities = new string[3];   // (6) 18. satırı şimdilik yoksaydık
                                      // (6.1) Burada yeni bir new işlemi yaptığımız için önceki cities'in referans değerlerini kaybettik!!. Yani ben bu satırdan yola çıkarak, ekrana yazdırma işlemii cities[0] olarak yaptığımda boş bir satır ile karşılaşcağım
                                      // (6.2) Çünkü az önce de denildiği gibi, yeni bir new işlemi yapıldığından o Arrray'in referans değerlerini kaybettik!!!! New işleminde yeni bir referans oluşturulur.
                                      // (6.3) Yeni bir referans aldık fakat burada da içi boş olduğu için, boş bir satırla karşılaşıyoruz.
                                      // (6.4) Diyelimki 100 elemanlı bir array var ve 101'inci bir eleman eklememiz gerekti. işte bu durumda çok ciddi bir dinamizim ile uğraşmamız gerekir.
                                      // (6.5) bunun için koleksiyonlardan faydalanıyoruz.

           // cities[2] = "Adana"; // (2) Burada yazılan kod bizim için problemdir.

            Console.WriteLine(cities[0]); // (3) Kodu çalıştırdığımızda burada patladık. Çünkü string[2] diyince buradaki 2 eleman sayısıdır. Yani 2 elemanlıdır.
            Console.ReadLine();        // (4) cities[2] dediğimizde, buraya yazacağımız değerler, Array 2 elemanlı olduğu için ya 0 dır ya da 1 dir. Yeni bir eleman eklemeye çalıştığımda ben 3. eleman değerini girdiğimde dizi sınırlarını aştığından dolayı hata verecek.
        }                              // (5) diziyi "ihtiyaç doğrultusunda" 3 elemana çıkarttığımız zaman gidip yeni bir new oluşturmamız gerekiyor.
    }
}
