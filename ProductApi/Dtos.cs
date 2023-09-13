namespace ProductApi
{
    public class Dtos
    {
        public record ProductDto(Guid Id, string ProducktName, int ProductPrice, DateTimeOffset CreatTime);
        public record CreateProductDto(string ProductName, int ProductPrice);

        public record UpdateProductDto(string ProductName, int ProductPrice);

    }
}
