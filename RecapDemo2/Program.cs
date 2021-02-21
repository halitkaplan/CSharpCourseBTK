using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RecapDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Logger = new SmsLogger();
            customerManager.Add();
            Console.ReadLine();

            // farklı bir ortama Loglama işlemi yapacaksak eğer, yeni bir ortam ekledik diyelim,
            // her yeri değiştirmek yerine, geliyorum buradaki SmsLogger kısmını artık hangi ortama kaydedecekse
            // onu yazıyoruz. Bitiyor :)
        }
    }

    class CustomerManager
    {
        public ILogger Logger { get; set; }
        public void Add()
        {
            // DatabaseLogger logger = new DatabaseLogger();
            // logger.Log();
            // yukarıdaki bu 2 satırlık kodlama doğru değildir.
            //ben her seferinde ekleme işlemini veritabanına yapmak zorunda kalıyorum.
            // belki farklı bir ekleme işlemini veritabanına değil de farklı bir yere yapmak istiyorum ?????
            //bazen doısyaya bazen veritabanına loglamak isteyebilirim
            // Yani bu durumlarda İNTERACE'lerin nimetlerinden yararlanmak gerekir.


            // bunun yerine burada bir property tanımlayacağız 



            Logger.Log();
            Console.WriteLine("Customer Added");
            
        }

    }

    // log atma işlemi yapmak istiyoruz yani, halit şu tarihte add metodunu şu parametrelerle çalıştırdı şeklinde

    class DatabaseLogger : ILogger
    {

        // loglama işleminde , yukarıda mesela Logger: ... yanında herhangi bir interfacesi yok
        // buna dikkat et!!!
        // aksi halde sürekli newleme işlemini gerçekleştirmek zorunda kalırız.

        // mesela adam geldi dedei ki; ben log işlemlerini veritabanına loglamak istemiyorum, farklı bir medin dosyasında tutmak istiyorum derse.
        // işte o zaman bizim gelip bütün logger'ların hepsini değiştirmemiz gerekir.
        // yani bir classın, loglama işlemi ise, mutlaka bir Basesi olmak zorunda 
        public void Log()
        {
            Console.WriteLine("Logged database!");
                
        }
    }

    class FileLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged to file");
        }
    }

    class SmsLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged to sms");
        }
    }


    interface ILogger
    {
        void Log();
    }


}

// tüm ortamların yapacağı Loglama işlemi birbirinden farklı olduğu için
// interace kullanıyoruz. Aynı loglama işlemini farklı şekillerde yapıyoruz.

// örneğin database ve file ye yazarken kodlar aynı sadece sms te değişiyor olsaydı onu virtual yapardık
// bir operasyonumn herkesi  değiştirecek ama bir tane opr. her yer de aynı ise Abstrac yapardık.

