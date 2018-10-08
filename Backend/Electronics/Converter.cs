using System.Threading.Tasks;
using Electronics.Models;
using Electronics.DbEntities;
using Electronics.Repositories.Abstract;
using Electronics.Repositories.Concrete;

namespace Electronics
{
    public class Converter : IConverter
    {
        private readonly IBrandRepository brandRepository;
        private readonly ICategoryRepository categoryRepository;

        public Converter(string connectionString)
        {
            brandRepository = new BrandRepository(connectionString);
            categoryRepository = new CategoryRepository(connectionString);
        }

        public Task<Product> ConvertProductEntityToProductModel(ProductEntity entity)
        {
            return Task.Run(() =>
            {
                return new Product
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Color = entity.Color,
                    Dimentions = entity.Dimentions,
                    Weight = entity.Weight,
                    Os = entity.Os,
                    Discount = entity.Discount,
                    Price = entity.Price,
                    ImagePath = entity.ImagePath,
                    ImageData = ImageLoader.CreateBase64Image(entity.ImagePath).Result ?? "unknown",
                    Brand = brandRepository.GetBrandByIdAsync(entity.BrandId).Result?.Name ?? "unknown",
                    Category = categoryRepository.GetCategoryByIdAsync(entity.CategoryId).Result?.Name ?? "unknown"
                };
            });
        }

        public Task<ProductEntity> ConvertProductModelToProductEntity(Product product)
        {
            return Task.Run(() =>
            {
                return new ProductEntity
                {
                    Id = product.Id,
                    Name = product.Name,
                    Color = product.Color,
                    Dimentions = product.Dimentions,
                    Weight = product.Weight,
                    Os = product.Os,
                    Discount = product.Discount,
                    Price = product.Price,
                    ImagePath = product.ImagePath,
                    BrandId = brandRepository.GetBrandByNameAsync(product.Brand).Result.Id,
                    CategoryId = categoryRepository.GetCategoryByNameAsync(product.Category).Result.Id
                };
            });
        }

        public Task<Brand> ConvertBrandEntityToBrandModel(BrandEntity entity)
        {
            return Task.Run(() =>
             {
                 return new Brand
                 {
                     Id = entity.Id,
                     Name = entity.Name
                 };
             });
        }

        public Task<BrandEntity> ConvertBrandModelToBrandEntity(Brand brand)
        {
            return Task.Run(() =>
            {
                return new BrandEntity
                {
                    Id = brand.Id,
                    Name = brand.Name
                };
            });
        }

        public Task<Category> ConvertCategoryEntityToCategoryModel(CategoryEntity entity)
        {
            return Task.Run(() =>
            {
                return new Category
                {
                    Id = entity.Id,
                    Name = entity.Name
                };
            });
        }

        public Task<CategoryEntity> ConvertCategoryModelToCategoryEntity(Category category)
        {
            return Task.Run(() =>
            {
                return new CategoryEntity
                {
                    Id = category.Id,
                    Name = category.Name
                };
            });
        }
    }
}
