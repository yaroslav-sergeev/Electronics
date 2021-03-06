﻿using System;
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

        public async Task<Product> GetByIdAsync(Guid productId)
        {
            return await converter.MapProductEntityToProductModel(await productRepository.GetProductByIdAsync(productId));
        }

        public async Task<IEnumerable<Product>> GetProductByBrandAndCategoryAsync(string brand, string category)
        {
            IEnumerable<ProductEntity> dbProducts = await productRepository.GetProductByBrandAndCategoryAsync(brand, category);

            return dbProducts.Select(product => converter.MapProductEntityToProductModel(product).Result);
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(string category)
        {
            IEnumerable<ProductEntity> products = await productRepository.GetProductByCategory(category);

            return products.Select(product => converter.MapProductEntityToProductModel(product).Result);
        }

        public Task UpdateProductAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
