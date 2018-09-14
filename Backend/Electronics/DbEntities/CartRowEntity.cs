using System;


namespace Electronics.DbEntities
{
    public class CartRowEntity
    {
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

    }
}
