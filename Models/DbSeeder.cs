using System;
using System.Linq;

namespace StockManagementSystem.Models
{
    public static class DbSeeder
    {
        public static void SeedData(AppDbContext dbContext)
        {
            // Only seed if database is empty
            if (dbContext.Products.Any())
            {
                return;
            }

            // Add sample products
            var products = new[]
            {
                new Product 
                { 
                    Name = "Widget A", 
                    Description = "Standard widget type A", 
                    UnitPrice = 10.99m, 
                    CurrentStock = 50, 
                    MinimumStockLevel = 10, 
                    SKU = "WID-A-001", 
                    Category = "Widgets" 
                },
                new Product 
                { 
                    Name = "Widget B", 
                    Description = "Premium widget type B", 
                    UnitPrice = 15.99m, 
                    CurrentStock = 30, 
                    MinimumStockLevel = 15, 
                    SKU = "WID-B-002", 
                    Category = "Widgets" 
                },
                new Product 
                { 
                    Name = "Gadget X", 
                    Description = "Standard gadget type X", 
                    UnitPrice = 25.50m, 
                    CurrentStock = 20, 
                    MinimumStockLevel = 10, 
                    SKU = "GAD-X-001", 
                    Category = "Gadgets" 
                },
                new Product 
                { 
                    Name = "Gadget Y", 
                    Description = "Premium gadget type Y", 
                    UnitPrice = 35.99m, 
                    CurrentStock = 15, 
                    MinimumStockLevel = 10, 
                    SKU = "GAD-Y-002", 
                    Category = "Gadgets" 
                },
                new Product 
                { 
                    Name = "Component Z", 
                    Description = "Standard component Z", 
                    UnitPrice = 5.99m, 
                    CurrentStock = 100, 
                    MinimumStockLevel = 50, 
                    SKU = "COM-Z-001", 
                    Category = "Components" 
                },
                new Product 
                { 
                    Name = "Low Stock Item", 
                    Description = "This item is low on stock", 
                    UnitPrice = 99.99m, 
                    CurrentStock = 2, 
                    MinimumStockLevel = 10, 
                    SKU = "LOW-001", 
                    Category = "Critical" 
                }
            };

            dbContext.Products.AddRange(products);
            dbContext.SaveChanges();

            // Add sample purchase order
            var order = new PurchaseOrder
            {
                OrderNumber = "PO-2023-001",
                OrderDate = DateTime.Now.AddDays(-10),
                ExpectedDeliveryDate = DateTime.Now.AddDays(5),
                Status = OrderStatus.Submitted,
                Notes = "Sample purchase order",
                RequestedBy = "System Administrator",
                TotalAmount = 275.95m
            };

            dbContext.PurchaseOrders.Add(order);
            dbContext.SaveChanges();

            // Add order items
            var orderItems = new[]
            {
                new PurchaseOrderItem 
                { 
                    PurchaseOrderId = order.Id, 
                    ProductId = products[0].Id, 
                    Quantity = 10, 
                    UnitPrice = products[0].UnitPrice 
                },
                new PurchaseOrderItem 
                { 
                    PurchaseOrderId = order.Id, 
                    ProductId = products[2].Id, 
                    Quantity = 5, 
                    UnitPrice = products[2].UnitPrice 
                }
            };

            dbContext.PurchaseOrderItems.AddRange(orderItems);
            dbContext.SaveChanges();

            // Add sample transactions
            var transactions = new[]
            {
                new StockTransaction 
                { 
                    ProductId = products[0].Id, 
                    Type = TransactionType.StockIn, 
                    Quantity = 50, 
                    TransactionDate = DateTime.Now.AddDays(-20), 
                    Reference = "Initial Stock", 
                    PerformedBy = "System" 
                },
                new StockTransaction 
                { 
                    ProductId = products[1].Id, 
                    Type = TransactionType.StockIn, 
                    Quantity = 30, 
                    TransactionDate = DateTime.Now.AddDays(-20), 
                    Reference = "Initial Stock", 
                    PerformedBy = "System" 
                },
                new StockTransaction 
                { 
                    ProductId = products[0].Id, 
                    Type = TransactionType.StockOut, 
                    Quantity = 5, 
                    TransactionDate = DateTime.Now.AddDays(-10), 
                    Reference = "Sample Order #12345", 
                    PerformedBy = "System" 
                }
            };

            dbContext.StockTransactions.AddRange(transactions);
            dbContext.SaveChanges();
        }
    }
} 