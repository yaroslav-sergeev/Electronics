using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electronics.DbEntities
{
    public class CartEntity
    {
        public Guid Id { get; set; }
        public int Total { get; set; }
    }
}
