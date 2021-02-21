using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contructor_Injector
{
    class Program
    {

        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.List();


            Product product = new Product { Id = 1, Name = "Laptop" };
            Product product1 = new Product();


            EmployeeManager employeeManager = new EmployeeManager(new DatabaseLogger()); // (3) Tanımlamamızı   // employeeManager.Logger = new DatabaseLogger();           
                                                                                         // (4) Loglamayı hangi projeye göre yapacaksak buradan ayarlıyoruz. 
            employeeManager.Add();                                     // (7) Zaten, bu yeni olan bu loglama işlemini yaptığımızda, 23. SAtırdaki tanımlamaya gerek kalmıyr.
                                                                       // (8) EmployeeManagerın yanındaki parantezin yerine (new DatabaseLogger()) yazmamız yeterli olacaktır
                                                                       // (9) Programcının buradaki parametrei unutma gibi bir şansı yok. Hata verecek çünkü
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
        // (1) Ben bu komutun başında Loglamayı çağırmak istiyorum.
        // (2) Main bloğuna dönüyoruz.
        // -->  public ILogger Logger { get; set; }
        // (5) Günümüzde bu işlemin daha doğru yapılış hali constructors kullanarak yapılan halidir.

        private ILogger _logger;
        public EmployeeManager(ILogger logger) // (6) Constructor ile gönderilen ILogger ne ise _logger'e eşitlendi.
        {                                       
            _logger = logger;
        }  
        public void Add()
        {
            _logger.Log();
            Console.WriteLine("Added");

        }
    }
}

