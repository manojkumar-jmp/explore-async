using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Demo.Business;
using Demo.Business.Contracts;

namespace Demo.WinForms.UI.Forms
{
    public partial class ProductList : Form
    {
        private readonly IProductService _productService;
        public ProductList()
        {
            InitializeComponent();

            _productService = new ProductService();

        }

        private void btnLoadProducts_Click(object sender, EventArgs e)
        {
            dataGridViewProducts.DataSource = _productService.GetAllProducts();

        }
    }
}
