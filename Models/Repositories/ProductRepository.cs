using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace StockManagementSystem.Models.Repositories
{
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Product> GetProductsWithLowStock()
        {
            return _dbSet.Where(p => p.CurrentStock <= p.MinimumStockLevel).ToList();
        }

        public void UpdateStock(int productId, int quantity)
        {
            var product = _dbSet.Find(productId);
            if (product != null)
            {
                product.CurrentStock += quantity;
                product.UpdatedAt = System.DateTime.Now;
                _context.SaveChanges();
            }
        }
    }
} 