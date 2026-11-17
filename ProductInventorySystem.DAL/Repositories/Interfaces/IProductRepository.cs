using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductInventorySystem.DAL.Entities;

namespace ProductInventorySystem.DAL.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();

        Task<Product?> GetByIdAsync(int id);

        Task AddAsync(Product product);

        void Update(Product product);

        void Delete(Product product);

        Task<bool> IsSKUExistsAsync(string sku);
    }
}
