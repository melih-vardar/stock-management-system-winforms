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
        this.tabControl1 = new System.Windows.Forms.TabControl();
        this.tabProducts = new System.Windows.Forms.TabPage();
        this.btnAddProduct = new System.Windows.Forms.Button();
        this.btnEditProduct = new System.Windows.Forms.Button();
        this.btnDeleteProduct = new System.Windows.Forms.Button();
        this.dgvProducts = new System.Windows.Forms.DataGridView();
        this.tabInventory = new System.Windows.Forms.TabPage();
        this.lblLowStock = new System.Windows.Forms.Label();
        this.dgvLowStock = new System.Windows.Forms.DataGridView();
        this.btnStockIn = new System.Windows.Forms.Button();
        this.btnStockOut = new System.Windows.Forms.Button();
        this.dgvTransactions = new System.Windows.Forms.DataGridView();
        this.lblTransactions = new System.Windows.Forms.Label();
        this.tabPurchaseOrders = new System.Windows.Forms.TabPage();
        this.btnCreateOrder = new System.Windows.Forms.Button();
        this.btnViewOrder = new System.Windows.Forms.Button();
        this.btnApproveOrder = new System.Windows.Forms.Button();
        this.lblPendingOrders = new System.Windows.Forms.Label();
        this.dgvPendingOrders = new System.Windows.Forms.DataGridView();
        this.dgvOrders = new System.Windows.Forms.DataGridView();
        this.statusStrip1 = new System.Windows.Forms.StatusStrip();
        this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
        this.menuStrip1 = new System.Windows.Forms.MenuStrip();
        this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.stockReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.transactionReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.ordersReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();

        this.tabControl1.SuspendLayout();
        this.tabProducts.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
        this.tabInventory.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvLowStock)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).BeginInit();
        this.tabPurchaseOrders.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvPendingOrders)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
        this.statusStrip1.SuspendLayout();
        this.menuStrip1.SuspendLayout();
        this.SuspendLayout();

        // tabControl1
        this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tabControl1.Location = new System.Drawing.Point(0, 24);
        this.tabControl1.Name = "tabControl1";
        this.tabControl1.SelectedIndex = 0;
        this.tabControl1.Size = new System.Drawing.Size(800, 404);
        this.tabControl1.TabIndex = 0;
        this.tabControl1.Controls.Add(this.tabProducts);
        this.tabControl1.Controls.Add(this.tabInventory);
        this.tabControl1.Controls.Add(this.tabPurchaseOrders);

        // tabProducts
        this.tabProducts.Location = new System.Drawing.Point(4, 22);
        this.tabProducts.Name = "tabProducts";
        this.tabProducts.Padding = new System.Windows.Forms.Padding(3);
        this.tabProducts.Size = new System.Drawing.Size(792, 378);
        this.tabProducts.TabIndex = 0;
        this.tabProducts.Text = "Products";
        this.tabProducts.UseVisualStyleBackColor = true;
        this.tabProducts.Controls.Add(this.dgvProducts);
        this.tabProducts.Controls.Add(this.btnAddProduct);
        this.tabProducts.Controls.Add(this.btnEditProduct);
        this.tabProducts.Controls.Add(this.btnDeleteProduct);

        // dgvProducts
        this.dgvProducts.AllowUserToAddRows = false;
        this.dgvProducts.AllowUserToDeleteRows = false;
        this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvProducts.Location = new System.Drawing.Point(8, 47);
        this.dgvProducts.Name = "dgvProducts";
        this.dgvProducts.ReadOnly = true;
        this.dgvProducts.Size = new System.Drawing.Size(776, 323);
        this.dgvProducts.TabIndex = 0;
        
        // btnAddProduct
        this.btnAddProduct.Location = new System.Drawing.Point(8, 16);
        this.btnAddProduct.Name = "btnAddProduct";
        this.btnAddProduct.Size = new System.Drawing.Size(75, 23);
        this.btnAddProduct.TabIndex = 1;
        this.btnAddProduct.Text = "Add";
        this.btnAddProduct.UseVisualStyleBackColor = true;
        
        // btnEditProduct
        this.btnEditProduct.Location = new System.Drawing.Point(89, 16);
        this.btnEditProduct.Name = "btnEditProduct";
        this.btnEditProduct.Size = new System.Drawing.Size(75, 23);
        this.btnEditProduct.TabIndex = 2;
        this.btnEditProduct.Text = "Edit";
        this.btnEditProduct.UseVisualStyleBackColor = true;
        
        // btnDeleteProduct
        this.btnDeleteProduct.Location = new System.Drawing.Point(170, 16);
        this.btnDeleteProduct.Name = "btnDeleteProduct";
        this.btnDeleteProduct.Size = new System.Drawing.Size(75, 23);
        this.btnDeleteProduct.TabIndex = 3;
        this.btnDeleteProduct.Text = "Delete";
        this.btnDeleteProduct.UseVisualStyleBackColor = true;

        // tabInventory
        this.tabInventory.Location = new System.Drawing.Point(4, 22);
        this.tabInventory.Name = "tabInventory";
        this.tabInventory.Padding = new System.Windows.Forms.Padding(3);
        this.tabInventory.Size = new System.Drawing.Size(792, 378);
        this.tabInventory.TabIndex = 1;
        this.tabInventory.Text = "Inventory";
        this.tabInventory.UseVisualStyleBackColor = true;
        this.tabInventory.Controls.Add(this.lblLowStock);
        this.tabInventory.Controls.Add(this.dgvLowStock);
        this.tabInventory.Controls.Add(this.btnStockIn);
        this.tabInventory.Controls.Add(this.btnStockOut);
        this.tabInventory.Controls.Add(this.dgvTransactions);
        this.tabInventory.Controls.Add(this.lblTransactions);

        // lblLowStock
        this.lblLowStock.AutoSize = true;
        this.lblLowStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lblLowStock.Location = new System.Drawing.Point(8, 16);
        this.lblLowStock.Name = "lblLowStock";
        this.lblLowStock.Size = new System.Drawing.Size(129, 13);
        this.lblLowStock.TabIndex = 0;
        this.lblLowStock.Text = "Products with Low Stock";

        // dgvLowStock
        this.dgvLowStock.AllowUserToAddRows = false;
        this.dgvLowStock.AllowUserToDeleteRows = false;
        this.dgvLowStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvLowStock.Location = new System.Drawing.Point(8, 32);
        this.dgvLowStock.Name = "dgvLowStock";
        this.dgvLowStock.ReadOnly = true;
        this.dgvLowStock.Size = new System.Drawing.Size(776, 100);
        this.dgvLowStock.TabIndex = 1;

        // btnStockIn
        this.btnStockIn.Location = new System.Drawing.Point(628, 138);
        this.btnStockIn.Name = "btnStockIn";
        this.btnStockIn.Size = new System.Drawing.Size(75, 23);
        this.btnStockIn.TabIndex = 2;
        this.btnStockIn.Text = "Stock In";
        this.btnStockIn.UseVisualStyleBackColor = true;

        // btnStockOut
        this.btnStockOut.Location = new System.Drawing.Point(709, 138);
        this.btnStockOut.Name = "btnStockOut";
        this.btnStockOut.Size = new System.Drawing.Size(75, 23);
        this.btnStockOut.TabIndex = 3;
        this.btnStockOut.Text = "Stock Out";
        this.btnStockOut.UseVisualStyleBackColor = true;

        // lblTransactions
        this.lblTransactions.AutoSize = true;
        this.lblTransactions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lblTransactions.Location = new System.Drawing.Point(8, 143);
        this.lblTransactions.Name = "lblTransactions";
        this.lblTransactions.Size = new System.Drawing.Size(115, 13);
        this.lblTransactions.TabIndex = 4;
        this.lblTransactions.Text = "Recent Transactions";

        // dgvTransactions
        this.dgvTransactions.AllowUserToAddRows = false;
        this.dgvTransactions.AllowUserToDeleteRows = false;
        this.dgvTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvTransactions.Location = new System.Drawing.Point(8, 167);
        this.dgvTransactions.Name = "dgvTransactions";
        this.dgvTransactions.ReadOnly = true;
        this.dgvTransactions.Size = new System.Drawing.Size(776, 205);
        this.dgvTransactions.TabIndex = 5;

        // tabPurchaseOrders
        this.tabPurchaseOrders.Location = new System.Drawing.Point(4, 22);
        this.tabPurchaseOrders.Name = "tabPurchaseOrders";
        this.tabPurchaseOrders.Size = new System.Drawing.Size(792, 378);
        this.tabPurchaseOrders.TabIndex = 2;
        this.tabPurchaseOrders.Text = "Purchase Orders";
        this.tabPurchaseOrders.UseVisualStyleBackColor = true;
        this.tabPurchaseOrders.Controls.Add(this.lblPendingOrders);
        this.tabPurchaseOrders.Controls.Add(this.dgvPendingOrders);
        this.tabPurchaseOrders.Controls.Add(this.btnCreateOrder);
        this.tabPurchaseOrders.Controls.Add(this.btnViewOrder);
        this.tabPurchaseOrders.Controls.Add(this.btnApproveOrder);
        this.tabPurchaseOrders.Controls.Add(this.dgvOrders);

        // lblPendingOrders
        this.lblPendingOrders.AutoSize = true;
        this.lblPendingOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lblPendingOrders.Location = new System.Drawing.Point(8, 16);
        this.lblPendingOrders.Name = "lblPendingOrders";
        this.lblPendingOrders.Size = new System.Drawing.Size(98, 13);
        this.lblPendingOrders.TabIndex = 0;
        this.lblPendingOrders.Text = "Pending Orders";

        // dgvPendingOrders
        this.dgvPendingOrders.AllowUserToAddRows = false;
        this.dgvPendingOrders.AllowUserToDeleteRows = false;
        this.dgvPendingOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvPendingOrders.Location = new System.Drawing.Point(8, 32);
        this.dgvPendingOrders.Name = "dgvPendingOrders";
        this.dgvPendingOrders.ReadOnly = true;
        this.dgvPendingOrders.Size = new System.Drawing.Size(776, 100);
        this.dgvPendingOrders.TabIndex = 1;

        // btnCreateOrder
        this.btnCreateOrder.Location = new System.Drawing.Point(8, 138);
        this.btnCreateOrder.Name = "btnCreateOrder";
        this.btnCreateOrder.Size = new System.Drawing.Size(100, 23);
        this.btnCreateOrder.TabIndex = 2;
        this.btnCreateOrder.Text = "Create Order";
        this.btnCreateOrder.UseVisualStyleBackColor = true;

        // btnViewOrder
        this.btnViewOrder.Location = new System.Drawing.Point(628, 138);
        this.btnViewOrder.Name = "btnViewOrder";
        this.btnViewOrder.Size = new System.Drawing.Size(75, 23);
        this.btnViewOrder.TabIndex = 3;
        this.btnViewOrder.Text = "View";
        this.btnViewOrder.UseVisualStyleBackColor = true;

        // btnApproveOrder
        this.btnApproveOrder.Location = new System.Drawing.Point(709, 138);
        this.btnApproveOrder.Name = "btnApproveOrder";
        this.btnApproveOrder.Size = new System.Drawing.Size(75, 23);
        this.btnApproveOrder.TabIndex = 4;
        this.btnApproveOrder.Text = "Approve";
        this.btnApproveOrder.UseVisualStyleBackColor = true;

        // dgvOrders
        this.dgvOrders.AllowUserToAddRows = false;
        this.dgvOrders.AllowUserToDeleteRows = false;
        this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvOrders.Location = new System.Drawing.Point(8, 167);
        this.dgvOrders.Name = "dgvOrders";
        this.dgvOrders.ReadOnly = true;
        this.dgvOrders.Size = new System.Drawing.Size(776, 205);
        this.dgvOrders.TabIndex = 5;

        // statusStrip1
        this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
        this.statusStrip1.Location = new System.Drawing.Point(0, 428);
        this.statusStrip1.Name = "statusStrip1";
        this.statusStrip1.Size = new System.Drawing.Size(800, 22);
        this.statusStrip1.TabIndex = 1;

        // statusLabel
        this.statusLabel.Name = "statusLabel";
        this.statusLabel.Size = new System.Drawing.Size(39, 17);
        this.statusLabel.Text = "Ready";

        // menuStrip1
        this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.helpToolStripMenuItem});
        this.menuStrip1.Location = new System.Drawing.Point(0, 0);
        this.menuStrip1.Name = "menuStrip1";
        this.menuStrip1.Size = new System.Drawing.Size(800, 24);
        this.menuStrip1.TabIndex = 2;
        this.menuStrip1.Text = "menuStrip1";

        // fileToolStripMenuItem
        this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.exitToolStripMenuItem});
        this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
        this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
        this.fileToolStripMenuItem.Text = "File";

        // settingsToolStripMenuItem
        this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
        this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
        this.settingsToolStripMenuItem.Text = "Settings";

        // exitToolStripMenuItem
        this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
        this.exitToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
        this.exitToolStripMenuItem.Text = "Exit";

        // reportsToolStripMenuItem
        this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stockReportToolStripMenuItem,
            this.transactionReportToolStripMenuItem,
            this.ordersReportToolStripMenuItem});
        this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
        this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
        this.reportsToolStripMenuItem.Text = "Reports";

        // stockReportToolStripMenuItem
        this.stockReportToolStripMenuItem.Name = "stockReportToolStripMenuItem";
        this.stockReportToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
        this.stockReportToolStripMenuItem.Text = "Stock Report";

        // transactionReportToolStripMenuItem
        this.transactionReportToolStripMenuItem.Name = "transactionReportToolStripMenuItem";
        this.transactionReportToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
        this.transactionReportToolStripMenuItem.Text = "Transaction Report";

        // ordersReportToolStripMenuItem
        this.ordersReportToolStripMenuItem.Name = "ordersReportToolStripMenuItem";
        this.ordersReportToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
        this.ordersReportToolStripMenuItem.Text = "Orders Report";

        // helpToolStripMenuItem
        this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
        this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
        this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
        this.helpToolStripMenuItem.Text = "Help";

        // aboutToolStripMenuItem
        this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
        this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
        this.aboutToolStripMenuItem.Text = "About";

        // Form1
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 450);
        this.Controls.Add(this.tabControl1);
        this.Controls.Add(this.statusStrip1);
        this.Controls.Add(this.menuStrip1);
        this.MainMenuStrip = this.menuStrip1;
        this.Name = "Form1";
        this.Text = "Stock Management System";
        
        this.tabControl1.ResumeLayout(false);
        this.tabProducts.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
        this.tabInventory.ResumeLayout(false);
        this.tabInventory.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvLowStock)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).EndInit();
        this.tabPurchaseOrders.ResumeLayout(false);
        this.tabPurchaseOrders.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvPendingOrders)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
        this.statusStrip1.ResumeLayout(false);
        this.statusStrip1.PerformLayout();
        this.menuStrip1.ResumeLayout(false);
        this.menuStrip1.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();
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