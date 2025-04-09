using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace StockManagementSystem.Models.Repositories
{
    public class PurchaseOrderRepository : Repository<PurchaseOrder>
    {
        public PurchaseOrderRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<PurchaseOrder> GetPurchaseOrdersWithItems()
        {
            return _dbSet
                .Include(po => po.OrderItems)
                .ThenInclude(item => item.Product)
                .ToList();
        }

        public PurchaseOrder GetPurchaseOrderWithItems(int id)
        {
            return _dbSet
                .Include(po => po.OrderItems)
                .ThenInclude(item => item.Product)
                .FirstOrDefault(po => po.Id == id);
        }

        public IEnumerable<PurchaseOrder> GetPendingApprovalOrders()
        {
            return _dbSet
                .Where(po => po.Status == OrderStatus.Submitted)
                .Include(po => po.OrderItems)
                .ThenInclude(item => item.Product)
                .ToList();
        }

        public void UpdateOrderStatus(int orderId, OrderStatus status, string approvedBy = null)
        {
            var order = _dbSet.Find(orderId);
            if (order != null)
            {
                order.Status = status;
                
                if (status == OrderStatus.Approved)
                {
                    order.ApprovedBy = approvedBy;
                    order.ApprovalDate = System.DateTime.Now;
                }
                
                _context.SaveChanges();
            }
        }
    }
} 