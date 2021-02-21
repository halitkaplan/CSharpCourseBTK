using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo
{
    public class ProductDal
    {
        public List<Product> GetAll()
        {
            using (TradeContext context = new TradeContext()) // buradaki using: TradeContext bellek için pahalı bir nesne. Çok yer kaplıyor. DbContext'e F12 ile gittiğim zaman;
                                                              // IDisposable interfacede implemente ediliyor. Bu da .Net'e ait bir interfacedir.
                                                              // Metod, bittiği zaman; .Net'in memory yöneticisi işi biten nesnelere bakıyor. Bu bittiği zamanda bellekten atmaya başlıyor. GurbageCollektor denilen çöp toplayıcı sistemiyle yapıyor.
                                                              // using kullanıldığında, method bittiği zaman, bu çöp toplayıcıyı beklemeden, dispose yapıyoruz. bellekten atmaya çalışıyoruz direk. Zorla Dispose komutunu çağırıyor.

            {
                return context.Products.ToList(); // tabloya erişme kodumuz bu kadar.




            }

        }


        public List<Product> GetByName(String key)
        {
            using (TradeContext context = new TradeContext()) 
            {
                return context.Products.Where(p=>p.Name.Contains(key)).ToList(); // direk veritabanında sorgulama işlemi yapıyor.

            }

        }


        public List<Product> GetByPrice(decimal min,decimal max)
        {
            using (TradeContext context = new TradeContext())
            {
                return context.Products.Where(p => p.Price >= min && p.Price<=max).ToList();  //ürünleri filtrele. fiyatları arasında sıralama yapıyor.
                                                                                              // iki fiyat aralığındaki ürünleri getirecek.
            
            
            
            }   

        }


        // tek bir ürün getirmek istediğimde, id ye göre sorgulama yaptığımda 
        public Product GetById(int id)  
        { 
            using (TradeContext context = new TradeContext())
            {
                //where, liste ile arama yaptığı için işimize yaramayacak şu an. data bulamazsan null getir, data bulursan datanın kendisini döndürür.
                var result =  context.Products.SingleOrDefault(p => p.Id == id);   //SingleOrDefault ile yaptığımızda aynı id ye sahip birden fazla nesne bulursa hatav eriyor.
                return result;
            }

        }




        public void Add(Product product) // bu bir işlem yapacak. Bir şey döndürmesi gerekmiyor. Bana bir product ver ve ben o product'u veritabanına ekleyeyim diyoruz.
        {
            using (TradeContext context = new TradeContext())
            {
                context.Products.Add(product); // ekleme işlemini burada yapıyoruz
                context.SaveChanges(); // işlem bittikten sonra adındanda görüldüğü gibi save ypaıyoruz

                // entity.State = EntityState.Added; şeklinde de ekleme işlemi yapılabilir.
            }
        }


        public void Update(Product product)
        {
            using (TradeContext context = new TradeContext())
            {
                var entity = context.Entry(product); //context'e product için abone ol.context üzerinden yapıyor. Bizim gönderdiğimiz productı veritabanındaki product'a eşitliyor. 
                entity.State = EntityState.Modified;
                context.SaveChanges();

            }
        }

        public void Delete(Product product)
        {
            using (TradeContext context = new TradeContext())
            {
                var entity = context.Entry(product); //context'e product için abone ol.context üzerinden yapıyor. Bizim gönderdiğimiz productı veritabanındaki product'a eşitliyor. 
                entity.State = EntityState.Deleted;
                context.SaveChanges();

            }
        }
    }
}
