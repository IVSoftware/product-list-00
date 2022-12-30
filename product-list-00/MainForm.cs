﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace product_list_00
{
    public partial class MainForm : Form
    {
        public MainForm() => InitializeComponent();
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            dataGridView.AllowUserToAddRows = false;
            dataGridView.DataSource = Products;

            #region F O R M A T    C O L U M N S
            DataGridViewColumn col;
            Products.Add(new Product());
            dataGridView.Columns[nameof(Product.Name)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns[nameof(Product.Barcode)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            col = dataGridView.Columns[nameof(Product.Price)];
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            col.DefaultCellStyle.Format = "N2";
            col = new DataGridViewButtonColumn{
                Text = "Save",
                UseColumnTextForButtonValue = true,
                Width = 75,
                FlatStyle = FlatStyle.Flat
            };
            col.DefaultCellStyle.BackColor = Color.AliceBlue;
            dataGridView.Columns.Add(col);
            col = new DataGridViewButtonColumn
            {
                Text = "Delete",
                UseColumnTextForButtonValue = true,
                Width = 75,
                FlatStyle = FlatStyle.Flat
            };
            col.DefaultCellStyle.BackColor = Color.AliceBlue;
            dataGridView.Columns.Add(col);
            Products.Clear();
            #endregion F O R M A T    C O L U M N S

            // Add a few products
            Products.Add(new Product { Name = "Coffee", Price = 3.99 });
            Products.Add(new Product { Name = "Milk", Price = 5.49 });
            Products.Add(new Product { Name = "Eggs", Price = 4.29 });
        }
        BindingList<Product> Products = new BindingList<Product>();
    }
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Barcode { get; set; } = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
    }
}
