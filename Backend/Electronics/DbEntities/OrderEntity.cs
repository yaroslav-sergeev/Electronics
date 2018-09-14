using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electronics.DbEntities
{
    public class OrderEntity
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public Guid CartId { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public int Discount { get; set; }
    }
}
