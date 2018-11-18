using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecapProject1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string key = textBox1.Text;
            if (string.IsNullOrEmpty(key))
            {
                ListProducts();
            }
            else
            {
                ListProductsByProductsName(key);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListCategories();
            ListProducts();

        }

        private void ListProducts()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                dgvProduct.DataSource = context.Products.ToList();
            }
        }

        private void ListCategories()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                cbxCategory.DataSource = context.Categories.ToList();
                cbxCategory.DisplayMember = "CategoryName";
                cbxCategory.ValueMember = "CategoryId";
            }
        }

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ListProductsByCategory(int.Parse(cbxCategory.SelectedValue.ToString()));
            }
            catch
            {

            }
        }

        private void ListProductsByCategory(int categoryId)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                dgvProduct.DataSource = context.Products.Where(x => x.CategoryId == categoryId).ToList();
            }
        }

        private void ListProductsByProductsName(string key)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                dgvProduct.DataSource = context.Products.Where(x => x.ProductName.ToLower().Contains(key.ToLower())).ToList();
            }
        }
    }
}
