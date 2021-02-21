using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkdAndLINQDemo
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
            LoadProduct();


        }

        private void LoadProduct()
        {
            dataGridView1.DataSource = _productDal.GetAll();
            trackBar1.Maximum = 10000;
            trackBar1.Minimum = 0;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            _productDal.Add(new Product
            {
                Name = txbName.Text,
                Price = Convert.ToDecimal(txbPrice.Text),
                Stock = Convert.ToInt32(txbPrice.Text)

            });
            LoadProduct();
            MessageBox.Show("Added!");

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            _productDal.Update(new Product
            {
                Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value),
                Name = txbNameUpdate.Text,
                Price = Convert.ToDecimal(txbPriceUpdate.Text),
                Stock = Convert.ToInt32(txbStockUpdate.Text)

            });
            LoadProduct();
            MessageBox.Show("Updated!");



        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txbNameUpdate.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txbPriceUpdate.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txbStockUpdate.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();



        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            _productDal.Delete(new Product
            {
                Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value)
            }) ;
            LoadProduct();
            MessageBox.Show("Deleted!");

        }

        private void txbSearch_TextChanged(object sender, EventArgs e)
        {
            SearchProducts(txbSearch.Text);
        }

        private void SearchProducts(string key)
        {
            var result = _productDal.GetByName(key);
            dataGridView1.DataSource = result;

            
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
         
            lblLevelPrice.Text = trackBar1.Value.ToString();


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchByPriceProducts(Convert.ToDecimal(trackBar1.Value));

        }

        private void SearchByPriceProducts(decimal price)
        {
            var result = _productDal.GetByPrice(price);
            dataGridView1.DataSource = result;
        }
    }
}
