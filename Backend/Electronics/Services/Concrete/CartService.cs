using Electronics.Models;
using Electronics.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electronics.Services.Concrete
{
    public class CartService : ICartService
    {
        public Task AddToCart(Guid cartId, Product product)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromCart(Guid cartId, Guid productId)
        {
            throw new NotImplementedException();
        }

    }
}
