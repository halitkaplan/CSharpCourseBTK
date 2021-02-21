using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferencesAndValueTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = 10;
            int number2 = 20;
            number2 = number1;
            number1 = 30;  // (1) Burada yapmış olduğumuz şey; değer tiptir. 

            Console.WriteLine(number2);

            string[] cities1 = new string[] { "Ankara", "Adana", "Afyon" };  //(2) Eşittirin sol tarafı, Değeri tutan yerdir; Sağ tarafı ise, Referansını tutan yerdir. New dediğimiz için referans bir değer atıyor. Diyelim ki bunun referansı 101
            string[] cities2 = new string[] { "Bursa", "İstanbul", "Sivas" }; // (2.1) Bunun referansı da 102 olsun.

            cities2 = cities1;  // (3) Buradaki olay tamamiyle bellekteki referans üzerinden gidiyor.
                                // (4) Burada, cities2 nin 102 olan referansı burada 101 yapıyoruz. Buradaki 102 nin hiç bir anlamı kalmıyor.

            cities1[0] = "İstanbul";



            Console.WriteLine(cities2[0]); // (5) Yukarıda, Cities1 in referansı 101 idi, Cities2 nin referansı da 102 idi, Bu 102 olan referansı biz 101 olarak değiştirdik.
                                           // (6) Sonuç olarak cities1 ve cities2 aynı şeyler oldular. Biz cities1 de bir dğeişiklik yapsakta bu cities2 ye de yansıyacak. çünkü cities2 nin referansı cities1 ile aynı!!!!

            // (7) Yukarıdaki Arraylar newlenerek oluşturulmuş arraylardir. Sonuç olarak bizim 2 adet 'Referansımız'mevcut.
            // (8) Bu durumlarda bizim performans olarak bir kaybımız mevcut.
            // (9) Bir şeyi 'New'lemek bellekteki en pahalı işlerden birisidir.

            // (10) Örnek olarak, programcı şu şekilde çalışabilirdi. Buradkai DataTable'leri bir class olarak düşünüelim yukarıdaki ile aynı mantık.

            //       DataTable dataTable = new DataTable();
           //        DataTable dataTable1 = new DataTable();
          //         dataTable = dataTable1;

            // (11) Yukarıdaki gibi yaptığında performans açısından bir kayıp oluşacaktı. Fakat aşşağıdaki gibi yapsa daha güzel olacak;

            DataTable dataTable;          // (12) Burada Newlemenin hiç bir anlamı yok!!.
            DataTable dataTable1 = new DataTable();
            dataTable = dataTable1;


            Console.ReadLine();
        }
    }
}
