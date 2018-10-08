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

        public async Task AddProductAsync(ProductEntity productEntity)
        {
            string query = $"insert into Product values(Id,Name,Color,Dimentions,Weight,Os,Discount,ImagePath,Price,BrandId,CategoryId)";

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.ExecuteAsync(query,productEntity);
                }
            }
            catch (SqlException sql)
            {
                throw;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Task DeleteByIdAsync(Guid productId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductEntity>> GetAllAsync()
        {
            string query = "select * from Product";

            using (var connection = new SqlConnection(connectionString))
            {
                return await connection.QueryAsync<ProductEntity>(query);
            }
        }

        public async Task<IEnumerable<ProductEntity>> GetProductByBrandAndCategoryAsync(string brand, string category)
        {
            string query = "select Product.* from (((select Category.Id from Category where Name=@category) as Cat inner join CategoryBrand on Cat.Id=CategoryBrand.CategoryId)" +
                            "inner join(select Brand.Id from Brand where Name= @brand) as Br on CategoryBrand.BrandId = Br.Id)" +
                            "inner join Product on Product.BrandId = CategoryBrand.BrandId and Product.CategoryId = CategoryBrand.CategoryId";

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    return await connection.QueryAsync<ProductEntity>(query,new { brand, category });
                }
            }
            catch (SqlException sql)
            {
                throw;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ProductEntity>> GetProductByCategory(string category)
        {
            string query = "select Product.* from ((select Id from Category where Name=@category) as Cat inner join CategoryBrand on Cat.Id=CategoryBrand.CategoryId)"+
                            "inner join Product on Product.CategoryId=CategoryBrand.CategoryId and CategoryBrand.BrandId=Product.BrandId";

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    return await connection.QueryAsync<ProductEntity>(query, new { category });
                }
            }
            catch (SqlException sql)
            {
                throw;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<ProductEntity> GetProductByIdAsync(Guid productId)
        {
            string query = "select * from Product where Id=@Id";

            using (var connection = new SqlConnection(connectionString))
            {
                return await connection.QuerySingleAsync<ProductEntity>(query, new {Id =productId });
            }
        }

        public Task UpdateProductAsync(ProductEntity product)
        {
            throw new NotImplementedException();
        }
    }
}
