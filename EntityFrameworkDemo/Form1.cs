using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkDemo
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
            LoadProducts();

        }

        private void LoadProducts()
        {
            dataGridView1.DataSource = _productDal.GetAll(); // ürünleri yükleyen kod.
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productDal.Add(new Product
            {
                Name = tbxName.Text,
                Price = Convert.ToDecimal(tbxPrice.Text),
                Stock = Convert.ToInt32(tbxStock.Text)
            }) ;
            LoadProducts();
            MessageBox.Show("Added!");
        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _productDal.Update(new Product
            {
                Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value), // Buradaki Id'yi gridden alıyoruz. Kullanıcının değiştirmesiin istemiyoruz.
                Name = tbxNameUpdate.Text,
                Price = Convert.ToDecimal(tbxPriceUpdate.Text),
                Stock = Convert.ToInt32(tbxStockUpdate.Text),
            });
            LoadProducts();
            MessageBox.Show("Updated!");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxNameUpdate.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString(); // gridin , currentRow -> seçili satırını, 1. değerini 0-> id , 1-> name
            tbxPriceUpdate.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            tbxStockUpdate.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            _productDal.Delete(new Product
            { 
            Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value)
            
            });
            LoadProducts();
            MessageBox.Show("Deleted!");
        }

        private void txbSearch_TextChanged(object sender, EventArgs e)
        {
            SearchProducts(txbSearch.Text);
        }

        private void SearchProducts(string key) // içerisine de parametre giriyoruz. Arama anahtarı. Arama anahtarımı string olarak belirttik.
        {
              //var result = _productDal.GetAll().Where(p=>p.Name.ToLower().Contains(key.ToLower())).ToList(); // burada data geiyor. Gelen liste üzerinden where ile filtre yapıyor. Listeye çevirmeden gelmeyebilir.
            var result = _productDal.GetByName(key); //productdal'da bulunanana getbyname vasıtasıyla sorguyu göndermiş olduk
              // p için, isimlerin içeriğine bak textboxa yazılana göre.
            dataGridView1.DataSource = result;

            // Sorgulama işlemini, burada yani, veritabanından sorgulama işlemi bittikten sonra yaparsak, küçük büyük
            // harf sornu olacaktır. L ile bulduğunda küçük l içe bulmayabilir. Bundan dolayı; her zaman veritabanından nesneleri çekerken sorgulama işlemini yapmak daha önemlidir.
            // c# küçük büyük harf duyarlıdır. bunun için; arama yapılacakken, öncelikle isimler küçük harfe çevirilir, ardındanda gelen anahtar sözcükte küçük harfe dönüştürülür.
            
        }

        private void tbxGetById_Click(object sender, EventArgs e)
        {
            _productDal.GetById(1);
        }
    }
}
