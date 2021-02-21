using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public delegate void StockControl();

   public class Product
   {
        // (5) Programı biraz genişletelim. 
        // (6) Bir değeri genelliklle veritabanından çekeriz. Fakat property vasıtasıyla bu değeri almaya çalışaağız.

       public int _stock;  // (7) _stock üzerinden sarı ampüle tıkladığımızda generate constructor vasıtasıyla kod satırını dirke oluşturabiliriz.

        public Product(int stock)
        {
            _stock = stock;
        }


        // (1) Mesela bir ticaret sitem var ve ürünlerin stok durumları bittiğinde ya da azaldığında belli bir sınıra
        // (2) geldiğinde, bana ya da müşteriye mail atsın demek istiyorum. 
        // (3) Bunu teker teker tüm malzemeler için if koduyla yapmam baya saçma. Bunu da Event ile rahatlıkla yapabiliyoruz.
        // (4) Bir eventi tanımlamak için:

        public event StockControl StockControlEvent;
        public string ProductName { get; set; }       
        
        public int Stock           // (8) Stocku burada get ve set ediyoruz. get, kalan stoğu okumak ; set ise stoğu yazmak
        {                          // (9) ben burad set işlemi yaparken, bir event vars ayani stock konusunda uyarılmak istiyorsa şöyle bir şley yaparız:
                                   // (10) Get için ayrı bir blok set için ayrı bir blok yapar ve bunların içlerini doldururuz.
            get
            {
                return _stock;
            }

            set
            {
                _stock = value;
                if (value <=15 && StockControlEvent!=null) // (11) Stok durumu 15 den az ise ve bu evente abone olunduysa ;
                {
                    StockControlEvent();
                }
            }              
     
        }                         

        public void Sell(int amount)
        {
            Stock -= amount;
            Console.WriteLine("{1} Stock amount : {0}", Stock, ProductName);
        }





    }
}
