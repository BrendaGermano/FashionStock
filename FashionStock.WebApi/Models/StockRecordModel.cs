using FashionStock.Entities;

namespace FashionStock.WebApi.Models
{

    public class StockRecordModel 
    {
        public int Id { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public int UserId { get; set; }
        public long RecordTypeId { get; set; } 
        public RecordType RecordType { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
