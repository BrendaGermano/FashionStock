using FashionStock.Entities;

namespace FashionStock.WebApi.Models
{
    public class ProductModel
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public float Price { get; set; }
            public int CategoryId { get; set; }
            public int Quantity { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }
    }
}
