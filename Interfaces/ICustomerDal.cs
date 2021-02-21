using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Interfaces
{
    interface ICustomerDal //buradaki "Dal" veri işlemlerini yapabilecğeimiz sınıf anlamına geliyor
    {
        void Add();
        void Update();
        void Delete();


    }

    class SqlServerCustomerDal : ICustomerDal //bruadaki Sql veritabanıdır. Farklı bir veritabanı kullanacaksakta bu ICustomerDAl diye belirtmeliyiz.
    {
        public void Add()
        {
            // throw new NotImplementedException();
            Console.WriteLine("Sql Added");
        }

        public void Delete()
        {
            Console.WriteLine("Sql Deleted");
        }

        public void Update()
        {
            Console.WriteLine("Sql Updated");
        }


        
    }

    class OracleServerCustomerDal : ICustomerDal //bruadaki Sql veritabanıdır. Farklı bir veritabanı kullanacaksakta bu ICustomerDAl diye belirtmeliyiz.
    {
        public void Add()
        {
            // throw new NotImplementedException();
            Console.WriteLine("Oracle Added");
        }

        public void Delete()
        {
            Console.WriteLine("Oracle Deleted");
        }

        public void Update()
        {
            Console.WriteLine("ORacle Updated");
        }



    }

    class CustomerManager
    {
        public void Add(ICustomerDal customerDal) //mesela bir proje yaptık. Sql'e göre. sonra müşteri geldi, benim veritabanım Oracle'ye göre. bunun için : 
        {
            customerDal.Add();  //Burada ne Sql görüyoruz ne ORacle. sadece interfaceyi görüyoruz. Gittik buradan program.cs nin içerisine.


        }

    }



}
