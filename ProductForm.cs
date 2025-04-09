using StockManagementSystem.Models;
using StockManagementSystem.Models.Repositories;
using System;
using System.Windows.Forms;

namespace StockManagementSystem
{
    public partial class ProductForm : Form
    {
        private readonly ProductRepository _productRepository;
        private readonly Product _product;
        private readonly bool _isEdit;

        public ProductForm(AppDbContext dbContext, Product product = null)
        {
            InitializeComponent();
            
            _productRepository = new ProductRepository(dbContext);
            _product = product ?? new Product();
            _isEdit = product != null;

            // Set up event handlers
            this.Load += ProductForm_Load;
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            // Set form caption based on whether we're editing or adding
            this.Text = _isEdit ? "Edit Product" : "Add Product";

            // If editing, populate the form with product data
            if (_isEdit)
            {
                txtName.Text = _product.Name;
                txtDescription.Text = _product.Description;
                txtSKU.Text = _product.SKU;
                txtCategory.Text = _product.Category;
                numUnitPrice.Value = _product.UnitPrice;
                numCurrentStock.Value = _product.CurrentStock;
                numMinimumStock.Value = _product.MinimumStockLevel;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Product name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtName.Focus();
                    return;
                }

                // Update product from form
                _product.Name = txtName.Text;
                _product.Description = txtDescription.Text;
                _product.SKU = txtSKU.Text;
                _product.Category = txtCategory.Text;
                _product.UnitPrice = numUnitPrice.Value;
                _product.CurrentStock = (int)numCurrentStock.Value;
                _product.MinimumStockLevel = (int)numMinimumStock.Value;
                _product.UpdatedAt = DateTime.Now;

                // Save to database
                if (_isEdit)
                {
                    _productRepository.Update(_product);
                }
                else
                {
                    _productRepository.Add(_product);
                }
                _productRepository.SaveChanges();

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #region Windows Form Designer Generated Code

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.labelSKU = new System.Windows.Forms.Label();
            this.txtSKU = new System.Windows.Forms.TextBox();
            this.labelCategory = new System.Windows.Forms.Label();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.labelUnitPrice = new System.Windows.Forms.Label();
            this.numUnitPrice = new System.Windows.Forms.NumericUpDown();
            this.labelCurrentStock = new System.Windows.Forms.Label();
            this.numCurrentStock = new System.Windows.Forms.NumericUpDown();
            this.labelMinStock = new System.Windows.Forms.Label();
            this.numMinimumStock = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.numUnitPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCurrentStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinimumStock)).BeginInit();
            this.SuspendLayout();

            // labelName
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(12, 15);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(35, 13);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Name:";

            // txtName
            this.txtName.Location = new System.Drawing.Point(120, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(250, 20);
            this.txtName.TabIndex = 1;

            // labelDescription
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(12, 41);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(63, 13);
            this.labelDescription.TabIndex = 2;
            this.labelDescription.Text = "Description:";

            // txtDescription
            this.txtDescription.Location = new System.Drawing.Point(120, 38);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(250, 60);
            this.txtDescription.TabIndex = 3;

            // labelSKU
            this.labelSKU.AutoSize = true;
            this.labelSKU.Location = new System.Drawing.Point(12, 111);
            this.labelSKU.Name = "labelSKU";
            this.labelSKU.Size = new System.Drawing.Size(32, 13);
            this.labelSKU.TabIndex = 4;
            this.labelSKU.Text = "SKU:";

            // txtSKU
            this.txtSKU.Location = new System.Drawing.Point(120, 108);
            this.txtSKU.Name = "txtSKU";
            this.txtSKU.Size = new System.Drawing.Size(250, 20);
            this.txtSKU.TabIndex = 5;

            // labelCategory
            this.labelCategory.AutoSize = true;
            this.labelCategory.Location = new System.Drawing.Point(12, 137);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(52, 13);
            this.labelCategory.TabIndex = 6;
            this.labelCategory.Text = "Category:";

            // txtCategory
            this.txtCategory.Location = new System.Drawing.Point(120, 134);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(250, 20);
            this.txtCategory.TabIndex = 7;

            // labelUnitPrice
            this.labelUnitPrice.AutoSize = true;
            this.labelUnitPrice.Location = new System.Drawing.Point(12, 163);
            this.labelUnitPrice.Name = "labelUnitPrice";
            this.labelUnitPrice.Size = new System.Drawing.Size(56, 13);
            this.labelUnitPrice.TabIndex = 8;
            this.labelUnitPrice.Text = "Unit Price:";

            // numUnitPrice
            this.numUnitPrice.DecimalPlaces = 2;
            this.numUnitPrice.Location = new System.Drawing.Point(120, 160);
            this.numUnitPrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.numUnitPrice.Name = "numUnitPrice";
            this.numUnitPrice.Size = new System.Drawing.Size(250, 20);
            this.numUnitPrice.TabIndex = 9;

            // labelCurrentStock
            this.labelCurrentStock.AutoSize = true;
            this.labelCurrentStock.Location = new System.Drawing.Point(12, 189);
            this.labelCurrentStock.Name = "labelCurrentStock";
            this.labelCurrentStock.Size = new System.Drawing.Size(75, 13);
            this.labelCurrentStock.TabIndex = 10;
            this.labelCurrentStock.Text = "Current Stock:";

            // numCurrentStock
            this.numCurrentStock.Location = new System.Drawing.Point(120, 186);
            this.numCurrentStock.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.numCurrentStock.Name = "numCurrentStock";
            this.numCurrentStock.Size = new System.Drawing.Size(250, 20);
            this.numCurrentStock.TabIndex = 11;

            // labelMinStock
            this.labelMinStock.AutoSize = true;
            this.labelMinStock.Location = new System.Drawing.Point(12, 215);
            this.labelMinStock.Name = "labelMinStock";
            this.labelMinStock.Size = new System.Drawing.Size(102, 13);
            this.labelMinStock.TabIndex = 12;
            this.labelMinStock.Text = "Minimum Stock Level:";

            // numMinimumStock
            this.numMinimumStock.Location = new System.Drawing.Point(120, 212);
            this.numMinimumStock.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.numMinimumStock.Name = "numMinimumStock";
            this.numMinimumStock.Size = new System.Drawing.Size(250, 20);
            this.numMinimumStock.TabIndex = 13;

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(120, 250);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(201, 250);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;

            // ProductForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 291);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.labelSKU);
            this.Controls.Add(this.txtSKU);
            this.Controls.Add(this.labelCategory);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.labelUnitPrice);
            this.Controls.Add(this.numUnitPrice);
            this.Controls.Add(this.labelCurrentStock);
            this.Controls.Add(this.numCurrentStock);
            this.Controls.Add(this.labelMinStock);
            this.Controls.Add(this.numMinimumStock);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Product";
            ((System.ComponentModel.ISupportInitialize)(this.numUnitPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCurrentStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinimumStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label labelSKU;
        private System.Windows.Forms.TextBox txtSKU;
        private System.Windows.Forms.Label labelCategory;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.Label labelUnitPrice;
        private System.Windows.Forms.NumericUpDown numUnitPrice;
        private System.Windows.Forms.Label labelCurrentStock;
        private System.Windows.Forms.NumericUpDown numCurrentStock;
        private System.Windows.Forms.Label labelMinStock;
        private System.Windows.Forms.NumericUpDown numMinimumStock;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
} 