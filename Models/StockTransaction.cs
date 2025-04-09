using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockManagementSystem.Models
{
    public enum TransactionType
    {
        StockIn,
        StockOut,
        Adjustment
    }

    public class StockTransaction
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public int ProductId { get; set; }
        
        [Required]
        public TransactionType Type { get; set; }
        
        [Required]
        public int Quantity { get; set; }
        
        [Required]
        public DateTime TransactionDate { get; set; } = DateTime.Now;
        
        public string? Reference { get; set; }
        
        [StringLength(500)]
        public string? Notes { get; set; }
        
        [Required]
        public string PerformedBy { get; set; } = string.Empty;
        
        // Navigation property
        [ForeignKey("ProductId")]
        public virtual Product? Product { get; set; }
    }
} 