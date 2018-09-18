using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Electronics.DbEntities;

namespace Electronics.Repositories.Abstract
{
   public interface IProductRepository
    {
        Task<IEnumerable<ProductEntity>> GetAllAsync();
        Task<ProductEntity> GetProductByIdAsync(Guid productId);
        Task DeleteByIdAsync(Guid productId);
        Task UpdateProductAsync(ProductEntity product);
        Task<IEnumerable<ProductEntity>> GetProductByCategory(string category);
        Task<IEnumerable<ProductEntity>> GetProductByBrandAndCategoryAsync(string brand, string category);
    }
}
