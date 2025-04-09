using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockManagementSystem.Models
{
    public class PurchaseOrderItem
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public int PurchaseOrderId { get; set; }
        
        [Required]
        public int ProductId { get; set; }
        
        [Required]
        public int Quantity { get; set; }
        
        [Required]
        public decimal UnitPrice { get; set; }
        
        [NotMapped]
        public decimal TotalPrice => Quantity * UnitPrice;
        
        // Navigation properties
        [ForeignKey("PurchaseOrderId")]
        public virtual PurchaseOrder? PurchaseOrder { get; set; }
        
        [ForeignKey("ProductId")]
        public virtual Product? Product { get; set; }
    }
} 