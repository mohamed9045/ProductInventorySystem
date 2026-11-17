using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductInventorySystem.BLL.ViewModels;

namespace ProductInventorySystem.BLL.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductListViewModel>> GetAllAsync();

        Task<ProductFormViewModel?> GetByIdAsync(int id);

        Task<string?> CreateAsync(ProductFormViewModel model);

        Task<string?> UpdateAsync(ProductFormViewModel model);

        Task<bool> DeleteAsync(int id);
    }
}
