using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Electronics.Models;
using Electronics.Repositories.Abstract;
using Electronics.Services.Abstract;
using Electronics.Repositories.Concrete;
using Electronics.DbEntities;

namespace Electronics.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IConverter converter;

        public CategoryService(string connectionString)
        {
            categoryRepository = new CategoryRepository(connectionString);
            converter = new Converter(connectionString);
        }

        public async Task AddCategoryAsync(Category category)
        {
           await categoryRepository.AddCategoryAsync(converter.ConvertCategoryModelToCategoryEntity(category).Result);
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            IEnumerable<CategoryEntity> dbCategories = await categoryRepository.GetAllAsync();

            return  dbCategories.Select(category => converter.ConvertCategoryEntityToCategoryModel(category).Result);              
        }
    }
}
