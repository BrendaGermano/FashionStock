namespace FashionStock.WebApi.Models
{
    public class ImageModel
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public int ProductId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
