using Electronics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electronics.Services.Abstract
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(Guid productId);
        Task DeleteByIdAsync(Guid productId);
        Task UpdateProductAsync(Product product);
        Task<IEnumerable<Product>> GetProductByCategory(string category);
        Task<IEnumerable<Product>> GetProductByBrandAndCategoryAsync(string brand, string category);
        Task AddProductAsync(Product product);
        Task<IEnumerable<Product>> GetProductsInRangeAsync(int low, int? high = null);
    }
}
