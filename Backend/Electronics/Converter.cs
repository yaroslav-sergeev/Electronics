using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Electronics.Models;
using Electronics.DbEntities;

namespace Electronics
{
    public class Converter:IConverter
    {      
        public  Task<Product> MapProductEntityToProductModel(ProductEntity entity)
        {
            Product product = new Product
            {
                Id = entity.Id,

            };
            throw new NotImplementedException();
        }

        public async Task<Brand> MapBrandEntityToBrandModel(BrandEntity entity)
        {
            return await Task.Run(() =>
             {
                 return new Brand
                 {
                     Id = entity.Id,
                     Name = entity.Name,
                     LogoData = ImageLoader.GetBytesAsync(entity.LogoPath).Result,
                     LogoPath = entity.LogoPath
                 };
             });
        }

        public Task<BrandEntity> MapBrandModelToBrandEntity(Brand brand)
        {
            return Task.Run(() =>
            {
                return new BrandEntity
                {
                    Id = brand.Id,
                    Name = brand.Name,
                     LogoPath = brand.LogoPath
                };
            });
        }
        
    }
}
