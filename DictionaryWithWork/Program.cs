using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryWithWork
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, string> dictionary = new Dictionary<string, string>();   // (1) bir anahtar kelime vasıtsıyla onun değerine ulaşabileceğimiz bir yapıdır.
                                                                                        // (2) Dictionary'nin içerisinde, <anahtar,değeri> anahtarı hangi türde, değeri hangi türde diye belirtiyoruz.

            dictionary.Add("Book", "Kitap");
            dictionary.Add("Table", "Tablo");
            dictionary.Add("Computer", "Bilgisayar");

            Console.WriteLine(dictionary["Table"]);         // (3) Değerini istediğimiz anahtarı soruyoruz. Değerini bize gösteriyor.
                                                            // (4) Eğer, sözlükte bulunmayan bir anahtarı sorguladığımız zaman hata verecek.!!!

            foreach (var item in dictionary)
            {
                Console.WriteLine(item.Key);                // (5) item'lerin hepsini görebilirim . Sadece, Keyleri görebilirim. Sadece 'Value'leri de görebilirim.
            }

                                                            // (6) Dictionary'de bir koleksiyondur. Metodları da burada kullanabiliriz.

            Console.WriteLine(dictionary.ContainsKey("glass"));  // (7) Sen de glass diye bir key var mı diye kontrol ettirebiliyoruz. Contains bool döndürüyor. True ya da False
            Console.WriteLine(dictionary.ContainsKey("Table"));  // (8) Aynı şeyler Value'ler için de geçerli.


                                     //!!!!!!!!!!!    (9) Dictionary< Tc , Müşteri> bunun gibi de olabilirdi. İlla sabit şeylerle yapmak zorunda değiliz.

            Console.ReadLine();
        }
    }
}
