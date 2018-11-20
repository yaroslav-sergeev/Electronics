using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Electronics.Models;
using Electronics.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Electronics.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService) => this.productService = productService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll() => Ok(await productService.GetAllAsync());
       
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
        [ProducesResponseType(typeof(Product),statusCode:200)]
        [ProducesResponseType(typeof(string),statusCode:404)]
        public async Task<ActionResult> GetProductById(Guid id)
        {
            Product product = await productService.GetByIdAsync(id);
            if (product == null) return NotFound($"there no product with id {id}");
            return Ok(product); 
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
            if (string.IsNullOrEmpty(product.Name) || string.IsNullOrEmpty(product.Brand))
                return BadRequest("invalid data one or more fields were empty");

            await productService.AddProductAsync(product);
            return Created(String.Empty, product);
        }

        [HttpGet("priceInRange")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProductsInRange(int low, int? high)
        {
            int? _high = high != 0 ? _high = high : _high = null; 
            IEnumerable<Product> products = await productService.GetProductsInRangeAsync(low, _high);

            if (products == null || ((List<Product>)products).Count == 0) return NotFound();
            return Ok(products);
        }

        [HttpGet("g")]
        public Guid G() => Guid.NewGuid();
    }
}