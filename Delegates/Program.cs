using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public delegate void MyDelegate();   // (1)  Bu bizim elçimiz. Buradaki void, kendi içerisinde bir şey döndürüyor diyebiliriz.
                                         // (2) void olan ve parametresi olmayan operasyonlara delegelik yapıyor diyebiliriz.

   public delegate void MyDelegate2(string text);   // (20) Aynı zamanda, birşey döndürmeyen yani void olan ve parametreye sahip bir şekilde de ulanabiliriz.

    public delegate int MyDelegate3(int number1, int number2); // (26) 2 tane int parametre isteyen ve aynı zamanda int döndüren opertasyonlara hizmet etmekte.
                                                               // (27) Burada int döndüğüne dikkat edelim.
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.SendMessage();
            customerManager.ShowAlert();
            // (5) ben bunları el ile çağpırdım

            MyDelegate myDelegate = customerManager.SendMessage;

            // (6)  MyDelegate myDelegate , public delegate void MyDelegate();   bu formatta çalışan bir elçi.
            // (7) Bir delegeden birden fazla işi yapan elçi oluşturabilirim. 
            // (8) Bu elçi, maydelegate; CustomerManagerin sendMEssagesine delege edilmiş durumda demek oluyor.
            // (9) Ama bu şekilde çalıştırdığımız zaman ekranda Hello yazısını görmeyeceğiz. Bunu yapabilmemiz için, bunu yap demedik.
            // (10) Delegeyi çağırmamız lazım  myDelegate(); ile delegemizi çağırmış oluyoruz. 
            
            myDelegate();

            // (11) Peki şu şekilde yaptığımız da;

            myDelegate += customerManager.ShowAlert; // (12) Ben başka bir operasyonu da bu arkadaşa bu şekilde delege etmiş oluyoruz.
                                                     // (13) += ile bu işlemi yapabiliriz. Arka arkaya iki operasyonu çağırabiliriz.
                                                     // (14) Yapılacak işlemleri belli şartlara göre nce topluyoruz ve en nihayetinde o sırayı toplamış oluyoruz ve onu çağırmış oluyoruz.

            // (15) Mesela bir porlbem var ve şöyle demek istiyorum. 
            // (16) Ona selamımı yollama direk uyarıyı yap!! gibi bir şey demek istiyorum

            myDelegate -= customerManager.SendMessage;          // (17) bir işlemi geri almak istiyorum ben. 
                                                                // (18) -= kulandığımda da merhaba demeeyecek
                                                                // (19) Msela bu işlemi, eğer şu olduysa şunu deme/yapma gibi kullanabiliriz.

            // MyDelegate2 myDelegate2 = customerManager.SendMessage; // (21) Ben bunu bu şekilde yazdığımda hata verecek
                                                                      // (22) string ifadeye uyan bir şey göndermemiz lazım çünkü string bir ifade istiyor.

            MyDelegate2 myDelegate2 = customerManager.SendMessage2;   // (23) SendMessage2 yi kullandığım zaman hata vermeyecek çünkü string bir parametre yolluyoruz.    
            myDelegate2 += customerManager.ShowAlert2;


            Matematik matematik = new Matematik();
            MyDelegate3 myDelegate3 = matematik.Topla;
            myDelegate3 += matematik.Carp;
            var sonuc = myDelegate3(2, 3);
            Console.WriteLine(sonuc);         // (28) Delegelerde, bir return type varsa en son return type olan delege neyse onu çalıştıracaktır.
                                              // (29) Biz buradaki kodlarda 2+3 ü yaptırdık buna da 2*3 ü eklemek istedik. En son return type ye 2*3ü yazdığı için ekranda 6 ifadesini gördük.


            myDelegate2("Hello, Send and Alert");  // (24) Burada da string bir ifadeyi parametre olarak yolluyoruz yalnız buradaki
                                    // (25) kısıtımız Hello ifadesini SendMessage2 ve ShowAlert2 için aynı anda yollamış oluyor

            myDelegate();

            Console.ReadLine();
        }
    }

    public class CustomerManager
    {
        public void SendMessage()
        {
            Console.WriteLine("Hello!");   // (3) Merhaba diyen bir method oluşturduk. 
                                           // (4) dikkat edecek olursak, Burası void ve parametresiz.!!!

        }                                   

        public void ShowAlert()
        {
            Console.WriteLine("Be carefull!");   
        }

        public void SendMessage2(string message)
        {
            Console.WriteLine(message);   // (3) Merhaba diyen bir method oluşturduk. 
                                           // (4) dikkat edecek olursak, Burası void ve parametresiz.!!!

        }

        public void ShowAlert2(string alert)
        {
            Console.WriteLine(alert);
        }
    }


    public class Matematik
    {
        public int Topla(int sayi1, int sayi2)
        {
            return sayi1 + sayi2;
        }

        public int Carp(int sayi1, int sayi2)
        {
            return sayi1 * sayi2;
        }
    }
}
