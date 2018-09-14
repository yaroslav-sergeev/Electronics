using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Electronics.Models;
using Electronics.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Electronics.Controllers
{
    [Route("api/product")]
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService) => this.productService = productService;

       [HttpGet]
       public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            return new OkObjectResult( await productService.GetAllAsync());
        }

      
    }
}