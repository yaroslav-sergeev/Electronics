using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electronics.DbEntities
{
    public class BrandEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LogoPath { get; set; }               
    }
}
