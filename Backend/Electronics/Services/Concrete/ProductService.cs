using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Electronics.Models;
using Electronics.Repositories.Abstract;
using Electronics.Repositories.Concrete;
using Electronics.Services.Abstract;

namespace Electronics.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(string connectionString) => productRepository = new ProductRepository(connectionString);

        public Task DeleteByIdAsync(Guid productId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var dbProducts = await productRepository.GetAllAsync();
            throw new NotImplementedException();
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
