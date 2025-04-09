using StockManagementSystem.Models;
using StockManagementSystem.Models.Repositories;
using System;
using System.Windows.Forms;

namespace StockManagementSystem
{
    public partial class Form1 : Form
    {
        private readonly AppDbContext _dbContext;
        private readonly ProductRepository _productRepository;
        private readonly PurchaseOrderRepository _orderRepository;
        private readonly StockTransactionRepository _transactionRepository;

        public Form1()
        {
            InitializeComponent();

            try
            {
                // Initialize the database context and repositories
                _dbContext = DbConfig.CreateDbContext();
                _productRepository = new ProductRepository(_dbContext);
                _orderRepository = new PurchaseOrderRepository(_dbContext);
                _transactionRepository = new StockTransactionRepository(_dbContext);

                // Ensure database is created
                _dbContext.Database.EnsureCreated();
                
                // Seed the database with sample data
                DbSeeder.SeedData(_dbContext);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database connection error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Set up event handlers
            this.Load += Form1_Load;
            btnAddProduct.Click += BtnAddProduct_Click;
            btnEditProduct.Click += BtnEditProduct_Click;
            btnDeleteProduct.Click += BtnDeleteProduct_Click;
            btnStockIn.Click += BtnStockIn_Click;
            btnStockOut.Click += BtnStockOut_Click;
            btnCreateOrder.Click += BtnCreateOrder_Click;
            btnViewOrder.Click += BtnViewOrder_Click;
            btnApproveOrder.Click += BtnApproveOrder_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Load initial data when form loads
            LoadProducts();
            LoadLowStockProducts();
            LoadPendingOrders();
            LoadRecentTransactions();
            LoadAllOrders();
        }

        private void LoadProducts()
        {
            // Implement loading products data to a DataGridView
            try
            {
                var products = _productRepository.GetAll();
                dgvProducts.DataSource = null;
                dgvProducts.DataSource = products;
                
                // Configure columns
                if (dgvProducts.Columns.Contains("Id"))
                    dgvProducts.Columns["Id"].Visible = false;
                
                if (dgvProducts.Columns.Contains("Description"))
                    dgvProducts.Columns["Description"].Visible = false;
                
                // Update status
                statusLabel.Text = $"Loaded {dgvProducts.Rows.Count} products";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLowStockProducts()
        {
            // Implement loading low stock products data to a DataGridView
            try
            {
                var lowStockProducts = _productRepository.GetProductsWithLowStock();
                dgvLowStock.DataSource = null;
                dgvLowStock.DataSource = lowStockProducts;
                
                // Configure columns
                if (dgvLowStock.Columns.Contains("Id"))
                    dgvLowStock.Columns["Id"].Visible = false;
                
                if (dgvLowStock.Columns.Contains("Description"))
                    dgvLowStock.Columns["Description"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading low stock products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPendingOrders()
        {
            // Implement loading pending orders to a DataGridView
            try
            {
                var pendingOrders = _orderRepository.GetPendingApprovalOrders();
                dgvPendingOrders.DataSource = null;
                dgvPendingOrders.DataSource = pendingOrders;
                
                // Configure columns
                if (dgvPendingOrders.Columns.Contains("Id"))
                    dgvPendingOrders.Columns["Id"].Visible = false;
                
                if (dgvPendingOrders.Columns.Contains("Notes"))
                    dgvPendingOrders.Columns["Notes"].Visible = false;
                
                if (dgvPendingOrders.Columns.Contains("OrderItems"))
                    dgvPendingOrders.Columns["OrderItems"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading pending orders: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void LoadAllOrders()
        {
            // Load all purchase orders
            try
            {
                var orders = _orderRepository.GetPurchaseOrdersWithItems();
                dgvOrders.DataSource = null;
                dgvOrders.DataSource = orders;
                
                // Configure columns
                if (dgvOrders.Columns.Contains("Id"))
                    dgvOrders.Columns["Id"].Visible = false;
                
                if (dgvOrders.Columns.Contains("Notes"))
                    dgvOrders.Columns["Notes"].Visible = false;
                
                if (dgvOrders.Columns.Contains("OrderItems"))
                    dgvOrders.Columns["OrderItems"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading orders: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void LoadRecentTransactions()
        {
            // Implement loading recent transactions to a DataGridView
            try
            {
                var recentTransactions = _transactionRepository.GetRecentTransactions(20);
                dgvTransactions.DataSource = null;
                dgvTransactions.DataSource = recentTransactions;
                
                // Configure columns
                if (dgvTransactions.Columns.Contains("Id"))
                    dgvTransactions.Columns["Id"].Visible = false;
                
                if (dgvTransactions.Columns.Contains("Product"))
                    dgvTransactions.Columns["Product"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading transactions: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            using (var form = new ProductForm(_dbContext))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadProducts();
                    LoadLowStockProducts();
                    statusLabel.Text = "Product added successfully";
                }
            }
        }
        
        private void BtnEditProduct_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null)
            {
                MessageBox.Show("Please select a product to edit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            var product = dgvProducts.CurrentRow.DataBoundItem as Product;
            
            using (var form = new ProductForm(_dbContext, product))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadProducts();
                    LoadLowStockProducts();
                    statusLabel.Text = "Product updated successfully";
                }
            }
        }
        
        private void BtnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null)
            {
                MessageBox.Show("Please select a product to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            var product = dgvProducts.CurrentRow.DataBoundItem as Product;
            
            var result = MessageBox.Show($"Are you sure you want to delete product '{product.Name}'?", 
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
            if (result == DialogResult.Yes)
            {
                try
                {
                    _productRepository.Remove(product);
                    _productRepository.SaveChanges();
                    
                    LoadProducts();
                    LoadLowStockProducts();
                    statusLabel.Text = "Product deleted successfully";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        private void BtnStockIn_Click(object sender, EventArgs e)
        {
            using (var form = new StockTransactionForm(_dbContext, TransactionType.StockIn))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadProducts();
                    LoadLowStockProducts();
                    LoadRecentTransactions();
                    statusLabel.Text = "Stock in transaction completed successfully";
                }
            }
        }
        
        private void BtnStockOut_Click(object sender, EventArgs e)
        {
            using (var form = new StockTransactionForm(_dbContext, TransactionType.StockOut))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadProducts();
                    LoadLowStockProducts();
                    LoadRecentTransactions();
                    statusLabel.Text = "Stock out transaction completed successfully";
                }
            }
        }
        
        private void BtnCreateOrder_Click(object sender, EventArgs e)
        {
            using (var form = new PurchaseOrderForm(_dbContext))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadPendingOrders();
                    LoadAllOrders();
                    statusLabel.Text = "Purchase order created successfully";
                }
            }
        }
        
        private void BtnViewOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow == null)
            {
                MessageBox.Show("Please select an order to view.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            // To be implemented in a future version
            MessageBox.Show("View Order functionality will be implemented in the next phase.", "Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        private void BtnApproveOrder_Click(object sender, EventArgs e)
        {
            if (dgvPendingOrders.CurrentRow == null)
            {
                MessageBox.Show("Please select an order to approve.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            var order = dgvPendingOrders.CurrentRow.DataBoundItem as PurchaseOrder;
            
            var result = MessageBox.Show($"Are you sure you want to approve purchase order '{order.OrderNumber}'?", 
                "Confirm Approval", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
            if (result == DialogResult.Yes)
            {
                try
                {
                    _orderRepository.UpdateOrderStatus(order.Id, OrderStatus.Approved, Environment.UserName);
                    
                    LoadPendingOrders();
                    LoadAllOrders();
                    statusLabel.Text = "Order approved successfully";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error approving order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
