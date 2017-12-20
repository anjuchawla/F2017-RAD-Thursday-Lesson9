using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductMaintenance
{
    public partial class frmMain : Form
    {
        private List<Product> products = null;
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            products = ProductDB.GetProducts();
            FillProductListBox();

        }

        private void FillProductListBox()
        {
            lstProducts.Items.Clear();
            foreach (Product product in products)
            {
                lstProducts.Items.Add(product.GetDisplay("\t"));
            }

        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            int selectedPosition = lstProducts.SelectedIndex;
            Product p;

            if (selectedPosition != -1)
            {
                DialogResult confirm = MessageBox.Show("Do you want to delete selected product?",
                    "Cofirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1);
                if (confirm == DialogResult.Yes)
                {
                   // lstProducts.Items.RemoveAt(selectedPosition);
                    products.RemoveAt(selectedPosition);
                    ProductDB.SaveProducts(products);
                    FillProductListBox();

                }
            }
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            frmNewProduct addProduct = new frmNewProduct();
            addProduct.ShowDialog();
            Product p = addProduct.GetNewProduct();

            if (p != null)
            {
                products.Add(p);
                ProductDB.SaveProducts(products);
                FillProductListBox();

            }

        }
    }
}
