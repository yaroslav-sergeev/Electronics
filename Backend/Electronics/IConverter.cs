using Electronics.DbEntities;
using Electronics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electronics
{
    public interface IConverter
    {
        Task<Product> ConvertProductEntityToProductModel(ProductEntity entity);
        Task<ProductEntity> ConvertProductModelToProductEntity(Product product);

        Task<Brand> ConvertBrandEntityToBrandModel(BrandEntity entity);
        Task<BrandEntity> ConvertBrandModelToBrandEntity(Brand brand);

        Task<Category> ConvertCategoryEntityToCategoryModel(CategoryEntity entity);
        Task<CategoryEntity> ConvertCategoryModelToCategoryEntity(Category category);
    }
}
