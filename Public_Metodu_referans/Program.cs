using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Public_Metodu; //  (6)  referans alacak olduğum projeyi burada tanımlıyorum.


namespace Public_Metodu_referans
{
    class Program
    {
        static void Main(string[] args)
        {
            Course course = new Course();   // (7) Proje Referanslarına ekleyip, yukarıda tanımladıktan sonra
                                            // herhangi bir sorun çıkartmadan, Public olarak tanımlanan sınıfı burada kullanabiliyoruz.

        }
    }
}
