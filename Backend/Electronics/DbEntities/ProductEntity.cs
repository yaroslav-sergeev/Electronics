using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electronics.DbEntities
{
    public class ProductEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Dimentions { get; set; }
        public double Weight { get; set; }
        public string Os { get; set; }
        public double Discount { get; set; }
        public string ImagePath { get; set; }
        public int Price { get; set; }
        
        public Guid BrandId { get; set; }
    }
}
