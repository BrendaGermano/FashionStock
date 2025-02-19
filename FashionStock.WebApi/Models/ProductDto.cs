namespace FashionStock.WebApi.Models
{
    public class ProductDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int TotalSold { get; set; }
        public long ProductId { get; set; }
    }
}
