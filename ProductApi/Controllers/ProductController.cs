using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static ProductApi.Dtos;

namespace ProductApi.Controllers
{
    [Route("product")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private static readonly List<ProductDto> products = new()
        {
            new ProductDto(Guid.NewGuid(), "termék1",3500,DateTimeOffset.UtcNow),
            new ProductDto(Guid.NewGuid(), "termék2",2500,DateTimeOffset.UtcNow),
            new ProductDto(Guid.NewGuid(), "termék3",1500,DateTimeOffset.UtcNow)
        };


        [HttpGet]

        public IEnumerable<ProductDto> GetAll()
        {
            return products;
        }

        [HttpGet("{id}")]
        public ProductDto GetById(Guid id)
        {
            var product = products.Where(x => x.Id == id).FirstOrDefault();

            return product;
        }

        [HttpPost]
        public ProductDto PostProduct(CreateProductDto createProduct)
        {
            var product = new ProductDto(
                Guid.NewGuid(),
                createProduct.ProductName,
                createProduct.ProductPrice,
                DateTimeOffset.UtcNow
                );

            products.Add(product);

            return CreatedAtAction(nameof(GetAll), new {id = product.Id}, product);
        }

        [HttpPut("{id}")]

        public ProductDto PullProduct(Guid id, UpdateProductDto updateProduct)
        {
            var existingProduct = products.Where(x =>x.Id == id).FirstOrDefault();

            var product = existingProduct with
            {
                ProductName = updateProduct.ProductName,
                ProductPrice = updatebProduct.ProductPrice,
            };

            var index = products.FindIndex(x => x.Id == id);
            products[index] = product;

            return product[index];        
        }

        [HttpDelete("(id)")]

        public string Delete(Guid id)
        {
            var index = products.FindIndex(x =>x.Id == id);
            products,removeAt(index);
            return "Az elem kitörölve";
        }

    }
}
