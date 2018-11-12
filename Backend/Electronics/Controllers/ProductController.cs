using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Electronics.Models;
using Electronics.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Electronics.Controllers
{
    [Route("api/products")]
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService) => this.productService = productService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll() => 
            new OkObjectResult(await productService.GetAllAsync());
       
        [HttpGet("{brand}/{category}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductByBrandAndCategoryAsync(string brand, string category)
        {
            // convert name e.g. BRAND || brand  -> Brand
            brand = brand.ToLower();          
            brand = brand.Replace(brand[0], char.ToUpper(brand[0]));

            category = category.ToLower();
            category = category.Replace(category[0], char.ToUpper(category[0]));
            return new OkObjectResult(await productService.GetProductByBrandAndCategoryAsync(brand, category));
        }

        [HttpGet("detail/{id}")]
        public async Task<ActionResult<Product>> GetProductById(Guid id)
        {            
            return new OkObjectResult(await productService.GetByIdAsync(id));
        }


        [HttpGet("{category}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategory(string category)
        {
            category = category.ToLower();
            category = category.Replace(category[0], char.ToUpper(category[0]));

            return new OkObjectResult(await productService.GetProductByCategory(category));
        }

        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct([FromBody] Product product)
        {
            await productService.AddProductAsync(product);

            return new OkObjectResult(product);
        }

        [HttpGet("g")]
        public Guid G() => Guid.NewGuid();
    }
}