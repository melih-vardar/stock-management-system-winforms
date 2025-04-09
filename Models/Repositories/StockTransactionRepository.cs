using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StockManagementSystem.Models.Repositories
{
    public class StockTransactionRepository : Repository<StockTransaction>
    {
        private readonly ProductRepository _productRepository;
        
        public StockTransactionRepository(AppDbContext context) : base(context)
        {
            _productRepository = new ProductRepository(context);
        }

        public IEnumerable<StockTransaction> GetRecentTransactions(int count = 50)
        {
            return _dbSet
                .Include(st => st.Product)
                .OrderByDescending(st => st.TransactionDate)
                .Take(count)
                .ToList();
        }

        public IEnumerable<StockTransaction> GetTransactionsByDateRange(DateTime startDate, DateTime endDate)
        {
            return _dbSet
                .Include(st => st.Product)
                .Where(st => st.TransactionDate >= startDate && st.TransactionDate <= endDate)
                .OrderByDescending(st => st.TransactionDate)
                .ToList();
        }

        public IEnumerable<StockTransaction> GetTransactionsByProduct(int productId)
        {
            return _dbSet
                .Include(st => st.Product)
                .Where(st => st.ProductId == productId)
                .OrderByDescending(st => st.TransactionDate)
                .ToList();
        }

        public void AddStockTransaction(int productId, TransactionType type, int quantity, string reference, string notes, string performedBy)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // Create the transaction record
                    var stockTransaction = new StockTransaction
                    {
                        ProductId = productId,
                        Type = type,
                        Quantity = quantity,
                        TransactionDate = DateTime.Now,
                        Reference = reference,
                        Notes = notes,
                        PerformedBy = performedBy
                    };

                    _dbSet.Add(stockTransaction);
                    
                    // Update the product's stock
                    int stockChange = type == TransactionType.StockOut ? -quantity : quantity;
                    _productRepository.UpdateStock(productId, stockChange);
                    
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
} 