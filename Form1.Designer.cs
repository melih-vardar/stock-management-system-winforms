namespace StockManagementSystem;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        tabControl1 = new TabControl();
        tabProducts = new TabPage();
        dgvProducts = new DataGridView();
        btnAddProduct = new Button();
        btnEditProduct = new Button();
        btnDeleteProduct = new Button();
        tabInventory = new TabPage();
        lblLowStock = new Label();
        dgvLowStock = new DataGridView();
        btnStockIn = new Button();
        btnStockOut = new Button();
        dgvTransactions = new DataGridView();
        lblTransactions = new Label();
        tabPurchaseOrders = new TabPage();
        lblPendingOrders = new Label();
        dgvPendingOrders = new DataGridView();
        btnCreateOrder = new Button();
        btnViewOrder = new Button();
        btnApproveOrder = new Button();
        dgvOrders = new DataGridView();
        statusStrip1 = new StatusStrip();
        statusLabel = new ToolStripStatusLabel();
        menuStrip1 = new MenuStrip();
        fileToolStripMenuItem = new ToolStripMenuItem();
        settingsToolStripMenuItem = new ToolStripMenuItem();
        exitToolStripMenuItem = new ToolStripMenuItem();
        reportsToolStripMenuItem = new ToolStripMenuItem();
        stockReportToolStripMenuItem = new ToolStripMenuItem();
        transactionReportToolStripMenuItem = new ToolStripMenuItem();
        ordersReportToolStripMenuItem = new ToolStripMenuItem();
        helpToolStripMenuItem = new ToolStripMenuItem();
        aboutToolStripMenuItem = new ToolStripMenuItem();
        tabControl1.SuspendLayout();
        tabProducts.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
        tabInventory.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvLowStock).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dgvTransactions).BeginInit();
        tabPurchaseOrders.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvPendingOrders).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
        statusStrip1.SuspendLayout();
        menuStrip1.SuspendLayout();
        SuspendLayout();
        // 
        // tabControl1
        // 
        tabControl1.Controls.Add(tabProducts);
        tabControl1.Controls.Add(tabInventory);
        tabControl1.Controls.Add(tabPurchaseOrders);
        tabControl1.Dock = DockStyle.Fill;
        tabControl1.Location = new Point(0, 24);
        tabControl1.Margin = new Padding(4, 3, 4, 3);
        tabControl1.Name = "tabControl1";
        tabControl1.SelectedIndex = 0;
        tabControl1.Size = new Size(933, 473);
        tabControl1.TabIndex = 0;
        // 
        // tabProducts
        // 
        tabProducts.Controls.Add(dgvProducts);
        tabProducts.Controls.Add(btnAddProduct);
        tabProducts.Controls.Add(btnEditProduct);
        tabProducts.Controls.Add(btnDeleteProduct);
        tabProducts.Location = new Point(4, 24);
        tabProducts.Margin = new Padding(4, 3, 4, 3);
        tabProducts.Name = "tabProducts";
        tabProducts.Padding = new Padding(4, 3, 4, 3);
        tabProducts.Size = new Size(925, 445);
        tabProducts.TabIndex = 0;
        tabProducts.Text = "Products";
        tabProducts.UseVisualStyleBackColor = true;
        // 
        // dgvProducts
        // 
        dgvProducts.AllowUserToAddRows = false;
        dgvProducts.AllowUserToDeleteRows = false;
        dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvProducts.Location = new Point(9, 54);
        dgvProducts.Margin = new Padding(4, 3, 4, 3);
        dgvProducts.Name = "dgvProducts";
        dgvProducts.ReadOnly = true;
        dgvProducts.Size = new Size(905, 373);
        dgvProducts.TabIndex = 0;
        // 
        // btnAddProduct
        // 
        btnAddProduct.Location = new Point(9, 18);
        btnAddProduct.Margin = new Padding(4, 3, 4, 3);
        btnAddProduct.Name = "btnAddProduct";
        btnAddProduct.Size = new Size(88, 27);
        btnAddProduct.TabIndex = 1;
        btnAddProduct.Text = "Add";
        btnAddProduct.UseVisualStyleBackColor = true;
        // 
        // btnEditProduct
        // 
        btnEditProduct.Location = new Point(104, 18);
        btnEditProduct.Margin = new Padding(4, 3, 4, 3);
        btnEditProduct.Name = "btnEditProduct";
        btnEditProduct.Size = new Size(88, 27);
        btnEditProduct.TabIndex = 2;
        btnEditProduct.Text = "Edit";
        btnEditProduct.UseVisualStyleBackColor = true;
        // 
        // btnDeleteProduct
        // 
        btnDeleteProduct.Location = new Point(198, 18);
        btnDeleteProduct.Margin = new Padding(4, 3, 4, 3);
        btnDeleteProduct.Name = "btnDeleteProduct";
        btnDeleteProduct.Size = new Size(88, 27);
        btnDeleteProduct.TabIndex = 3;
        btnDeleteProduct.Text = "Delete";
        btnDeleteProduct.UseVisualStyleBackColor = true;
        // 
        // tabInventory
        // 
        tabInventory.Controls.Add(lblLowStock);
        tabInventory.Controls.Add(dgvLowStock);
        tabInventory.Controls.Add(btnStockIn);
        tabInventory.Controls.Add(btnStockOut);
        tabInventory.Controls.Add(dgvTransactions);
        tabInventory.Controls.Add(lblTransactions);
        tabInventory.Location = new Point(4, 24);
        tabInventory.Margin = new Padding(4, 3, 4, 3);
        tabInventory.Name = "tabInventory";
        tabInventory.Padding = new Padding(4, 3, 4, 3);
        tabInventory.Size = new Size(925, 445);
        tabInventory.TabIndex = 1;
        tabInventory.Text = "Inventory";
        tabInventory.UseVisualStyleBackColor = true;
        // 
        // lblLowStock
        // 
        lblLowStock.AutoSize = true;
        lblLowStock.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblLowStock.Location = new Point(9, 18);
        lblLowStock.Margin = new Padding(4, 0, 4, 0);
        lblLowStock.Name = "lblLowStock";
        lblLowStock.Size = new Size(148, 13);
        lblLowStock.TabIndex = 0;
        lblLowStock.Text = "Products with Low Stock";
        // 
        // dgvLowStock
        // 
        dgvLowStock.AllowUserToAddRows = false;
        dgvLowStock.AllowUserToDeleteRows = false;
        dgvLowStock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvLowStock.Location = new Point(9, 37);
        dgvLowStock.Margin = new Padding(4, 3, 4, 3);
        dgvLowStock.Name = "dgvLowStock";
        dgvLowStock.ReadOnly = true;
        dgvLowStock.Size = new Size(905, 115);
        dgvLowStock.TabIndex = 1;
        // 
        // btnStockIn
        // 
        btnStockIn.Location = new Point(733, 159);
        btnStockIn.Margin = new Padding(4, 3, 4, 3);
        btnStockIn.Name = "btnStockIn";
        btnStockIn.Size = new Size(88, 27);
        btnStockIn.TabIndex = 2;
        btnStockIn.Text = "Stock In";
        btnStockIn.UseVisualStyleBackColor = true;
        // 
        // btnStockOut
        // 
        btnStockOut.Location = new Point(827, 159);
        btnStockOut.Margin = new Padding(4, 3, 4, 3);
        btnStockOut.Name = "btnStockOut";
        btnStockOut.Size = new Size(88, 27);
        btnStockOut.TabIndex = 3;
        btnStockOut.Text = "Stock Out";
        btnStockOut.UseVisualStyleBackColor = true;
        // 
        // dgvTransactions
        // 
        dgvTransactions.AllowUserToAddRows = false;
        dgvTransactions.AllowUserToDeleteRows = false;
        dgvTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvTransactions.Location = new Point(9, 193);
        dgvTransactions.Margin = new Padding(4, 3, 4, 3);
        dgvTransactions.Name = "dgvTransactions";
        dgvTransactions.ReadOnly = true;
        dgvTransactions.Size = new Size(905, 237);
        dgvTransactions.TabIndex = 5;
        // 
        // lblTransactions
        // 
        lblTransactions.AutoSize = true;
        lblTransactions.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblTransactions.Location = new Point(9, 165);
        lblTransactions.Margin = new Padding(4, 0, 4, 0);
        lblTransactions.Name = "lblTransactions";
        lblTransactions.Size = new Size(125, 13);
        lblTransactions.TabIndex = 4;
        lblTransactions.Text = "Recent Transactions";
        // 
        // tabPurchaseOrders
        // 
        tabPurchaseOrders.Controls.Add(lblPendingOrders);
        tabPurchaseOrders.Controls.Add(dgvPendingOrders);
        tabPurchaseOrders.Controls.Add(btnCreateOrder);
        tabPurchaseOrders.Controls.Add(btnViewOrder);
        tabPurchaseOrders.Controls.Add(btnApproveOrder);
        tabPurchaseOrders.Controls.Add(dgvOrders);
        tabPurchaseOrders.Location = new Point(4, 24);
        tabPurchaseOrders.Margin = new Padding(4, 3, 4, 3);
        tabPurchaseOrders.Name = "tabPurchaseOrders";
        tabPurchaseOrders.Size = new Size(925, 438);
        tabPurchaseOrders.TabIndex = 2;
        tabPurchaseOrders.Text = "Purchase Orders";
        tabPurchaseOrders.UseVisualStyleBackColor = true;
        // 
        // lblPendingOrders
        // 
        lblPendingOrders.AutoSize = true;
        lblPendingOrders.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblPendingOrders.Location = new Point(9, 18);
        lblPendingOrders.Margin = new Padding(4, 0, 4, 0);
        lblPendingOrders.Name = "lblPendingOrders";
        lblPendingOrders.Size = new Size(94, 13);
        lblPendingOrders.TabIndex = 0;
        lblPendingOrders.Text = "Pending Orders";
        // 
        // dgvPendingOrders
        // 
        dgvPendingOrders.AllowUserToAddRows = false;
        dgvPendingOrders.AllowUserToDeleteRows = false;
        dgvPendingOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvPendingOrders.Location = new Point(9, 37);
        dgvPendingOrders.Margin = new Padding(4, 3, 4, 3);
        dgvPendingOrders.Name = "dgvPendingOrders";
        dgvPendingOrders.ReadOnly = true;
        dgvPendingOrders.Size = new Size(905, 115);
        dgvPendingOrders.TabIndex = 1;
        // 
        // btnCreateOrder
        // 
        btnCreateOrder.Location = new Point(9, 159);
        btnCreateOrder.Margin = new Padding(4, 3, 4, 3);
        btnCreateOrder.Name = "btnCreateOrder";
        btnCreateOrder.Size = new Size(117, 27);
        btnCreateOrder.TabIndex = 2;
        btnCreateOrder.Text = "Create Order";
        btnCreateOrder.UseVisualStyleBackColor = true;
        // 
        // btnViewOrder
        // 
        btnViewOrder.Location = new Point(733, 159);
        btnViewOrder.Margin = new Padding(4, 3, 4, 3);
        btnViewOrder.Name = "btnViewOrder";
        btnViewOrder.Size = new Size(88, 27);
        btnViewOrder.TabIndex = 3;
        btnViewOrder.Text = "View";
        btnViewOrder.UseVisualStyleBackColor = true;
        // 
        // btnApproveOrder
        // 
        btnApproveOrder.Location = new Point(827, 159);
        btnApproveOrder.Margin = new Padding(4, 3, 4, 3);
        btnApproveOrder.Name = "btnApproveOrder";
        btnApproveOrder.Size = new Size(88, 27);
        btnApproveOrder.TabIndex = 4;
        btnApproveOrder.Text = "Approve";
        btnApproveOrder.UseVisualStyleBackColor = true;
        // 
        // dgvOrders
        // 
        dgvOrders.AllowUserToAddRows = false;
        dgvOrders.AllowUserToDeleteRows = false;
        dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvOrders.Location = new Point(9, 193);
        dgvOrders.Margin = new Padding(4, 3, 4, 3);
        dgvOrders.Name = "dgvOrders";
        dgvOrders.ReadOnly = true;
        dgvOrders.Size = new Size(905, 237);
        dgvOrders.TabIndex = 5;
        // 
        // statusStrip1
        // 
        statusStrip1.Items.AddRange(new ToolStripItem[] { statusLabel });
        statusStrip1.Location = new Point(0, 497);
        statusStrip1.Name = "statusStrip1";
        statusStrip1.Padding = new Padding(1, 0, 16, 0);
        statusStrip1.Size = new Size(933, 22);
        statusStrip1.TabIndex = 1;
        // 
        // statusLabel
        // 
        statusLabel.Name = "statusLabel";
        statusLabel.Size = new Size(39, 17);
        statusLabel.Text = "Ready";
        // 
        // menuStrip1
        // 
        menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, reportsToolStripMenuItem, helpToolStripMenuItem });
        menuStrip1.Location = new Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Padding = new Padding(7, 2, 0, 2);
        menuStrip1.Size = new Size(933, 24);
        menuStrip1.TabIndex = 2;
        menuStrip1.Text = "menuStrip1";
        // 
        // fileToolStripMenuItem
        // 
        fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { settingsToolStripMenuItem, exitToolStripMenuItem });
        fileToolStripMenuItem.Name = "fileToolStripMenuItem";
        fileToolStripMenuItem.Size = new Size(37, 20);
        fileToolStripMenuItem.Text = "File";
        // 
        // settingsToolStripMenuItem
        // 
        settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
        settingsToolStripMenuItem.Size = new Size(116, 22);
        settingsToolStripMenuItem.Text = "Settings";
        // 
        // exitToolStripMenuItem
        // 
        exitToolStripMenuItem.Name = "exitToolStripMenuItem";
        exitToolStripMenuItem.Size = new Size(116, 22);
        exitToolStripMenuItem.Text = "Exit";
        // 
        // reportsToolStripMenuItem
        // 
        reportsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { stockReportToolStripMenuItem, transactionReportToolStripMenuItem, ordersReportToolStripMenuItem });
        reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
        reportsToolStripMenuItem.Size = new Size(59, 20);
        reportsToolStripMenuItem.Text = "Reports";
        // 
        // stockReportToolStripMenuItem
        // 
        stockReportToolStripMenuItem.Name = "stockReportToolStripMenuItem";
        stockReportToolStripMenuItem.Size = new Size(180, 22);
        stockReportToolStripMenuItem.Text = "Stock Report";
        // 
        // transactionReportToolStripMenuItem
        // 
        transactionReportToolStripMenuItem.Name = "transactionReportToolStripMenuItem";
        transactionReportToolStripMenuItem.Size = new Size(180, 22);
        transactionReportToolStripMenuItem.Text = "Transaction Report";
        // 
        // ordersReportToolStripMenuItem
        // 
        ordersReportToolStripMenuItem.Name = "ordersReportToolStripMenuItem";
        ordersReportToolStripMenuItem.Size = new Size(180, 22);
        ordersReportToolStripMenuItem.Text = "Orders Report";
        // 
        // helpToolStripMenuItem
        // 
        helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
        helpToolStripMenuItem.Name = "helpToolStripMenuItem";
        helpToolStripMenuItem.Size = new Size(44, 20);
        helpToolStripMenuItem.Text = "Help";
        // 
        // aboutToolStripMenuItem
        // 
        aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
        aboutToolStripMenuItem.Size = new Size(107, 22);
        aboutToolStripMenuItem.Text = "About";
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(933, 519);
        Controls.Add(tabControl1);
        Controls.Add(statusStrip1);
        Controls.Add(menuStrip1);
        MainMenuStrip = menuStrip1;
        Margin = new Padding(4, 3, 4, 3);
        Name = "Form1";
        Text = "Stock Management System";
        tabControl1.ResumeLayout(false);
        tabProducts.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
        tabInventory.ResumeLayout(false);
        tabInventory.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvLowStock).EndInit();
        ((System.ComponentModel.ISupportInitialize)dgvTransactions).EndInit();
        tabPurchaseOrders.ResumeLayout(false);
        tabPurchaseOrders.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvPendingOrders).EndInit();
        ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
        statusStrip1.ResumeLayout(false);
        statusStrip1.PerformLayout();
        menuStrip1.ResumeLayout(false);
        menuStrip1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabProducts;
    private System.Windows.Forms.TabPage tabInventory;
    private System.Windows.Forms.TabPage tabPurchaseOrders;
    private System.Windows.Forms.DataGridView dgvProducts;
    private System.Windows.Forms.Button btnAddProduct;
    private System.Windows.Forms.Button btnEditProduct;
    private System.Windows.Forms.Button btnDeleteProduct;
    private System.Windows.Forms.Label lblLowStock;
    private System.Windows.Forms.DataGridView dgvLowStock;
    private System.Windows.Forms.Button btnStockIn;
    private System.Windows.Forms.Button btnStockOut;
    private System.Windows.Forms.DataGridView dgvTransactions;
    private System.Windows.Forms.Label lblTransactions;
    private System.Windows.Forms.Label lblPendingOrders;
    private System.Windows.Forms.DataGridView dgvPendingOrders;
    private System.Windows.Forms.Button btnCreateOrder;
    private System.Windows.Forms.Button btnViewOrder;
    private System.Windows.Forms.Button btnApproveOrder;
    private System.Windows.Forms.DataGridView dgvOrders;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStripStatusLabel statusLabel;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem stockReportToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem transactionReportToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem ordersReportToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
}