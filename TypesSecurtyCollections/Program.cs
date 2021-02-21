using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypesSecurtyCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            //  ArrayList();

                                                                             // (1) Tip güvenli diziler ile çalışacaksak ;
            List<string> cities = new List<string>();                        // (2) Ben bir, Dizi oluşturmak istiyorum fakat bu dizi sadece ve sadece 'String' temelli olacak.

            cities.Add("Ankara");                                            // (3) Burada ekleme işlemi yaparken zorunlu olarak string bir ifade girilmesi isteniyor. Gidipte parantez içerisinde '1' yazdırmıyor. Hata veriyor zaten.
            cities.Add("İstanbul");

            Console.WriteLine(cities.Contains("Ankara"));                    // (17) Contains Komutu, Bu listede aradığımzı değer var mı? diye bakıyor.)
                                                                             // (18) Şehirlerin içerisinde Ankara değeri varsa, True döner. Eğer yoksa False dönecekti. True ya da False diye yazar.   
            foreach (var city in cities)
            {
                Console.WriteLine(city);
            }

                                                                              // (4) Ben, oluşturduğum bir dizi tipine göre de bir dizi tipi verebilirim. Şöyle ki;

            //List<Customer> customers = new List<Customer>();
            //customers.Add(new Customer { Id = 1, FirstName = "Halit" });
            //customers.Add(new Customer { Id = 2, FirstName = "Derin" });    // (7) 31-32-33. satırları bu şekilde yazmak yerine ;

            List<Customer> customers = new List<Customer>
            {
                new Customer { Id = 1, FirstName = "Halit" },
                new Customer { Id = 2, FirstName = "Derin" }
            };                                                                 // (8) 35-39 gibi de yazılabilir. 



                                                               // (9) Collection özelliklerinden bahsedecek olursak:

           

            var customer1 = new Customer
            {
                Id = 3, FirstName = "Salih"
            };
            
            customers.Add(customer1);                          // (11) Customer'e ekleme işlemini de 47-52 satırları arasındaki gibi yapabiliyoruz.

            customers.AddRange(new Customer[2]                 // (12) Array bazlı bir listeyi ver bana, ben de bunları olduğu gibi customers'in içerisine ekleyeyim.
            {
                new Customer {Id= 4, FirstName = "Ali"},
                new Customer {Id= 5 , FirstName = "Halido"}
            });

            Console.WriteLine(customers.Contains(customer1));  // (19) Burada da, customers'in içerisinde customer1'den eklediklerimiz var mı diye kontrol ettiriyoruz.

                                                              // (13) !!!!!!!! Bunu yaparken parantezin nasıl konduğuna dikkat et !!!!!!!!!!!


            // customers.Clear();                             // (14)  customers Listesini burada temizleyecek.


            var index = customers.IndexOf(customer1);        // (20) customer1'i aramaya baştan başlıyor. 0,1,2 diye
            Console.WriteLine("Index : {0}", index);

            customers.Add(customer1);

            var Lindex = customers.LastIndexOf(customer1);  // (21) Customer 1 i aramaya sondan başlıyor. 5 eleman arsa 5,4,3 gibi
            Console.WriteLine("LIndex : {0}", Lindex);

            customers.Insert(0,customer1);                  // (22) !!! kaçıncı sıraya neyi eklemek istiyorsun onu ayarlıyor. 0. indexe customer1'i ekliyor.

            customers.Remove(customer1);                    // (23) Remove, bulduğu ilk customer 1 değerini uçurur. hepsini silmez.
            customers.RemoveAll(c=>c.FirstName=="Salih");    // (24) Burada farklı bir parametre kullandık. Çok detaylı anlatılmadı. Listede Adı "Salih" olanları bul ve sil dedik. Buna da Predicat** deniyor. /SAnırım\fdsfds



            foreach (var customer in customers)
            {
                //Console.WriteLine(customer);              // (5) Bunu çaıştırdğım aman TypesSecurtyCollection'un altında olduğu için TypesSecurtyCollection.customer olarak bir yazı ile karşılaşacaktık

                Console.WriteLine(customer.FirstName);      // (6) ben customer'in neyini yazdırmak istediğimi burada belirtmeliyim ki beni anlasın.

            }
            var count = customers.Count;                    // (10) customers'e ne kadar eleman eklediysek ya da ne kadar eleman varsa onun sayısını verecek
            Console.WriteLine("Count : {0}", count);        // (15) Count'u 2 iken saydırdığımız içinn ekrana 2 diye yazdı.
                                                            // (16) Countu clear yaptıktan sonra saydırsaydık. 0 ı görecektik.

            Console.ReadLine();
        }


        private static void ArrayList()
        {
            ArrayList cities = new ArrayList();

            cities.Add("Ankara");               // (4) ArrayList'i oluşturduğumuz zaman, her hangi bir sınır koymuyoruz. İstediğimiz kadar eleman ekleyebiliriz.
            cities.Add("İstanbul");

            foreach (var city in cities)        // (5) Dizi mantığından olduğu için, ekrana yazdırırken ya da bir dizinin tüm elemanlarını dolaşmak için 
            {                                   // (6) Bildiğimiz üzere foreach komutunu kullanıyoruz.
                Console.WriteLine(city);
            }

            cities.Add("Adana");

            cities.Add(1);                      // (7) Add komutunu yazdıktan sonra bizden 'value' yani 'değer' istiyor. Buraya normal bir harf yazabiliriz, sayı yazabiliriz, kelime yazabiliriz.
            cities.Add('A');
            // (8) Yaptığımız projede 'tip güvenliği'yok ise yani, mecburi olarak tüm değerler string, int değil ise 
            // (9) Değerlerimiz buradakler gibi değişkense, rahat bir şekilde ArrayList'i kullanabiliriz.
            // (10) projelerde genellikle tip güvenli koleksiyonlar kullanıldığı için bu bakımdan çok tercih edilmemekte. 
            // (11) Bir sonrakinde de tip güvenli koleksiyonlara bakacağız.
            foreach (var city2 in cities)
            {
                Console.WriteLine(city2);
            }
            // Console.WriteLine(cities[2]);
        }
    }

    class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
    }
}
