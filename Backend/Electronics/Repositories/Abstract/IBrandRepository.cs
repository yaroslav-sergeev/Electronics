using Electronics.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electronics.Repositories.Abstract
{
    public interface IBrandRepository
    {
        Task<IEnumerable<BrandEntity>> GetAllAsync();
        Task<BrandEntity> GetBrandByIdAsync(Guid brandId);
        Task DeleteByIdAsync(Guid brandId);
        Task UpdateBrandAsync(BrandEntity brand);
        Task AddBrandAsync(BrandEntity entity);
    }
}
