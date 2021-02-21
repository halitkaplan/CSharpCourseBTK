using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            Utilities utilities = new Utilities(); // (15) sık kullandığımız işlemleri içerisine koyduğumuz bir sınıftır. 
                                                   // (16) Genellikle utilities adı kullanılır.

            List<string> result = utilities.BuildList<string>("Ankara","İzmir","Adana");  // (17) Ben sana böyle bir liste veriyorum
                                                                                          // (18) Sen bana, hangi tipte yazarsam bu tipte bir liste oluştur.
                                                                                          // (19) Bu datayı o tipte olan bir liste oluştur.
                                                                                          // (20) Utilitiesin BuildList'i List of String döndürmeli!!!! Ben int versem, integer döndürmeliydi
            
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            List<Customer> result2 = utilities.BuildList<Customer>(new Customer { FirstName = "Engin" }, new Customer { FirstName= "Derin"}); // (26) Ben burada müşteri listesi oluşturuyorum. Rahatlıkla gönderebiliriz.
                                                                                                    // (27) Değerlerini vererek tabi.

            foreach (var customer in result2)
            {
                Console.WriteLine(customer.FirstName);
            }



            Console.ReadLine();


        }
    }

    class Utilities
    {                                   // (21) List'in içerisine hangi tipte çalışacam o tipte döndür demek diye T yazdık
                                        // (22) Generic metodlarda, lass veya interface gibi, methodun sonuna çalışacağımız tipi vererek olur.
                                        // (23) Çalışacağım tipte değerler istiyorum diye yazıyoruz. T tipinde deerler istiyorum diye.
                                        // (24) Ankara izmir adana gibi 3 tane olurn 4 tane olur. Bunları da params ile yapıyorduk
        public List<T> BuildList<T>(params T[] items)
        {
            return new List<T>(items);   // (25) List of T yi döndür. T yi items için döndür diyoruz.
                                        
        }
    }


    class Product
    {

    }

    interface IProductDal : IRepository<Product>  //(1) bu interface ile temel operasyonları tanımlayıp onu implemente edicek sınıfları implemente ettirebiliriz
    {
        //List<Product> GetAll();
        //Product Get(int id);
        //void Add(Product product);
        //void Delete(Product product);
        //void Update(Product product);

    }


    class Customer
    {

    }


    interface ICustomerDal : IRepository<Customer>  // (8) Buraya gelip, sen bir IRepositoy'sin ve çalışma tipin Customersin dediğim zaman bitti.
    {
        //List<Customer> GetAll();
        //Customer Get(int id);
        //void Add(Customer product);
        //void Delete(Customer product);
        //void Update(Customer product);        bunları buradan silebiliriz 8. işlemi yaptıktan sonra. 


    }


    // (2) ProductDal ile CustomerDal birbirine çok benzer. Peki, biz bu yapıyı nasıl daha iyi hale getirebiliriz?

    interface IRepository<T> where T:class, IEntity, new()  // (3) Projeleri, nesne bazlı çalıştırabileceğimiz bir şey yazabiliriz. 
    {                         // (4) Yani, ben bu projeyi product olarak çalıştırayım, diğerini customer olarak çalıştırayım diyebiliriz.
                              // (5) bunun ini, interfaceye ya da abstract classa <T> gibi genellikle T kullanılır Type'den gelir. 
                              // (6) ben repository ile çalışacağım ama bana tipi ver
                              
                              // (28) Ben buradaki T nin veri tipini kısıtlamak istiyorum. 
                              // (29) Programcı geldi ve bir sınıfın tipini de string olarak verdi. Dalgınlıkla.
                              // (30) string harici veri tiplerinin girilmesi gerekiyordur ama. İşte bu kısıtlamayı yapabiliyoruz.
                              // (30) where T:class , T burada referans tiptir. buradaki class'tan kasıt, Referans tip olmak zorunda. 
                              // (31) buradaki class sınıf demek değil, referans tip demektir. String istiyorumsam class yapıyorum. 
                              // (32) Fakat string'te istemiyorum. O zaman: ,new() yazıyoruz. Buraya yazılan tip referans tip ve aynı zamanda newlenebilir bir nesne olması lazım.
                              // (33) string, newlenebilir bir nesne değil s'si küçük olan string. 
                              // (34) Bir class olmasını sağlayacağımız en önemli özellik class ve new yazmaktır.
        List<T> GetAll();
        T Get(int id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);      // (7) Buralarda da ben sana T vereceğim, Bu T ye göre yap. 


        // (9) Repository ismi genellikle veritabanlarında kullanılan aynı zamanda tasarım desenidir.

    }

    interface IStudentDal : IRepository<Student>   // (35) Buradaki student refernas tiptir ve newlenebilir bir nesnedir.
    {                                              // (36) Genellikle bu aşamada yapar ve bitiririz.
                                                   // (37) Daha da prof bir hale getirmk için; Burada sadece veritabanı nesneleri yazılabilsin isityorum
                                                   // (38) IRepository<CustomerDal> yazıldı diyelim. Ama bu saçma. Customer ya dastudent gibi bir şey yazıalbilir. 
                                                   // (39) Böyle bir durumda Student'i IEntity denilen bir interfaceden implemente ediyorum.
                                                   
    }

    class Student : IEntity                        // (40) IEntity'den implemende edilen bir sınıf, veritabanı nesnesidir.
                                
    {                                              // (41) Fakat kısıtı koyarken, Bizim bu referansımız IEntity'den implemente ediliyor olmalı!!! Diye bir kısıt belirtiyoruz.
                                                   // (42) interface IRepository<T> where T:class, IEntity, new()  şeklinde yazılır. new() her zaman sonda olmalı.
    }                                              // (43) class, refernas tip, IEntity buradan implemente edilmeli , new ; newlenebilir olmalı.
                                                   // (44) T için üç tane kısıt belirledik. 
                                                   // (45) Peki ben sadece Değer tipleriv ermek istiyorsam: ???
                                                   // (46) interface IRepository <T> where T:struct   , struct değer tiplere karşılık gelir. 
                                                   // (47) Dolyısıyla <Student> yazıldığında kızacak. Student yerine int yazarsam sorun ortadan kalkacak çünkü int değer tiptir.
    interface IEntity
    {

    }

    class ProductDal : IProductDal   // (10) IproductDal'ı burada implemente ettiğim zaman aşağıdaki gibi 
                                     // Product olarak geldiğini görebiliyorum.
    {
        public void Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }


    class CustomerDal : ICustomerDal    // (11) Ben peki burada direk IRepository üzerinden yapsam olmuyor muydu? 
    {                                   // (12) Yaptığımız zaman bir şeye kızmadığını görebiliriz. Olur fakat; Şöyle bir problemimiz var    
                                        // (13) Yarın veya öbür gün, CustomerDal'a özel bir şey yapıtğım zaman mesela ayın en popüler müşterisi 
                                        // (14) gibi bir ona özel bir işlem yaptırdığımız zaman, CustomerDal'ı implemente edeceksin diye zorluyor.

        public void Add(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
