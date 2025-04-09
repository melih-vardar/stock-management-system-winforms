using System;
using System.ComponentModel.DataAnnotations;

namespace StockManagementSystem.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(500)]
        public string? Description { get; set; }
        
        [Required]
        public decimal UnitPrice { get; set; }
        
        [Required]
        public int CurrentStock { get; set; }
        
        [Required]
        public int MinimumStockLevel { get; set; }
        
        public string? SKU { get; set; }
        
        public string? Category { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        public DateTime? UpdatedAt { get; set; }
    }
} 