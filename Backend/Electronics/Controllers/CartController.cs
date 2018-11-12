using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Electronics.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Electronics.Controllers
{
    [Route("api/cart")]
    public class CartController : Controller
    {
        [HttpPost]
        public async Task<ActionResult<Product>> AddToCart([FromBody]Product product)
        {

            return new OkObjectResult(product);
        }

        //[HttpPost("a")]
        //public string A()
        //{
        //    var s = HttpContext;
        //    return s.Id;
        //}
    }
}