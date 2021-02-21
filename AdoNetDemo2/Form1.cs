using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoNetDemo2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ProductDal _productDal = new ProductDal();
        private void Form1_Load(object sender, EventArgs e)
        {
            // ProductDal productDal = new ProductDal();   
            // ProductDal nesnesini sürekli Newlemek yerine methodun üstüne yazabiliriz.
            LoadProducts();//datagridViewin veri kaynağı olarak ProductDal daki GetAll metodunuu gösterdik
            // buradaki gridView'i bir method haline getirip, butona basılıp ekleme işlemi yapıldıktan sonra 
           // tekrardan eklenen nesneyi görmek için kullanabiliriz.


        }

        private void LoadProducts()
        {
            dataGridView1.DataSource = _productDal.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productDal.Add(new Product
            { 
                Name = tbxName.Text,
                Price = Convert.ToDecimal(tbxPrice.Text),
                Stock = Convert.ToInt32(tbxStock.Text)
            });
            LoadProducts();

            MessageBox.Show("Product Added!");

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // GricView içerisinde bir satırı seçtiğimde veya bir hücreyi seçtiğimde, seçtiğim satırın
            // veya hücrenin, Update a Product içerisindeki istediğim textboxlara gelmesini istiyorum. 
            // bunun içinde, GridView içerisinde bir eylem gerçekleştiriyor olmam gerek yani, gridview'e 
            // bir tıklama işlemi gibi bir eylem gerçeklişitiyor olmam lazım. bunun için gerekli kodları buraya yazıyoruz. 
            // bu kısım, hücrenin içerisindeki yazıya tılandığında seçer ama ben hücreyi seçtiğimde gelmesini istediğim için
            // CellClick işlemi yapmam lazım. bunun için aşağıdaki işlemi yapmalıyım.
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxNameUpdate.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString(); // gridin , currentRow -> seçili satırını, 1. değerini 0-> id , 1-> name
            tbxPriceUpdate.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            tbxStockUpdate.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Product product = new Product 
            { 

                Id    = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value), // Buradaki Id'yi gridden alıyoruz. Kullanıcının değiştirmesiin istemiyoruz.
                Name  = tbxNameUpdate.Text,
                Price = Convert.ToDecimal(tbxPriceUpdate.Text),
                Stock = Convert.ToInt32(tbxStockUpdate.Text),

                
            };

            _productDal.Update(product); // burada da productu gönderidk
            LoadProducts();
            MessageBox.Show("Updated!");


        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value); // silme işlemini id üzerinden
            // yapacağımız için id'ye de buradan ulaşıp id field'ine atıyoruz.

            _productDal.Delete(id);
            LoadProducts();
            MessageBox.Show("Deleted!");
        }
    }
}
