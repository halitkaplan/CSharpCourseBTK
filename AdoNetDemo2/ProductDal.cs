using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetDemo2
{
    public class ProductDal
    {
        SqlConnection _connection = new SqlConnection(@"server=(localdb)\MSSQLLocalDB; initial catalog=Trade; integrated security=true");
        public List<Product> GetAll()
        {
            // SqlConnection connection = new SqlConnection(@"server=(localdb)\MSSQLLocalDB; initial catalog=Trade; integrated security=true"); //integrated security=false;uid=engin;password=12345 
            // metodların dışında kullandığımız için isimlendirme kuralıda değişmesi gerekiyor. "_" alt çizgi ekleyerek bu işlemi yapabiliriz _connection gibi.
            ConnectionControl();

            SqlCommand command = new SqlCommand("Select * from Products", _connection); // buradaki sorguyu da connection'a gönderiyoruz.
            SqlDataReader reader = command.ExecuteReader();

            List<Product> products = new List<Product>();

            while (reader.Read())  // okunan şeyler var ise, okuma işlemi yapılıyorsa istediğim kodları yap.
            {
                Product product = new Product
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    Stock = Convert.ToInt32(reader["Stock"]),
                    Price = Convert.ToDecimal(reader["Price"])

                };
                products.Add(product);  // okuduktan sonrada ekleme işlemini yapıyorum.

            }

            reader.Close();
            _connection.Close();
            return products;

        }

        private void ConnectionControl()   // bu işlemi sürekli yapacağımız için, method haline getirebiliriz.

        {
            if (_connection.State == ConnectionState.Closed)  // burada da bağlantı işlemi yapıldıysa tekrar bağlanmaması için, bağlantı kapalı ise aç işlemini yaptırıyoruz.
            {
                _connection.Open();
            }
        }

        public void Add(Product product) // bu bir işlem yapacak. Bir şey döndürmesi gerekmiyor. Bana bir product ver ve ben o product'u veritabanına ekleyeyim diyoruz.
        {
            // Burada bir komut çalıştırmamız gerekiyor. Bunun için :
            //SqlConnection connection = new SqlConnection(@"server=(localdb)\MSSQLLocalDB; initial catalog=Trade; integrated security=true"); 
            // Bu bağlantıyı süreki kullanıyoruz çünkü bir bağlanma işlemi gerçekleştirmemiz gerekiyor. Bu bağlantıyı sürekli 
            // yazmak yerine, Public class'ımızın bir satır altına yazsak daha iyi olur aslında.
            ConnectionControl();
            SqlCommand command = new SqlCommand("Insert into Products values(@Name,@Price,@Stock)", _connection); //buradaki valuesyi paramtere olarak bir yerden alacağımızı valuenin parantezi içerisine yazıyor. @Name 'den al gibi.
            command.Parameters.AddWithValue("@Name",product.Name); //parametremiz varsa, valuemize şu şekilde ekliyoruz. Product'un namesini alıyor, @Name'nin içerisine koyuyor.
            command.Parameters.AddWithValue("@Price", product.Price);
            command.Parameters.AddWithValue("@Stock", product.Stock); //Framework kullanıldığında bunlar otomatik yapılıyor zaten. Onu bildiğimizde bunları sürkeli yazmaya gerek yok.

            command.ExecuteNonQuery();// etkilenen kayıt sayısını döndürür. kayt oldu mu olmadı mı kontrolü yapmak için kullanılabiliyor.
            _connection.Close();

            // bu işlemleri yaptıktan sonra da, form 1 içerisine gidebiliriz.


        }

       

        public void Update(Product product)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand(
                "Update Products set Name=@name, Price=@Price, Stock=@Stock where Id=@id", _connection);
            // Burası çok önemlidir. Update işlemini bu şekilde yapıyoruz. Ama, Where koşulunu yazmadan asla yapma çünkü tüm kayıtlı verileri değiştirir. 
            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@Price", product.Price);
            command.Parameters.AddWithValue("@Stock", product.Stock);
            command.Parameters.AddWithValue("@id", product.Id);            // Burada da id'yi nereden alacağını belirliyoruz.
            command.ExecuteNonQuery();

            _connection.Close();
        }


        public void Delete(int id) // silme işlemini id üzerinden yapacağımız için, parametremizi int id olarak isteyeceğiz.
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand(
                "Delete from Products where Id=@id", _connection);
            

            command.Parameters.AddWithValue("@id", id);           
            command.ExecuteNonQuery();

            _connection.Close();
        }








        public DataTable GetAll3()
        {
            //burada ürünleri listeleyen kodları yazacağız.
            // ilk kullanmamız gereken kod SqlConection kod sınıfıdır.
            // SqlConnection parantez içerisine de parametreleri yani bağlantı bilgilerini yazıyoruz.
            // [1] Hangi veri Tabanına (server = SQL server object explorer de yazan local db ile başlayan ismi yazıyoruz.)
            // [2] initial catalog: hangi veritabanına bağlanacağımızı belirler. bizim yapmış olduumuz Trade veritabanına bağlanacak.
            // integrated security ise, windows açıldığında bağlan demek. bunu da true yapıyoruz. 
            // false yaparsak eğer, kullanıcı adı şifre gibi parametreleride belirlememiz gerekiyor.
            // uzaktaki bir veritabanına bağlanmak istersek false yapıyoruz.
          //  SqlConnection connection = new SqlConnection(@"server=(localdb)\MSSQLLocalDB; initial catalog=Trade; integrated security=true"); //integrated security=false;uid=engin;password=12345 
            if (_connection.State == ConnectionState.Closed)  // burada da bağlantı işlemi yapıldıysa tekrar bağlanmaması için, bağlantı kapalı ise aç işlemini yaptırıyoruz.
            {
                _connection.Open();
            }
            SqlCommand command = new SqlCommand("Select * from Products", _connection); // buradaki sorguyu da connection'a gönderiyoruz.
            SqlDataReader reader = command.ExecuteReader();  // bu executeReader sınıfı yardımıyla komutu çalıştırabiliyoruz. diğerlerinde değişkenlik gösteiyoruz.

            DataTable dataTable = new DataTable();
            dataTable.Load(reader);

            reader.Close();
            _connection.Close();
            return dataTable;

        }

    }
}
