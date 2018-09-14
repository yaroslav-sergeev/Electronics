using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Electronics.DbEntities;
using Electronics.Repositories.Abstract;
using Dapper;
using System.Data.SqlClient;

namespace Electronics.Repositories.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private readonly string connectionString;

        public ProductRepository(string connectionString) => this.connectionString = connectionString;

        public Task DeleteByIdAsync(Guid productId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductEntity>> GetAllAsync()
        {
            string query = "select * from Product";

            using (var connection =new SqlConnection(connectionString))
            {
               return await connection.QueryAsync<ProductEntity>(query);
            }
        }

        public Task<IEnumerable<ProductEntity>> GetProductByCaqtegory(string category)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductEntity> GetProductByIdAsync(Guid productId)
        {
            string query = "select * from Product where Id=@Id";

            using (var connection = new SqlConnection(connectionString))
            {
                return await connection.QuerySingleAsync<ProductEntity>(query,new { Id=productId });
            }
        }

        public Task UpdateProductAsync(ProductEntity product)
        {
            throw new NotImplementedException();
        }
    }
}
