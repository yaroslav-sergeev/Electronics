﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Electronics.DbEntities;
using Electronics.Repositories.Abstract;

namespace Electronics.Repositories.Concrete
{
    public class BrandRepository : IBrandRepository
    {
        private readonly string connectionString;

        public BrandRepository(string connectionString) => this.connectionString = connectionString;

        public async Task AddBrandAsync(BrandEntity entity)
        {
            string query = "insert into Brand values(@Id,@Name)";

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                 await connection.ExecuteAsync(query,entity);
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

        public Task DeleteByIdAsync(Guid brandId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BrandEntity>> GetAllAsync()
        {
            string query = "select * from Brand";

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    return await connection.QueryAsync<BrandEntity>(query);
                }
            }
            catch (SqlException sql)
            {

                throw;
            }
            catch(Exception e)
            {
                throw;
            }
            
        }

        public Task<BrandEntity> GetBrandByIdAsync(Guid brandId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBrandAsync(BrandEntity brand)
        {
            throw new NotImplementedException();
        }
    }
}
