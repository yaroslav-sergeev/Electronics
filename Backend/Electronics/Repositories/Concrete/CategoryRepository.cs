using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Electronics.DbEntities;
using Electronics.Repositories.Abstract;
using Dapper;

namespace Electronics.Repositories.Concrete
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly string connectionString;

        public CategoryRepository(string connectionString) => this.connectionString = connectionString;

        public async Task DeleteByIdAsync(Guid productId)
        {
            string query = string.Empty;

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.ExecuteAsync(query);
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

        //public Task<IEnumerable<CategoryEntity>> GetAllAsync()
        //{
        //    try
        //    {
        //        using (var connection = new SqlConnection(connectionString))
        //        {
        //           // await connection.ExecuteAsync(query, entity);
        //        }
        //    }
        //    catch (SqlException sql)
        //    {
        //        throw;
        //    }
        //    catch (Exception e)
        //    {
        //        throw;
        //    }
        //}

        public async Task<IEnumerable<CategoryEntity>> GetCategoriesOfBrand(Guid brandId)
        {
            string query = "select Category.* from (Category inner join CategoryBrand on Category.Id=CategoryBrand.CategoryId) inner join Brand on CategoryBrand.BrandId=Brand.Id where BrandId = @brandId";
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    return await connection.QueryAsync<CategoryEntity>(query);
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

        public async Task<CategoryEntity> GetCategoryByIdAsync(Guid categoryId)
        {
            string query = string.Empty;
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                   return await connection.QueryFirstOrDefaultAsync<CategoryEntity>(query);
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

        public async Task UpdateCategoryAsync(CategoryEntity category)
        {
            string query = string.Empty;
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.ExecuteAsync(query, category);
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
    }
}
