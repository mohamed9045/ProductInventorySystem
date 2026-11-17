using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ProductInventorySystem.DAL.Entities;

namespace ProductInventorySystem.BLL.ViewModels
{
    public class ProductFormViewModel : IValidatableObject
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "SKU is required")]
        [StringLength(20, ErrorMessage = "SKU cannot exceed 20 characters")]
        public string SKU { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string? Description { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Stock quantity cannot be negative")]
        public int StockQuantity { get; set; }

        [Required]
        public ProductCategory Category { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public IEnumerable<ValidationResult> Validate(
            ValidationContext validationContext)
        {
            if (ExpiryDate.HasValue && ExpiryDate.Value.Date < DateTime.Today)
            {
                yield return new ValidationResult(
                    "Expiry date cannot be in the past",
                    new[] { nameof(ExpiryDate) });
            }

            if (Category == ProductCategory.Grocery && !ExpiryDate.HasValue)
            {
                yield return new ValidationResult(
                    "Expiry date is required for Grocery products",
                    new[] { nameof(ExpiryDate) });
            }
        }
    }
}
