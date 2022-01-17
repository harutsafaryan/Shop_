using Data.Models;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Products
{
    public partial class Shop : Form
    {
        private readonly IProductService _productService;

        public Shop(IProductService productService)
        {
            _productService = productService;
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Product product = new Product()
            {
                Name = txtName.Text.ToString(),
                Price = decimal.Parse(txtPrice.Text.ToString())
            };

            _productService.Add(product);

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Product product = new Product()
            {
                Id = (Guid)grdProduct.SelectedRows[0].Cells["Id"].Value,
                Name = txtName.Text,
                Price = decimal.Parse(txtPrice.Text.ToString()),
            };
            _productService.Update(product);
            RefreshProducts();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (grdProduct.SelectedRows.Count == 0)
                return;
            else
            {
                _productService.Remove((Guid)grdProduct.SelectedRows[0].Cells[0].Value);
                RefreshProducts();
            }
        }

        private void RefreshProducts()
        {
            grdProduct.ClearSelection();
            grdProduct.DataSource = _productService.GetAll();
            if (grdProduct.Rows.Count > 0)
            {
                grdProduct.Rows[0].Selected = true;
            }
            //richTextBoxTeacher.Text = File.ReadAllText("C:\\University\\teacher.xml");
        }
    }
}
