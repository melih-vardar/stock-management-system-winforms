using StockManagementSystem.Models;
using StockManagementSystem.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StockManagementSystem
{
    public partial class PurchaseOrderForm : Form
    {
        private readonly AppDbContext _dbContext;
        private readonly PurchaseOrderRepository _orderRepository;
        private readonly ProductRepository _productRepository;
        private readonly PurchaseOrder _order;
        private List<PurchaseOrderItem> _orderItems;

        public PurchaseOrderForm(AppDbContext dbContext)
        {
            InitializeComponent();
            
            _dbContext = dbContext;
            _orderRepository = new PurchaseOrderRepository(dbContext);
            _productRepository = new ProductRepository(dbContext);
            _order = new PurchaseOrder();
            _orderItems = new List<PurchaseOrderItem>();

            // Set up event handlers
            this.Load += PurchaseOrderForm_Load;
            btnAddItem.Click += BtnAddItem_Click;
            btnRemoveItem.Click += BtnRemoveItem_Click;
            btnSubmit.Click += BtnSubmit_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        private void PurchaseOrderForm_Load(object sender, EventArgs e)
        {
            // Load products for ComboBox
            var products = _productRepository.GetAll().ToList();
            cboProduct.DataSource = products;
            cboProduct.DisplayMember = "Name";
            cboProduct.ValueMember = "Id";
            
            // Set default dates
            dtpOrderDate.Value = DateTime.Now;
            dtpExpectedDelivery.Value = DateTime.Now.AddDays(7);
            
            // Setup order items grid
            RefreshOrderItemsGrid();
        }

        private void RefreshOrderItemsGrid()
        {
            dgvOrderItems.DataSource = null;
            dgvOrderItems.DataSource = _orderItems.ToList();
            
            if (dgvOrderItems.Columns.Contains("Id"))
                dgvOrderItems.Columns["Id"].Visible = false;
                
            if (dgvOrderItems.Columns.Contains("PurchaseOrderId"))
                dgvOrderItems.Columns["PurchaseOrderId"].Visible = false;
                
            if (dgvOrderItems.Columns.Contains("PurchaseOrder"))
                dgvOrderItems.Columns["PurchaseOrder"].Visible = false;
                
            if (dgvOrderItems.Columns.Contains("Product"))
                dgvOrderItems.Columns["Product"].Visible = false;
                
            // Calculate total
            decimal total = _orderItems.Sum(item => item.TotalPrice);
            lblTotal.Text = $"Total: {total:C}";
        }

        private void BtnAddItem_Click(object sender, EventArgs e)
        {
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

            var product = cboProduct.SelectedItem as Product;
            
            // Check if product already exists in order
            var existingItem = _orderItems.FirstOrDefault(item => item.ProductId == product.Id);
            
            if (existingItem != null)
            {
                // Update existing item
                existingItem.Quantity += (int)numQuantity.Value;
                MessageBox.Show("Product quantity updated in order.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Add new item
                var orderItem = new PurchaseOrderItem
                {
                    ProductId = product.Id,
                    Product = product,
                    Quantity = (int)numQuantity.Value,
                    UnitPrice = product.UnitPrice
                };
                
                _orderItems.Add(orderItem);
            }
            
            // Refresh grid
            RefreshOrderItemsGrid();
            
            // Reset input fields
            cboProduct.SelectedIndex = -1;
            numQuantity.Value = 1;
        }

        private void BtnRemoveItem_Click(object sender, EventArgs e)
        {
            if (dgvOrderItems.CurrentRow == null)
            {
                MessageBox.Show("Please select an item to remove.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            var item = dgvOrderItems.CurrentRow.DataBoundItem as PurchaseOrderItem;
            _orderItems.Remove(item);
            
            // Refresh grid
            RefreshOrderItemsGrid();
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input
                if (string.IsNullOrWhiteSpace(txtOrderNumber.Text))
                {
                    MessageBox.Show("Order number is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtOrderNumber.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtRequestedBy.Text))
                {
                    MessageBox.Show("Requested by is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtRequestedBy.Focus();
                    return;
                }

                if (_orderItems.Count == 0)
                {
                    MessageBox.Show("At least one item must be added to the order.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Create purchase order
                _order.OrderNumber = txtOrderNumber.Text;
                _order.OrderDate = dtpOrderDate.Value;
                _order.ExpectedDeliveryDate = dtpExpectedDelivery.Value;
                _order.Status = OrderStatus.Draft;
                _order.Notes = txtNotes.Text;
                _order.RequestedBy = txtRequestedBy.Text;
                _order.TotalAmount = _orderItems.Sum(item => item.TotalPrice);

                // Add to database
                _orderRepository.Add(_order);
                _orderRepository.SaveChanges();

                // Now add order items with the order ID
                foreach (var item in _orderItems)
                {
                    item.PurchaseOrderId = _order.Id;
                    _dbContext.Set<PurchaseOrderItem>().Add(item);
                }
                _dbContext.SaveChanges();

                // Ask if user wants to submit order
                var result = MessageBox.Show("Purchase order created successfully. Would you like to submit it for approval now?", 
                    "Order Created", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    
                if (result == DialogResult.Yes)
                {
                    _order.Status = OrderStatus.Submitted;
                    _dbContext.SaveChanges();
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            this.labelOrderNumber = new System.Windows.Forms.Label();
            this.txtOrderNumber = new System.Windows.Forms.TextBox();
            this.labelOrderDate = new System.Windows.Forms.Label();
            this.dtpOrderDate = new System.Windows.Forms.DateTimePicker();
            this.labelExpDelivery = new System.Windows.Forms.Label();
            this.dtpExpectedDelivery = new System.Windows.Forms.DateTimePicker();
            this.labelRequestedBy = new System.Windows.Forms.Label();
            this.txtRequestedBy = new System.Windows.Forms.TextBox();
            this.labelNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.groupBoxItems = new System.Windows.Forms.GroupBox();
            this.labelProduct = new System.Windows.Forms.Label();
            this.cboProduct = new System.Windows.Forms.ComboBox();
            this.labelQuantity = new System.Windows.Forms.Label();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.dgvOrderItems = new System.Windows.Forms.DataGridView();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).BeginInit();
            this.groupBoxItems.SuspendLayout();
            this.SuspendLayout();

            // labelOrderNumber
            this.labelOrderNumber.AutoSize = true;
            this.labelOrderNumber.Location = new System.Drawing.Point(12, 15);
            this.labelOrderNumber.Name = "labelOrderNumber";
            this.labelOrderNumber.Size = new System.Drawing.Size(76, 13);
            this.labelOrderNumber.TabIndex = 0;
            this.labelOrderNumber.Text = "Order Number:";

            // txtOrderNumber
            this.txtOrderNumber.Location = new System.Drawing.Point(120, 12);
            this.txtOrderNumber.Name = "txtOrderNumber";
            this.txtOrderNumber.Size = new System.Drawing.Size(250, 20);
            this.txtOrderNumber.TabIndex = 1;

            // labelOrderDate
            this.labelOrderDate.AutoSize = true;
            this.labelOrderDate.Location = new System.Drawing.Point(12, 41);
            this.labelOrderDate.Name = "labelOrderDate";
            this.labelOrderDate.Size = new System.Drawing.Size(62, 13);
            this.labelOrderDate.TabIndex = 2;
            this.labelOrderDate.Text = "Order Date:";

            // dtpOrderDate
            this.dtpOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpOrderDate.Location = new System.Drawing.Point(120, 38);
            this.dtpOrderDate.Name = "dtpOrderDate";
            this.dtpOrderDate.Size = new System.Drawing.Size(250, 20);
            this.dtpOrderDate.TabIndex = 3;

            // labelExpDelivery
            this.labelExpDelivery.AutoSize = true;
            this.labelExpDelivery.Location = new System.Drawing.Point(12, 67);
            this.labelExpDelivery.Name = "labelExpDelivery";
            this.labelExpDelivery.Size = new System.Drawing.Size(108, 13);
            this.labelExpDelivery.TabIndex = 4;
            this.labelExpDelivery.Text = "Expected Delivery Date:";

            // dtpExpectedDelivery
            this.dtpExpectedDelivery.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExpectedDelivery.Location = new System.Drawing.Point(120, 64);
            this.dtpExpectedDelivery.Name = "dtpExpectedDelivery";
            this.dtpExpectedDelivery.Size = new System.Drawing.Size(250, 20);
            this.dtpExpectedDelivery.TabIndex = 5;

            // labelRequestedBy
            this.labelRequestedBy.AutoSize = true;
            this.labelRequestedBy.Location = new System.Drawing.Point(12, 93);
            this.labelRequestedBy.Name = "labelRequestedBy";
            this.labelRequestedBy.Size = new System.Drawing.Size(75, 13);
            this.labelRequestedBy.TabIndex = 6;
            this.labelRequestedBy.Text = "Requested By:";

            // txtRequestedBy
            this.txtRequestedBy.Location = new System.Drawing.Point(120, 90);
            this.txtRequestedBy.Name = "txtRequestedBy";
            this.txtRequestedBy.Size = new System.Drawing.Size(250, 20);
            this.txtRequestedBy.TabIndex = 7;

            // labelNotes
            this.labelNotes.AutoSize = true;
            this.labelNotes.Location = new System.Drawing.Point(12, 119);
            this.labelNotes.Name = "labelNotes";
            this.labelNotes.Size = new System.Drawing.Size(38, 13);
            this.labelNotes.TabIndex = 8;
            this.labelNotes.Text = "Notes:";

            // txtNotes
            this.txtNotes.Location = new System.Drawing.Point(120, 116);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(250, 60);
            this.txtNotes.TabIndex = 9;

            // groupBoxItems
            this.groupBoxItems.Controls.Add(this.labelProduct);
            this.groupBoxItems.Controls.Add(this.cboProduct);
            this.groupBoxItems.Controls.Add(this.labelQuantity);
            this.groupBoxItems.Controls.Add(this.numQuantity);
            this.groupBoxItems.Controls.Add(this.btnAddItem);
            this.groupBoxItems.Controls.Add(this.dgvOrderItems);
            this.groupBoxItems.Controls.Add(this.btnRemoveItem);
            this.groupBoxItems.Controls.Add(this.lblTotal);
            this.groupBoxItems.Location = new System.Drawing.Point(12, 186);
            this.groupBoxItems.Name = "groupBoxItems";
            this.groupBoxItems.Size = new System.Drawing.Size(620, 264);
            this.groupBoxItems.TabIndex = 10;
            this.groupBoxItems.TabStop = false;
            this.groupBoxItems.Text = "Order Items";

            // labelProduct
            this.labelProduct.AutoSize = true;
            this.labelProduct.Location = new System.Drawing.Point(6, 22);
            this.labelProduct.Name = "labelProduct";
            this.labelProduct.Size = new System.Drawing.Size(47, 13);
            this.labelProduct.TabIndex = 0;
            this.labelProduct.Text = "Product:";

            // cboProduct
            this.cboProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProduct.FormattingEnabled = true;
            this.cboProduct.Location = new System.Drawing.Point(74, 19);
            this.cboProduct.Name = "cboProduct";
            this.cboProduct.Size = new System.Drawing.Size(200, 21);
            this.cboProduct.TabIndex = 1;

            // labelQuantity
            this.labelQuantity.AutoSize = true;
            this.labelQuantity.Location = new System.Drawing.Point(280, 22);
            this.labelQuantity.Name = "labelQuantity";
            this.labelQuantity.Size = new System.Drawing.Size(49, 13);
            this.labelQuantity.TabIndex = 2;
            this.labelQuantity.Text = "Quantity:";

            // numQuantity
            this.numQuantity.Location = new System.Drawing.Point(335, 20);
            this.numQuantity.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(120, 20);
            this.numQuantity.TabIndex = 3;
            this.numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });

            // btnAddItem
            this.btnAddItem.Location = new System.Drawing.Point(461, 18);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(75, 23);
            this.btnAddItem.TabIndex = 4;
            this.btnAddItem.Text = "Add";
            this.btnAddItem.UseVisualStyleBackColor = true;

            // dgvOrderItems
            this.dgvOrderItems.AllowUserToAddRows = false;
            this.dgvOrderItems.AllowUserToDeleteRows = false;
            this.dgvOrderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderItems.Location = new System.Drawing.Point(9, 50);
            this.dgvOrderItems.Name = "dgvOrderItems";
            this.dgvOrderItems.ReadOnly = true;
            this.dgvOrderItems.Size = new System.Drawing.Size(605, 179);
            this.dgvOrderItems.TabIndex = 5;

            // btnRemoveItem
            this.btnRemoveItem.Location = new System.Drawing.Point(539, 235);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveItem.TabIndex = 6;
            this.btnRemoveItem.Text = "Remove";
            this.btnRemoveItem.UseVisualStyleBackColor = true;

            // lblTotal
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(9, 240);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(69, 13);
            this.lblTotal.TabIndex = 7;
            this.lblTotal.Text = "Total: $0.00";

            // btnSubmit
            this.btnSubmit.Location = new System.Drawing.Point(476, 456);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 11;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(557, 456);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;

            // PurchaseOrderForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 491);
            this.Controls.Add(this.labelOrderNumber);
            this.Controls.Add(this.txtOrderNumber);
            this.Controls.Add(this.labelOrderDate);
            this.Controls.Add(this.dtpOrderDate);
            this.Controls.Add(this.labelExpDelivery);
            this.Controls.Add(this.dtpExpectedDelivery);
            this.Controls.Add(this.labelRequestedBy);
            this.Controls.Add(this.txtRequestedBy);
            this.Controls.Add(this.labelNotes);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.groupBoxItems);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PurchaseOrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create Purchase Order";
            this.groupBoxItems.ResumeLayout(false);
            this.groupBoxItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelOrderNumber;
        private System.Windows.Forms.TextBox txtOrderNumber;
        private System.Windows.Forms.Label labelOrderDate;
        private System.Windows.Forms.DateTimePicker dtpOrderDate;
        private System.Windows.Forms.Label labelExpDelivery;
        private System.Windows.Forms.DateTimePicker dtpExpectedDelivery;
        private System.Windows.Forms.Label labelRequestedBy;
        private System.Windows.Forms.TextBox txtRequestedBy;
        private System.Windows.Forms.Label labelNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.GroupBox groupBoxItems;
        private System.Windows.Forms.Label labelProduct;
        private System.Windows.Forms.ComboBox cboProduct;
        private System.Windows.Forms.Label labelQuantity;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.DataGridView dgvOrderItems;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
    }
} 