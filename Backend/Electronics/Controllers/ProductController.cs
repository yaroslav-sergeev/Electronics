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
        public async Task<ActionResult<IEnumerable<Product>>> GetAll() => new OkObjectResult(await productService.GetAllAsync());

        [HttpGet("{brand}/{category}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductByBrandAndCategoryAsync(string brand, string category)
        {
            brand = brand.ToLower();
            brand = brand.Replace(brand[0], char.ToUpper(brand[0]));// BRAND || brand  -> Brand

            category = category.ToLower();
            category = category.Replace(category[0], char.ToUpper(category[0]));
            return new OkObjectResult(await productService.GetProductByBrandAndCategoryAsync(brand, category));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(Guid id)
        {
            if (id == null) return new BadRequestObjectResult(null);

            return new OkObjectResult(await productService.GetByIdAsync(id));
        }

        [HttpGet("{category}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategory(string category)
        {
            category = category.ToLower();
            category = category.Replace(category[0], char.ToUpper(category[0]));

            return new OkObjectResult(await productService.GetProductByCategory(category));
        }
    }
}