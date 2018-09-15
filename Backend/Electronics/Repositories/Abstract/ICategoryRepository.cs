using Electronics.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electronics.Repositories.Abstract
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryEntity>> GetAllAsync();
        Task<CategoryEntity> GetCategoryByIdAsync(Guid categoryId);
        Task<CategoryEntity> GetCategoryByNameAsync(string categoryName);
        Task DeleteByIdAsync(Guid categoryId);
        Task UpdateCategoryAsync(CategoryEntity category);
        Task AddCategoryAsync(CategoryEntity category);
        Task<IEnumerable<CategoryEntity>> GetCategoriesOfBrandAsync(Guid brandId);
    }
}
