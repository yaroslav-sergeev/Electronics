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
        Task<Product> MapProductEntityToProductModel(ProductEntity entity);
        Task<ProductEntity> MapProductModelToProductEntity(Product product);

        Task<Brand> MapBrandEntityToBrandModel(BrandEntity entity);
        Task<BrandEntity> MapBrandModelToBrandEntity(Brand brand);

        Task<Category> MapCategoryEntityToCategoryModel(CategoryEntity entity);
        Task<CategoryEntity> MapCategoryModelToCategoryEntity(Category category);
    }
}
