using Electronics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electronics.Services.Abstract
{
    public interface IBrandService
    {
        Task<IEnumerable<Brand>> GetAllAsync();
        Task<Brand> GetBrandByIdAsync(Guid brandId);
        Task DeleteByIdAsync(Guid brandId);
        Task UpdateBrandAsync(Brand brand);
        Task AddBrandAsync(Brand brand);
    }
}
