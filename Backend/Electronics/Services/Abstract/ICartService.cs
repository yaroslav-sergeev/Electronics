using Electronics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electronics.Services.Abstract
{
   public interface ICartService
    {
        Task AddToCart(Guid cartId,Product product);
        Task RemoveFromCart(Guid cartId,Guid productId);

    }
}
