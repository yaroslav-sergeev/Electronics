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

        public Task DeleteByIdAsync(Guid productId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            IEnumerable<ProductEntity> dbProducts = await productRepository.GetAllAsync();

            return dbProducts.Select(product => converter.MapProductEntityToProductModel(product).Result);
        }

        public Task<Product> GetByIdAsync(Guid productId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductByCaqtegory(string category)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProductAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
