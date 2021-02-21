using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections_ArrayLists
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList cities = new ArrayList(); // (1) Koleksiyonlara başladığımızda bir öncekinde 'Collections'ta gördüğümüz gibi
                                                // (2) Bir şeyi new'lemek bellek için çok mağliyetli bir şeydir.
                                                // (3) Bunun yerine ArrayListler mevcut. ArrayList'i gösterildiği gibi oluşturuyoruz. Ardından Diziye eklemek istediklerimizi .add komutu ile ekliyoruz.

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

            Console.ReadLine();

        }
    }
}
