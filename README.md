Your question is about **Setting the button text of a DataGridView cell button**. Here's an alternative to the currently accepted answer that uses the `DataSource` property of the `DataGridView` which often makes things easier because you can work with the underlying data directly. In the initialization code below, the `Text` and ` UseColumnTextForButtonValue` properties of the column are used to set "Save" and "Delete" for the buttons.


[![minimal sample][1]][1]

***
The `BindingList<Product>` contains objects of a class you define to represent a row:

    // Minimal product class for example
    class Product
    {
        // Read-only fields for this example.
        public string Name { get; internal set; }
        public double Price { get; internal set; }
        public string Barcode { get; internal set; } =
            $"*{Guid.NewGuid().ToString().Substring(0, 8).ToUpper()}*";
    }

***
Then in the main form, the `Load` event can be used to set up the columns and formatting, including the **button text**.

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        initBarcodeFont();
        dataGridView.AllowUserToAddRows = false;
        dataGridView.DataSource = Products;
        dataGridView.RowTemplate.Height = 100;

        #region F O R M A T    C O L U M N S
        DataGridViewColumn col;
        Products.Add(new Product());
        dataGridView.Columns[nameof(Product.Name)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        col = dataGridView.Columns[nameof(Product.Barcode)];
        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        col.DefaultCellStyle.Font = _barcodeFont;
        col = dataGridView.Columns[nameof(Product.Price)];
        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        col.DefaultCellStyle.Format = "N2";
        col = new DataGridViewButtonColumn{
            Text = "Save",
            UseColumnTextForButtonValue = true,
            Width = 90,
            FlatStyle = FlatStyle.Flat
        };
        col.DefaultCellStyle.BackColor = Color.AliceBlue;
        dataGridView.Columns.Add(col);
        col = new DataGridViewButtonColumn
        {
            Text = "Delete",
            UseColumnTextForButtonValue = true,
            Width = 90,
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
 


  [1]: https://i.stack.imgur.com/rjKtK.png