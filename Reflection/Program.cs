using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            //DortIslem dortIslem = new DortIslem(2, 3);
            //Console.WriteLine( dortIslem.Topla2());
            //Console.WriteLine( dortIslem.Topla(3,4));

            var tip  = typeof(DortIslem);   // Bütün tipleri atayabildiğimiz bir nesnedir. 
                                            // bu bir instance değil. 
                                            // Benim çalışacağım bir tip var ve o DortIslem'dir diyoruz.

            DortIslem dortIslem = (DortIslem)Activator.CreateInstance(tip,6,7);
            // Neyin insantecsini oluşturmak istiyoruz???  aslında kod içerisinde 
            // yaptığımız new işlemini çalışma anında yapıyoruz. gelen tipe göre gerçeleştirmiş oluyoruz.

           Console.WriteLine(dortIslem.Topla(4, 5));    // mesela ben bir şey yapacağım ama bunun kodlama yaparken toplama olup olmadığını bilmiyorum
           Console.WriteLine(dortIslem.Topla2());       // Reflection ile instance oluşturduğumuzd aonun methodunu da çalıştırabiliyoruz.
                                                        // şöyle ki 


            var instance = Activator.CreateInstance(tip, 6, 5);

            MethodInfo methodInfon = instance.GetType().GetMethod("Topla2");
           Console.WriteLine(methodInfon.Invoke(instance, null));                    // GetMethod dediğim zaman, method bilgisine ulaşıyor. Invoke et dediğimizde
                                                                                     // Bu methodu neresi için çalıştıracak hususuna gelirsek içerisine instance yazıyor. Burada ki null parametresiz olduğunu gösterir.
                                                                                     // GetMethod ile istenilen methoda ulaşılıyor. İnvoke ile çalıştırıyor.
                                                                                     // bir tipin methoduna ulaşabilirsiz istersekte onu çalıştırabiliriz.
                                                                                     //   methodInfon.Invoke(instance, null);    burası bir sonuç döndürdüğü için ekrana yazdralım.
                                                                                     // üst satırda '35' te method bilgisi topluyoruz instance ile bağı kaybediyoruz.
                                                                                     // o methodinfoya, topa2adlı infoy çalıştır gibi bilgi vermiş oluyoruz.

            Console.WriteLine("----------------------");

            var metodlar = tip.GetMethods();                                          // Bu yazılan ifadeyle, bu classın' sahip olduğu methodlar geldi
            foreach (var info in metodlar)
            {
                Console.WriteLine("Metod adı: {0}", info.Name);                       // Console.WriteLine("Metod adı: {0}", info.Name);  Bununla methodların İSİMLERİNE.
                foreach (var parameterInfo in info.GetParameters())
                {
                    Console.WriteLine("Parametre: {0}", parameterInfo.Name);         // Console.WriteLine("Metod adı: {0}", info.GetParameters());     MEthodun parametrelerine
                }


                // Burada, parametrelerine ulaşabildiğim gibi Attributelerine de ulaşabilirim.

                foreach (var attribute in info.GetCustomAttributes())
                {
                    Console.WriteLine("Attribute Name : {0}", attribute.GetType().Name);   // varsa eğer ekrana yazacak 
                }
                                                                                              
            }                                                                                   


            Console.ReadLine();                                         
        }

    }


   public class DortIslem
    {
        private int _sayi1;
        private int _sayi2;

        public DortIslem(int sayi1 , int sayi2)
        {
            _sayi1 = sayi1;
            _sayi2 = sayi2;
        }
        public DortIslem()
        {

        }
        public int Topla(int sayi1, int sayi2)
        {
            return sayi1 + sayi2;
        }

        public int Carp(int sayi1, int sayi2)
        {
            return sayi1 * sayi2;
        }

        public int Topla2()
        {
            return _sayi1 + _sayi2;
        }

        [MetodName("Carpma")]   // bu methodun buradaki adı Carp2 fakat ben bu methodun dışarıya farklı bir isimle gözüksün isteyebilirim.
        public int Carp2()
        {
            return _sayi1 * _sayi2;
        }



    }


   public class MetodNameAttribute :Attribute
    {
        public MetodNameAttribute(string name)
        {

        }
    }



}
