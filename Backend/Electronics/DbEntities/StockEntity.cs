using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electronics.DbEntities
{
    public class StockEntity
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
