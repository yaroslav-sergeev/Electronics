using System.Threading.Tasks;
using Xunit;
using Electronics.Models;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System;
using System.Text;

namespace Electronics.Tests
{
    public class ProductControllerTest
    {
        [Fact(DisplayName = "Get all products return Ok and all products ")]
        public async Task Get_All_Products_ReturnOkResultAndAllProducts()
        {
            using (var client = new TestClientProvider().Client)
            {
                var clientResponse = await client.GetAsync("api/products");

                var responseString = await clientResponse.Content.ReadAsStringAsync();
                List<Product> products = JsonConvert.DeserializeObject<List<Product>>(responseString);

                Assert.Equal(HttpStatusCode.OK, clientResponse.StatusCode);
                Assert.Equal(6, products.Count);
            }
        }

        [Fact(DisplayName = "Get product by uknown id return NotFound result")]
        public async Task GetProductById_UnknownGuidPassed_ReturnNotFoundResult()
        {
            using (var client = new TestClientProvider().Client)
            {
                Guid id = Guid.NewGuid();
                var clientResponse = await client.GetAsync($"api/products/detail/{id}");
                string message = await clientResponse.Content.ReadAsStringAsync();

                Assert.Equal(HttpStatusCode.NotFound, clientResponse.StatusCode);
                Assert.NotEmpty(clientResponse.ReasonPhrase);
                Assert.Equal($"there no product with id {id}",message);
            }
        }

        [Fact(DisplayName = "Get product by existing id return Ok result and product")]
        public async Task GetProductById_ExistingGuidPassed_ReturnOkResultAndProduct()
        {
            using (var client = new TestClientProvider().Client)
            {
                Guid.TryParse("09fb86d7-050d-45b6-ac0d-854d2635ff56", out Guid id);

                var clientResponse = await client.GetAsync($"api/products/detail/{id}");

                var responseString = await clientResponse.Content.ReadAsStringAsync();
                Product product = JsonConvert.DeserializeObject<Product>(responseString);

                Assert.Equal(HttpStatusCode.OK, clientResponse.StatusCode);
                Assert.NotNull(product);
                Assert.Equal("Apple", product.Brand);
                Assert.Equal("Phone", product.Category);
            }
        }

        [Fact(DisplayName = "Add product pass invalid object")]
        public async Task AddProduct_InvalidObjectPassed_ReturnBadRequest()
        {
            using (var client = new TestClientProvider().Client)
            {
                Product product = new Product
                {
                    Id = Guid.Empty,
                    Name = string.Empty,
                    Brand = string.Empty,
                    Category = string.Empty,
                    Color = string.Empty,
                    Dimentions = string.Empty,
                    Discount = default(double),
                    ImageData = string.Empty,
                    ImagePath = string.Empty,
                    Os = string.Empty,
                    Price = default(int),
                    Weight = default(double)
                };

                var clientResponse = await client.PostAsync("api/products",
                    new StringContent(JsonConvert.SerializeObject(product),
                    Encoding.UTF8, "application/json"));

                string message = await clientResponse.Content.ReadAsStringAsync();

                Assert.Equal(HttpStatusCode.BadRequest, clientResponse.StatusCode);
                Assert.Equal("invalid data one or more fields were empty", message);
            }
        }

        [Theory(DisplayName ="Get products in range return Ok and products")]
        [InlineData(7000,20000)]
        [InlineData(10000,null)]
        [InlineData(5000,9000)]
        public async Task GetProductsInRange_ReturnOkAndProducts(int low, int? high)
        {
            using (var client = new TestClientProvider().Client)
            {
               string url = high==null? $"api/products/priceInRange?low={low}" : $"api/products/priceInRange?low={low}&high={high}";
                var clientResponse = await client.GetAsync(url);

                var responseString = await clientResponse.Content.ReadAsStringAsync();
               IEnumerable<Product> products = JsonConvert.DeserializeObject<IEnumerable<Product>>(responseString);

                Assert.Equal(HttpStatusCode.OK, clientResponse.StatusCode);
                Assert.NotNull(products);
                Assert.NotEmpty(products);
            }
               
        }

    }
}
