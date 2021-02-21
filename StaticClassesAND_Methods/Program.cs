using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticClassesAND_Methods
{
    class Program
    {

        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.List();


            Product product = new Product { Id = 1, Name = "Laptop" };
            Product product1 = new Product();


            EmployeeManager employeeManager = new EmployeeManager(new DatabaseLogger());
            employeeManager.Add();

            PersonManager personManager = new PersonManager("Product");
            personManager.Add();


            Console.ReadLine();

        }
    }

    class CustomerManager
    {
        private int _count = 15;
        public CustomerManager(int count)
        {
            _count = count;
        }



        public CustomerManager()
        {

        }


        public void List()
        {
            Console.WriteLine("Listed! {0} items", _count);

        }

        public void Add()
        {
            Console.WriteLine("Added!");
        }
    }




    class Product
    {
        public Product()
        {

        }
        private int _id;
        private string _name;
        public Product(int id, string name)
        {
            _id = id;
            _name = name;
        }

        public int Id { get; set; }
        public String Name { get; set; }
    }

    interface ILogger
    {
        void Log();
    }

    class DatabaseLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged to Database");
        }
    }

    class FileLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged to File");
        }
    }

    class EmployeeManager
    {





        private ILogger _logger;
        public EmployeeManager(ILogger logger)
        {
            _logger = logger;
        }
        public void Add()
        {
            _logger.Log();
            Console.WriteLine("Added");

        }
    }


    class BaseClass
    {
        private string _entity;

        public BaseClass(string entity)
        {
            _entity = entity;
        }
        public void Message()
        {
            Console.WriteLine("{0} Message" , _entity);  // (7) çalıştırdığımız zaman, ekradan; Product Message'yi görebiliriz.
        }
    }

    class PersonManager : BaseClass // (1) Burada , constructor olduğu için; Ben, base classtan mesajı çağıracağım ama
    {                               // senin bana bir entity göndermen gerekiyor. Diyor.

        public PersonManager(string entity) : base(entity)  // (2) Buraya bir constructor veriyorum
        {                                                   // (3) PersonManager'in içerisinde string entity olarak tanımlayıp, base ye de bu entity değerini gönderebiliyorum.
                                                            // (4) Base sınıfı bir değer göndermek istiyorsak; base diyerek, parametredeki değeri oraya yollayabilirim.


        }

        public void Add()
        {
            Console.WriteLine("Added!");
            Message(); // (5) BaseClass'ta Message olduğu için ben bunu inherit ettiğim yerde kullanabilirim.
                       // (6) PErsonManager'in içerisinde Message de var artık.
        }
    }
}
