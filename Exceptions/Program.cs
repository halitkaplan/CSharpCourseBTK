using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exceptions   // Hata Yönetimi 
{
    class Program      // Kullanıcıya, Program üzerinden bir hata olduğunda uyarı gösterecek kodlardır.
    {
        static void Main(string[] args)
        {
            // (2) Hata olmasından endişelendiğimiz bir kod var ise:
            try         //(3) Kod, başarılı olursa yani bir hata olmazsa ki kodu 'try' kısmına yazıyoruz.
            {
                string[] students = new string[3] { "Engin", "Derin", "Salih" };

                students[3] = "Ahmet";  // (1) Kullanıcı geldi, bu şekilde bir şey yazdı. Dalgınlığına geldi diyelim.

          
            }

            catch (IndexOutOfRangeException exception)   // (10) Alınan hatanın türü, IndexOutOfRangeException ise, bunu yap diyoruz. 
            {                                            // (11) IndexOut... kısmına seçip F12 ye bastığımızda, Exception tabanında olduğuu görüyoruz. 
                Console.WriteLine(exception.Message);    // (12) Aldığımız hatanın türü bu değilse, bunu haricindeki bütün hatalar için; Exception kısmı çalışır.
            }
            //  Eğer birden fazla değişik hata türünde hata alacağımızı düşünüyorsak, buradaki gibi çoğaltmayı yapabiliriz.

            catch (Exception exception)   // (4) 'try' da bir hata olursa, cathc kısmına geçiyor.
                                          // (5) Buradaki Exception olayı, try kısmında hata olduğunda Exception diye bir nesneye aktarılıyor. kullanacaksak buraya exception diye de yazabiliriz.
            {                             // (6) exception.Message diye bir uyarıyıda yazdırabilirdik.

                Console.WriteLine(exception.Message);   // (7) Yaptığımız bir uygulama bir hata verdiğinde bu hatayı genellikle kullanıcıya göstermeyiz. Çünkü sistem hakkında bilgi sahibi olmuş olur.    
                                                        // (8) Peki buradaki exception.Mesaageyi biz nerede kullancağız?? Bunu son kullanıcıya göstermek yerine; Bunu bir veritabanına loglarız.

                Console.WriteLine(exception.InnerException);  // (9) Bu exception hakkında varsa daha detaylı bilgi verecektir. Şu an Inner exception datası olmadığı için bir şey yazmıyor.


            }

            // (13) HandleExceptions diye bir metod oluşturmak istiyorum.

            HandleException(() =>      // (14) Buradaki parametremin türünün kod bloğu olmasını istiyorum yani parametreye 'string city' gibi şeyler yazmak yerine parametre olarak bir method yollamak istiyorum.
            {
                                      // (15) Bunun içinde 'delege'leri kullanıyorum yani, ()=>{}   boş olan yay parantez parametresiz methodum    , bu methodun => (karşılığı) kod kümesi {} olmuş olacak

                // (99999) Buraya private static void yani kendini tekrarlama demek istediğimiz mir method oluşturudp direk emthod adını yazabiliriz. DAha iyi olur.

                                      // (16)  try catch ifadesi yerine, bunu kullanabiliriz.
                                      // (17)  HandleException yazdığımızda altı kırmızı çizilebilir. Bunun için üstüne tıklayıp 'Genereate Method diyebiliriz.

            });

            Func<int, int, int> add = Topla;       // (99999_5) <1. veri tipim, 2. veri tipim , dönüş tipim > , Func<int, int, int> add = Topla(3,7); Bu şekilde yazdığımda
                                                   // (99999_6) benim dönüş tipim int ama beklediğim sonuç Func. Ben buna dönüştüremiyorum diye hata verecek.
                                                   // (99999_7) Onun için delegelerdeki gibi çağırmam gerekir. 

            Console.WriteLine(add(3, 5));
            
            Console.WriteLine(Topla(8,5));


            // (99999_8) Ben burada Func<int> gibi bir şey gördüm. tek parametre, Demekki burada mutlaka bir ödnüş olmak zorunda
            // bu da parametresiz metodlara delegasyon yapıyor ve sonucunda int döndürüyor. 
            Func<int> getRandomNumber = delegate ()
            {
                Random random = new Random();
                return random.Next(1, 100);
            };


            // (99999_9) Bunun da farklı yazış tipine bakacamk olursak:
            
            Func<int> getRandomNumber2 = () => new Random().Next(1, 100); // Parametresiz methoda delegasyon yapacak.

            Console.WriteLine(getRandomNumber());
            Thread.Sleep(1000); // 1 sn delay
            Console.WriteLine(getRandomNumber2());



            Console.ReadLine();
        }

        private static void HandleException(Action action)     // (18) Buradaki Action kısmı, handle exceptionun içi demek.
        {                                                      // (99999_1) !! Buradaki Action kısmı bir methoda karşılık gelir. MEthod bloğuna. 
                                                               // (99999_2) Void olanları çalıştırmakla yükümlüdür.
                                                               // (99999_3) Buradkai ACtion için, Ben senden bir şey beklemiyorum. Sana blok yollayacağım benim içn onu çalıştır diyoruz.
            // (19) Bu kod bloğu benim hayatım boyunca bir kere yazacağım bir kod bloğu. 
            // (20) try catch kısmını buraya yazıyoruz.

            try
            {
                action.Invoke();        // (22) yani burada, action kısmını handleexception kısmı olduğunu tekrar hatırlayıp , HandleExceptionu burada yani tryın içerisinde çalıştırıyor.
            }
            catch (Exception exeption)  // (21) Aldığın exception türü ne olursa olsun action'u "Invoke" et dedik 
            {
                Console.WriteLine(exeption.Message);      // (23) Biz bu privet static void handleE.... kısmını merkezi bir classın içerisine koyup çağırız genellikle.
                throw;
            }
        }



        static int Topla(int x, int y) // (99999_4)FUNC ,    Çalıştır ve aynı zamanda bana bir değer döndür diyebiliriz.
        {
            return x + y;


        }


    }
}
