using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Electronics.Models;
using Electronics.Services.Abstract;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Electronics.Controllers
{
    [Route("api/brand")]
    public class BrandController : Controller
    {
        private readonly IBrandService brandService;
        private readonly IHostingEnvironment appEnvironment;

        public BrandController(IBrandService brandService, IHostingEnvironment appEnvironment)
        {
            this.brandService = brandService;
            this.appEnvironment = appEnvironment;
        }


        /// <summary>
        /// Get all brands
        /// </summary>
        /// <returns>list of brands</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brand>>> GetAllAsync()
        {
            return new OkObjectResult(await brandService.GetAllAsync());
        }

        [HttpPost]
        public async Task<ActionResult<Brand>> AddBrand([FromBody] Brand brand)
        {           
            await brandService.AddBrandAsync(brand);
            return new OkObjectResult(brand);
        }       
    }
}