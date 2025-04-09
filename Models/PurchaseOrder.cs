using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StockManagementSystem.Models
{
    public enum OrderStatus
    {
        Draft,
        Submitted,
        Approved,
        Rejected,
        Received,
        Canceled
    }

    public class PurchaseOrder
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string OrderNumber { get; set; } = string.Empty;
        
        [Required]
        public DateTime OrderDate { get; set; } = DateTime.Now;
        
        public DateTime? ExpectedDeliveryDate { get; set; }
        
        [Required]
        public OrderStatus Status { get; set; } = OrderStatus.Draft;
        
        [StringLength(500)]
        public string? Notes { get; set; }
        
        [Required]
        public string RequestedBy { get; set; } = string.Empty;
        
        public string? ApprovedBy { get; set; }
        
        public DateTime? ApprovalDate { get; set; }
        
        public decimal TotalAmount { get; set; }
        
        // Navigation property
        public virtual ICollection<PurchaseOrderItem> OrderItems { get; set; } = new List<PurchaseOrderItem>();
    }
} 