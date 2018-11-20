using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Electronics.DbEntities;
using Electronics.Models;
using Electronics.Repositories.Abstract;
using Electronics.Repositories.Concrete;
using Electronics.Services.Abstract;

namespace Electronics.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IConverter converter;
        public ProductService(string connectionString)
        {
            productRepository = new ProductRepository(connectionString);
            converter = new Converter(connectionString);
        }

        public async Task AddProductAsync(Product product)
        {
          await productRepository.AddProductAsync(converter.ConvertProductModelToProductEntity(product).Result);
        }

        public Task DeleteByIdAsync(Guid productId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            IEnumerable<ProductEntity> dbProducts = await productRepository.GetAllAsync(); 
            return dbProducts.Select(product =>converter.ConvertProductEntityToProductModel(product).Result);
        }

        public async Task<Product> GetByIdAsync(Guid productId)
        {
            ProductEntity productEntity = await productRepository.GetProductByIdAsync(productId);

            if (productEntity == null) return null;

            return await converter.ConvertProductEntityToProductModel(productEntity);
        }

        public async Task<IEnumerable<Product>> GetProductByBrandAndCategoryAsync(string brand, string category)
        {
            IEnumerable<ProductEntity> dbProducts = await productRepository.GetProductByBrandAndCategoryAsync(brand, category);

            return dbProducts.Select(product => converter.ConvertProductEntityToProductModel(product).Result);
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(string category)
        {
            IEnumerable<ProductEntity> products = await productRepository.GetProductByCategory(category);

            return products.Select(product => converter.ConvertProductEntityToProductModel(product).Result);
        }

        public async Task<IEnumerable<Product>> GetProductsInRangeAsync(int low, int? high = null)
        {
            IEnumerable<ProductEntity> dbProducts = await productRepository.GetProductsInRangeAsync(low, high);

            List<Product> products = new List<Product>();
            foreach (var product in dbProducts)
                products.Add(await converter.ConvertProductEntityToProductModel(product));

            // IE<Product> products= dbProducts.Select( product => converter.ConvertProductEntityToProductModel(product).Result);
            return products;
        }

        public Task UpdateProductAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
