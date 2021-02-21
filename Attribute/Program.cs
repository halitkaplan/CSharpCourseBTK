using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer { Id = 1, LastName = "Kaplan", Age = 21 };
            CustomerDal customerDal = new CustomerDal();
            customerDal.Add(customer);
            Console.ReadLine();


                                  // (6) Customer class'ının içerisindeki RequiredProperty'nin olmadığını varsaayrsak;
                                  // (7) Aşağıda oluşturduğumuz ekrana yazma kodunda, FirstName kısmını yazmayacak, çünkü yok.
                                  // (8) Biz bunu istemiyoruz. Adın yazılması zorunlu olsun.
        }
    }

    [ToTable("Customers")]        // (9) Bu Customer nesnesi veritanablarında customers tablosuna denk gelir. Genellikle 
                                  // (9.1) bu yapıyıda Dinamik sorgular yapmak için sorgularız. Müşteri ekleme işlemi yapmak için
                                  // (9.2) Aşağıdaki verileri alıp bir de customers tablosunu alıp bir inster sorgusu SQl sorgusu yapılabiliyor.
                                  // (9.3) Burada da class'a attribute eklemiş olduk.
    [ToTable("Customers")]
    class Customer
    {
        // (1) Ben diyorum ki; Bu nesneleri kullanan ortamlarda mesela FirstNamee için, FirstName girilmesi zorunlu olsun diyorum.
        // (2) bir anlam ifade edecek bir yapı kullanabilirim:

        public int Id { get; set; }
        [RequiredProperty]         // (3) FistName'nin üzerine Reuqied Attribute eklediğimizde : normal şartlarda bu şekilde
                                   // (3.1) Bu şekilde bir anlamı yok tabi
                                   // (4) Required Property oluşturdupumuzda, customer class'ı oluşturan bir kişi
                                   // (4.1) İd, LastName, Age gibi değerleri verdi ve bu customeri ekleme çalışıyor diyelim

        public string FirstName { get; set; }
        [RequiredProperty]
        [RequiredProperty]
        public string LastName { get; set; }
        [RequiredProperty]
        public int Age { get; set; }
    }


    class CustomerDal
    {
        [Obsolete("Don't use Add, instead use AddNew Method")]   //(18) bu hazır bir attributedir.
                                                                 // (19) Açıklama gibi bir şey de ekleyebiliriz.
                                                                 // (20) Add'yi kullanma AddNew'i kullan diye. Obsolete ifadesi 'eski' demek zaten.
        public void Add(Customer customer)  // (5)  Bu customer2i eklemeye çalışıyor. 
        {
            Console.WriteLine("{0},{1},{2},{3}, added!", customer.Id, customer.FirstName, customer.LastName, customer.Age);
        }
        

        public void AddNew(Customer customer)  
        {
            Console.WriteLine("{0},{1},{2},{3}, added!", customer.Id, customer.FirstName, customer.LastName, customer.Age);
        }  // (15) Hazır Attributeler de var. MEsela ben buraya AddNew diye bir şey ekledim. Ama üsteki Add'ye dokunamıyorum 
           // (16) Çünkü programda onu kullanan yerler var. Programcıya şöyle Bir şey diyebiliriz. Arkadşa ben yenisini yazdım
           // (17) Bunu kullanma. 
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)] // (21) Ben bu ifadeyi kullandığım zaman, alt satırda oluşturmuş olduğum attributeyi 
                                                // (22) bu attribute'yi herkese kullanabilirsin demek. ister bir class'a istr bi lass,'ın özelliğine..
                                                // (23) Eğer ben burada, All yerine Class deseydim; Bu Attrubet sınıfını sadece Class'larda kullanabileceğimiz anlamına gelir.
                                                // (24) Ben bunu nesnelerde kullanacağım için Property demeliyim.
                                                // (25) Bunlardan bir kaç tanesine kullanmak sitiyorsam mesela poperty ya da fieldlerde kullaancağım diyorum.
                                                // (26) O zaman pipe kullanabiliriz | . [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]    gibi de kullanabiliri.
                                                // (27) MEsela ben bir şeyin attributesini, sorgusunu iki kere ve ya daha fazla uygulamak istiyorum
                                                // (28) O zaman ; [AttributeUsage(AttributeTargets.Property , AllowMultiple = true)] dediğim zaman
                                                // (29)   [RequiredProperty]
                                                //        [RequiredProperty]
                                                //        public string LastName { get; set; }   AllowMultiple true ise bu şekilde kullanabilirim. false dediğim zaman da birden fazla kulanamıyoruz.
    class RequiredPropertyAttribute : Attribute   // (10) Attribute nesnelerinin isimlerinin sonuna Attribute gelir ve Attribute snıfından inherit edilmesi gerekir.
    {

    }

    [AttributeUsage(AttributeTargets.Class , AllowMultiple = true)]
    class ToTableAttribute : Attribute  // (11) ToTable için yapacağımız Attributeerde Attribute den inherit edilir.
    {                                   // (12) Yukarıda yazmış olduğumuz sınıf için oluşturduğumuz attribute de 
                                        // (13) [ToTable("Customers")]  Burada, Customers kısmına kızdı. Çünkü biz Customers'e bir parametre yolluyoruz.
                                        // (14) Bu Attributeye parametre yollayabilmemiz için :
        private string _tableName;
        public ToTableAttribute(string tableName)
        {
            _tableName = tableName;
        }

    }



    
}
