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
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository brandRepository;
        private readonly IConverter converter = new Converter();

        public BrandService(string connectionString) => brandRepository = new BrandRepository(connectionString);

        public async Task AddBrandAsync(Brand brand)
        {
            await brandRepository.AddBrandAsync(await converter.MapBrandModelToBrandEntity(brand));
        }

        public Task DeleteByIdAsync(Guid brandId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Brand>> GetAllAsync()
        {
            IEnumerable<BrandEntity> dbBrands = await brandRepository.GetAllAsync();

            // List<Brand> brands = null;

            var sdv = dbBrands.Select(brand => converter.MapBrandEntityToBrandModel(brand).Result);
            //foreach (var brand in dbBrands)
            //{
            //    brands.Add(Converter.MapBrandEntityToBrandModel(brand).Result);
            //}
            return sdv;
        }

        public Task<Brand> GetBrandByIdAsync(Guid brandId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBrandAsync(Brand brand)
        {
            throw new NotImplementedException();
        }
    }
}
