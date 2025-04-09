using StockManagementSystem.Models;
using StockManagementSystem.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StockManagementSystem
{
    public partial class StockTransactionForm : Form
    {
        private readonly StockTransactionRepository _transactionRepository;
        private readonly ProductRepository _productRepository;
        private readonly TransactionType _transactionType;

        public StockTransactionForm(AppDbContext dbContext, TransactionType transactionType)
        {
            InitializeComponent();
            
            _transactionRepository = new StockTransactionRepository(dbContext);
            _productRepository = new ProductRepository(dbContext);
            _transactionType = transactionType;

            // Set up event handlers
            this.Load += StockTransactionForm_Load;
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        private void StockTransactionForm_Load(object sender, EventArgs e)
        {
            // Set up form based on transaction type
            this.Text = _transactionType == TransactionType.StockIn ? "Stock In" : "Stock Out";
            lblQuantity.Text = $"{(_transactionType == TransactionType.StockIn ? "Stock In" : "Stock Out")} Quantity:";

            // Load products for ComboBox
            var products = _productRepository.GetAll().ToList();
            cboProduct.DataSource = products;
            cboProduct.DisplayMember = "Name";
            cboProduct.ValueMember = "Id";
            
            // Default to current date
            dtpTransactionDate.Value = DateTime.Now;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input
                if (cboProduct.SelectedItem == null)
                {
                    MessageBox.Show("Please select a product.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (numQuantity.Value <= 0)
                {
                    MessageBox.Show("Quantity must be greater than zero.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    numQuantity.Focus();
                    return;
                }

                // If it's a stock out, check if we have enough inventory
                var product = cboProduct.SelectedItem as Product;
                if (_transactionType == TransactionType.StockOut && product.CurrentStock < numQuantity.Value)
                {
                    MessageBox.Show($"Not enough stock available. Current stock: {product.CurrentStock}", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Create the transaction
                _transactionRepository.AddStockTransaction(
                    (int)cboProduct.SelectedValue,
                    _transactionType,
                    (int)numQuantity.Value,
                    txtReference.Text,
                    txtNotes.Text,
                    Environment.UserName);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating transaction: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            this.labelProduct = new System.Windows.Forms.Label();
            this.cboProduct = new System.Windows.Forms.ComboBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.labelReference = new System.Windows.Forms.Label();
            this.txtReference = new System.Windows.Forms.TextBox();
            this.labelNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.labelTransactionDate = new System.Windows.Forms.Label();
            this.dtpTransactionDate = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.SuspendLayout();

            // labelProduct
            this.labelProduct.AutoSize = true;
            this.labelProduct.Location = new System.Drawing.Point(12, 15);
            this.labelProduct.Name = "labelProduct";
            this.labelProduct.Size = new System.Drawing.Size(47, 13);
            this.labelProduct.TabIndex = 0;
            this.labelProduct.Text = "Product:";

            // cboProduct
            this.cboProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProduct.FormattingEnabled = true;
            this.cboProduct.Location = new System.Drawing.Point(120, 12);
            this.cboProduct.Name = "cboProduct";
            this.cboProduct.Size = new System.Drawing.Size(250, 21);
            this.cboProduct.TabIndex = 1;

            // lblQuantity
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(12, 42);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(49, 13);
            this.lblQuantity.TabIndex = 2;
            this.lblQuantity.Text = "Quantity:";

            // numQuantity
            this.numQuantity.Location = new System.Drawing.Point(120, 40);
            this.numQuantity.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(250, 20);
            this.numQuantity.TabIndex = 3;
            this.numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });

            // labelReference
            this.labelReference.AutoSize = true;
            this.labelReference.Location = new System.Drawing.Point(12, 68);
            this.labelReference.Name = "labelReference";
            this.labelReference.Size = new System.Drawing.Size(60, 13);
            this.labelReference.TabIndex = 4;
            this.labelReference.Text = "Reference:";

            // txtReference
            this.txtReference.Location = new System.Drawing.Point(120, 65);
            this.txtReference.Name = "txtReference";
            this.txtReference.Size = new System.Drawing.Size(250, 20);
            this.txtReference.TabIndex = 5;

            // labelNotes
            this.labelNotes.AutoSize = true;
            this.labelNotes.Location = new System.Drawing.Point(12, 94);
            this.labelNotes.Name = "labelNotes";
            this.labelNotes.Size = new System.Drawing.Size(38, 13);
            this.labelNotes.TabIndex = 6;
            this.labelNotes.Text = "Notes:";

            // txtNotes
            this.txtNotes.Location = new System.Drawing.Point(120, 91);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(250, 60);
            this.txtNotes.TabIndex = 7;

            // labelTransactionDate
            this.labelTransactionDate.AutoSize = true;
            this.labelTransactionDate.Location = new System.Drawing.Point(12, 163);
            this.labelTransactionDate.Name = "labelTransactionDate";
            this.labelTransactionDate.Size = new System.Drawing.Size(96, 13);
            this.labelTransactionDate.TabIndex = 8;
            this.labelTransactionDate.Text = "Transaction Date:";

            // dtpTransactionDate
            this.dtpTransactionDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTransactionDate.Location = new System.Drawing.Point(120, 160);
            this.dtpTransactionDate.Name = "dtpTransactionDate";
            this.dtpTransactionDate.Size = new System.Drawing.Size(250, 20);
            this.dtpTransactionDate.TabIndex = 9;

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(120, 200);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(201, 200);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;

            // StockTransactionForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 241);
            this.Controls.Add(this.labelProduct);
            this.Controls.Add(this.cboProduct);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.labelReference);
            this.Controls.Add(this.txtReference);
            this.Controls.Add(this.labelNotes);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.labelTransactionDate);
            this.Controls.Add(this.dtpTransactionDate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StockTransactionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Stock Transaction";
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelProduct;
        private System.Windows.Forms.ComboBox cboProduct;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Label labelReference;
        private System.Windows.Forms.TextBox txtReference;
        private System.Windows.Forms.Label labelNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label labelTransactionDate;
        private System.Windows.Forms.DateTimePicker dtpTransactionDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
} 