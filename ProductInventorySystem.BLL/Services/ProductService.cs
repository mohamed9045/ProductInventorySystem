using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductInventorySystem.BLL.Services.Interfaces;
using ProductInventorySystem.BLL.ViewModels;
using ProductInventorySystem.DAL.Entities;
using ProductInventorySystem.DAL.Repositories.Interfaces;

namespace ProductInventorySystem.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProductListViewModel>> GetAllAsync()
        {
            var products = await _repository.GetAllAsync();

            return products.Select(p => new ProductListViewModel
            {
                Id = p.Id,
                Name = p.Name,
                SKU = p.SKU,
                Price = p.Price,
                StockQuantity = p.StockQuantity,
                Category = p.Category,
                IsActive = p.IsActive,
                CreatedAt = p.CreatedAt
            }).ToList();
        }

        public async Task<ProductFormViewModel?> GetByIdAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);

            if (product == null)
                return null;

            return new ProductFormViewModel
            {
                Id = product.Id,
                Name = product.Name,
                SKU = product.SKU,
                Description = product.Description,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                Category = product.Category,
                ExpiryDate = product.ExpiryDate
            };
        }

        public async Task<string?> CreateAsync(ProductFormViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
                return "Product name is required.";

            if (string.IsNullOrWhiteSpace(model.SKU))
                return "SKU is required.";

            if (model.Price <= 0)
                return "Price must be greater than zero.";

            if (model.StockQuantity < 0)
                return "Stock quantity cannot be negative.";

            if (model.ExpiryDate.HasValue &&
                model.ExpiryDate.Value.Date < DateTime.Today)
                return "Expiry date cannot be in the past.";

            if (model.Category == ProductCategory.Grocery &&
                !model.ExpiryDate.HasValue)
                return "Expiry date is required for Grocery products.";

            if (await _repository.IsSKUExistsAsync(model.SKU))
                return "This SKU already exists.";

            var product = new Product
            {
                Name = model.Name,
                SKU = model.SKU,
                Description = model.Description,
                Price = model.Price,
                StockQuantity = model.StockQuantity,
                Category = model.Category,
                ExpiryDate = model.ExpiryDate,
                IsActive = true
            };

            await _repository.AddAsync(product);

            return null;
        }

        public async Task<string?> UpdateAsync(ProductFormViewModel model)
        {
            var product = await _repository.GetByIdAsync(model.Id);

            if (product == null)
                return "Product not found.";

            if (string.IsNullOrWhiteSpace(model.Name))
                return "Product name is required.";

            if (string.IsNullOrWhiteSpace(model.SKU))
                return "SKU is required.";

            if (model.Price <= 0)
                return "Price must be greater than zero.";

            if (model.StockQuantity < 0)
                return "Stock quantity cannot be negative.";

            if (model.ExpiryDate.HasValue &&
                model.ExpiryDate.Value.Date < DateTime.Today)
                return "Expiry date cannot be in the past.";

            if (model.Category == ProductCategory.Grocery &&
                !model.ExpiryDate.HasValue)
                return "Expiry date is required for Grocery products.";

            if (product.SKU != model.SKU &&
                await _repository.IsSKUExistsAsync(model.SKU))
                return "This SKU already exists.";

            product.Name = model.Name;
            product.SKU = model.SKU;
            product.Description = model.Description;
            product.Price = model.Price;
            product.StockQuantity = model.StockQuantity;
            product.Category = model.Category;
            product.ExpiryDate = model.ExpiryDate;

            _repository.Update(product);

            return null;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);

            if (product == null)
                return false;

            _repository.Delete(product);

            return true;
        }
    }
}
