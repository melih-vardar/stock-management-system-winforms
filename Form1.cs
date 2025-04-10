using StockManagementSystem.Models;
using StockManagementSystem.Models.Repositories;
using System;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using System.Text;

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
                
                // Test the database connection
                _dbContext.Database.CanConnect();
                
                // Initialize repositories
                _productRepository = new ProductRepository(_dbContext);
                _orderRepository = new PurchaseOrderRepository(_dbContext);
                _transactionRepository = new StockTransactionRepository(_dbContext);

                // Ensure database is created
                _dbContext.Database.EnsureCreated();
                
                // Seed the database with sample data
                if (_dbContext.Products.CountAsync().Result == 0)
                {
                    DbSeeder.SeedData(_dbContext);
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
                
                // Set up menu event handlers
                settingsToolStripMenuItem.Click += SettingsToolStripMenuItem_Click;
                exitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
                stockReportToolStripMenuItem.Click += StockReportToolStripMenuItem_Click;
                transactionReportToolStripMenuItem.Click += TransactionReportToolStripMenuItem_Click;
                ordersReportToolStripMenuItem.Click += OrdersReportToolStripMenuItem_Click;
                aboutToolStripMenuItem.Click += AboutToolStripMenuItem_Click;
            }
            catch (Exception ex)
            {
                string errorMessage = $"Database connection error: {ex.Message}";
                if (ex.InnerException != null)
                {
                    errorMessage += $"\nInner Exception: {ex.InnerException.Message}";
                }
                
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                // Disable controls since we can't connect to the database
                tabControl1.Enabled = false;
            }
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
            
            var order = dgvOrders.CurrentRow.DataBoundItem as PurchaseOrder;
            
            try
            {
                // Load order details with items
                var orderWithItems = _orderRepository.GetPurchaseOrderWithItems(order.Id);
                
                if (orderWithItems == null)
                {
                    MessageBox.Show("Order details could not be loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                // Show order details in a read-only dialog
                string message = $"Order Number: {orderWithItems.OrderNumber}\n" +
                                $"Date: {orderWithItems.OrderDate:d}\n" +
                                $"Expected Delivery: {orderWithItems.ExpectedDeliveryDate:d}\n" +
                                $"Requested By: {orderWithItems.RequestedBy}\n" +
                                $"Status: {orderWithItems.Status}\n" +
                                $"Total Amount: {orderWithItems.TotalAmount:C2}\n\n" +
                                $"Items:\n";
                
                foreach (var item in orderWithItems.OrderItems)
                {
                    message += $"- {item.Product.Name}: {item.Quantity} x {item.UnitPrice:C2} = {item.TotalPrice:C2}\n";
                }
                
                MessageBox.Show(message, $"Order Details - {orderWithItems.OrderNumber}", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading order details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature will allow you to customize application settings.\n\n" +
                "Settings like:\n" +
                "- Database connection\n" +
                "- User preferences\n" +
                "- Notification options", 
                "Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Ask for confirmation before closing the application
            DialogResult result = MessageBox.Show("Are you sure you want to exit the application?", 
                "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void StockReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Get all products
                var products = _productRepository.GetAll();
                
                // Create report string
                StringBuilder reportText = new StringBuilder();
                reportText.AppendLine("STOCK REPORT");
                reportText.AppendLine("===========");
                reportText.AppendLine($"Date: {DateTime.Now:d}");
                reportText.AppendLine();
                reportText.AppendLine("CURRENT STOCK LEVELS:");
                reportText.AppendLine();
                reportText.AppendLine(String.Format("{0,-5} {1,-30} {2,-15} {3,-15} {4,-15}", 
                    "ID", "Product Name", "Current Stock", "Min. Level", "Status"));
                reportText.AppendLine(new string('-', 80));
                
                foreach (var product in products)
                {
                    string status = product.CurrentStock <= product.MinimumStockLevel ? "LOW STOCK" : "OK";
                    reportText.AppendLine(String.Format("{0,-5} {1,-30} {2,-15} {3,-15} {4,-15}", 
                        product.Id, product.Name, product.CurrentStock, product.MinimumStockLevel, status));
                }
                
                // Show report
                MessageBox.Show(reportText.ToString(), "Stock Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating stock report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TransactionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Get recent transactions
                var transactions = _transactionRepository.GetRecentTransactions(50);
                
                // Create report string
                StringBuilder reportText = new StringBuilder();
                reportText.AppendLine("TRANSACTION REPORT");
                reportText.AppendLine("==================");
                reportText.AppendLine($"Date: {DateTime.Now:d}");
                reportText.AppendLine();
                
                decimal totalStockIn = 0;
                decimal totalStockOut = 0;
                
                foreach (var transaction in transactions)
                {
                    if (transaction.Type == TransactionType.StockIn)
                    {
                        totalStockIn += transaction.Quantity;
                    }
                    else
                    {
                        totalStockOut += transaction.Quantity;
                    }
                }
                
                reportText.AppendLine($"Total Stock In: {totalStockIn}");
                reportText.AppendLine($"Total Stock Out: {totalStockOut}");
                reportText.AppendLine($"Net Change: {totalStockIn - totalStockOut}");
                reportText.AppendLine();
                reportText.AppendLine("RECENT TRANSACTIONS:");
                reportText.AppendLine();
                reportText.AppendLine(String.Format("{0,-10} {1,-30} {2,-15} {3,-10} {4,-15}", 
                    "Date", "Product", "Type", "Quantity", "Reference"));
                reportText.AppendLine(new string('-', 80));
                
                foreach (var transaction in transactions)
                {
                    string type = transaction.Type == TransactionType.StockIn ? "Stock In" : "Stock Out";
                    reportText.AppendLine(String.Format("{0,-10} {1,-30} {2,-15} {3,-10} {4,-15}", 
                        transaction.TransactionDate.ToString("d"), 
                        transaction.Product.Name, 
                        type, 
                        transaction.Quantity, 
                        transaction.Reference));
                }
                
                // Show report
                MessageBox.Show(reportText.ToString(), "Transaction Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating transaction report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OrdersReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Get all orders
                var orders = _orderRepository.GetPurchaseOrdersWithItems();
                
                // Create report string
                StringBuilder reportText = new StringBuilder();
                reportText.AppendLine("ORDERS REPORT");
                reportText.AppendLine("=============");
                reportText.AppendLine($"Date: {DateTime.Now:d}");
                reportText.AppendLine();
                
                // Order statistics
                int totalOrders = orders.Count();
                int pendingOrders = orders.Count(o => o.Status == OrderStatus.Submitted);
                int approvedOrders = orders.Count(o => o.Status == OrderStatus.Approved);
                decimal totalValue = orders.Sum(o => o.TotalAmount);
                
                reportText.AppendLine($"Total Orders: {totalOrders}");
                reportText.AppendLine($"Pending Orders: {pendingOrders}");
                reportText.AppendLine($"Approved Orders: {approvedOrders}");
                reportText.AppendLine($"Total Value: {totalValue:C2}");
                reportText.AppendLine();
                reportText.AppendLine("ORDER SUMMARY:");
                reportText.AppendLine();
                reportText.AppendLine(String.Format("{0,-15} {1,-12} {2,-12} {3,-15} {4,-15}", 
                    "Order Number", "Date", "Status", "Requested By", "Total"));
                reportText.AppendLine(new string('-', 80));
                
                foreach (var order in orders)
                {
                    reportText.AppendLine(String.Format("{0,-15} {1,-12} {2,-12} {3,-15} {4,-15}", 
                        order.OrderNumber, 
                        order.OrderDate.ToString("d"), 
                        order.Status, 
                        order.RequestedBy, 
                        $"{order.TotalAmount:C2}"));
                }
                
                // Show report
                MessageBox.Show(reportText.ToString(), "Orders Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating orders report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Stock Management System\n" +
                "Version 1.0\n\n" +
                "This application helps you manage your inventory, track stock movements, and handle purchase orders.\n\n" +
                "Features:\n" +
                "- Product management\n" +
                "- Stock movement tracking\n" +
                "- Purchase order management\n" +
                "- Low stock alerts\n" +
                "- Reporting", 
                "About Stock Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
